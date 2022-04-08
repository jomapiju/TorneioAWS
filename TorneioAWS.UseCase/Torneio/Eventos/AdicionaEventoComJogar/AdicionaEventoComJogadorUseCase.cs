using TorneioAWS.Application.Repository;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.UseCases.Torneio.AdicionaEventoComJogador;
using TorneioAWS.Domain;
using StackExchange.Redis;
using Newtonsoft.Json;
using TorneioAWS.Domain.Enumeradores;

namespace TorneioAWS.UseCase.AdicionaEventoComJogador;
public  class AdicionaEventoComJogadorUseCase : IAdicionaEventoComJogadorUseCase
{
    private readonly IRepository<Evento> _eventoRepository;
    private readonly IRepository<Competicao> _competicaoRepository;
    private readonly IObterCompeticaoEspecificacao _obterCompeticaoEspecificacao;
    private readonly IRepository<Partida> _partidaRepository;
    private readonly IObterPartidaEspecificacao _obterPartidaEspecificacao;
    private readonly IRepository<Time> _timeRepository;
    private readonly IObterTimeEspecificacao _obterTimeEspecificacao;
    private readonly IRepository<Jogador> _jogadorRepository;
    private readonly IObterJogadorEspecificacao _obterJogadorEspecificacao;
    private readonly IConnectionMultiplexer _redis;
    public AdicionaEventoComJogadorUseCase(IRepository<Evento> eventoRepository,
            IRepository<Competicao> competicaoRepository,
            IObterCompeticaoEspecificacao obterCompeticaoEspecificacao,
            IRepository<Partida> partidaRepository,
            IObterPartidaEspecificacao obterPartidaEspecificacao,
            IRepository<Time> timeRepository,
            IObterTimeEspecificacao obterTimeEspecificacao,
            IRepository<Jogador> jogadorRepository,
            IObterJogadorEspecificacao obterJogadorEspecificacao,
            IConnectionMultiplexer redis)
    {
        _eventoRepository = eventoRepository;
        _competicaoRepository = competicaoRepository;
        _obterCompeticaoEspecificacao = obterCompeticaoEspecificacao;
        _obterPartidaEspecificacao = obterPartidaEspecificacao;
        _partidaRepository = partidaRepository;
        _obterTimeEspecificacao = obterTimeEspecificacao;
        _timeRepository = timeRepository;
        _obterJogadorEspecificacao = obterJogadorEspecificacao;
        _jogadorRepository = jogadorRepository;
        _redis = redis;
    }

    public async Task<IResourceModel> Execute(EventoComJogadorRequestDto eventoComJogadorRequest)
    {
        if (eventoComJogadorRequest == null)
            return null;

        if (eventoComJogadorRequest.ComepticaoId == null 
        || eventoComJogadorRequest.PartidaId == null
        || eventoComJogadorRequest.TimeId == null
        || eventoComJogadorRequest.JogadorPrincipalId == null
        || (eventoComJogadorRequest.JogadorSecundarioId == null && eventoComJogadorRequest.TipoEvento == TipoEvento.Substituicao)) {
            return null;
        }

        Competicao competicao = await RecuperaCache<Competicao>(eventoComJogadorRequest.ComepticaoId.ToString());
        if (competicao == null) {
            competicao = _competicaoRepository.Get(_obterCompeticaoEspecificacao.Execute(eventoComJogadorRequest.ComepticaoId));
            if (competicao == null) {
                return null;
            } else {
                await AdicionaCache(competicao.CompeticaoId.ToString(), competicao);
            }
        }

        Partida partida = await RecuperaCache<Partida>(eventoComJogadorRequest.PartidaId.ToString());
        if (partida == null) {
            partida = _partidaRepository.Get(_obterPartidaEspecificacao.Execute(eventoComJogadorRequest.PartidaId));
            if (partida == null) {
                return null;
            } else {
                await AdicionaCache(partida.PartidaId.ToString(), partida);
            }
        }

        if (!competicao.CompeticaoId.Equals(partida.CompeticaoId))
            return null;

        Time time = await RecuperaCache<Time>(eventoComJogadorRequest.TimeId.ToString());
        if (time == null) {
            time = _timeRepository.Get(_obterTimeEspecificacao.Execute(eventoComJogadorRequest.TimeId));
            if (time == null) {
                return null;
            } else {
                await AdicionaCache(time.TimeId.ToString(), time);
            }
        }

        if (!partida.TimeCasaId.Equals(time.TimeId) && !partida.TimeVisitanteId.Equals(time.TimeId))
            return null;

        Jogador jogadorPrincipal = await RecuperaCache<Jogador>(eventoComJogadorRequest.JogadorPrincipalId.ToString());
        if (jogadorPrincipal == null) {
            jogadorPrincipal = _jogadorRepository.Get(_obterJogadorEspecificacao.Execute(eventoComJogadorRequest.JogadorPrincipalId));
            if (jogadorPrincipal == null) {
                return null;
            } else {
                await AdicionaCache(jogadorPrincipal.JogadorId.ToString(), jogadorPrincipal);
            }
        }

        if(jogadorPrincipal.TimeId.Equals(time.TimeId))
            return null;

        if (eventoComJogadorRequest.TipoEvento == TipoEvento.Substituicao) {
            Jogador jogadorSecundario = await RecuperaCache<Jogador>(eventoComJogadorRequest.JogadorSecundarioId.ToString());
            if (jogadorSecundario == null) {
                jogadorSecundario = _jogadorRepository.Get(_obterJogadorEspecificacao.Execute((Guid)eventoComJogadorRequest.JogadorSecundarioId));
                if (jogadorSecundario == null) {
                    return null;
                } else {
                    await AdicionaCache(jogadorSecundario.JogadorId.ToString(), jogadorSecundario);
                }
            }

            if(jogadorSecundario.TimeId.Equals(time.TimeId))
                return null;
        }

        Evento evento = new Evento {
            EventoId = Guid.NewGuid(),
            ComepticaoId = eventoComJogadorRequest.ComepticaoId,
            PartidaId = eventoComJogadorRequest.PartidaId,
            TimeId = eventoComJogadorRequest.TimeId,
            TipoEvento = eventoComJogadorRequest.TipoEvento,
            JogadorPrincipalId = eventoComJogadorRequest.JogadorPrincipalId,
            JogadorSecundarioId = eventoComJogadorRequest.JogadorSecundarioId
        };
        
        _eventoRepository.Add(evento);

        return eventoComJogadorRequest;
    }

    private async Task AdicionaCache(string key, object valor)
        => await _redis.GetDatabase().StringSetAsync(key, JsonConvert.SerializeObject(valor), TimeSpan.FromMinutes(10), When.NotExists)
        .ConfigureAwait(false);

    private async Task<T> RecuperaCache<T>(string key) 
    {
        RedisValue rv = await _redis.GetDatabase().StringGetAsync(key).ConfigureAwait(false);
        if (!rv.HasValue)
            return default;
        T rgv = JsonConvert.DeserializeObject<T>(rv);
        return rgv;
    }
}