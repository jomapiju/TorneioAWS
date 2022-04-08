using TorneioAWS.Application.Repository;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.UseCases.Torneio.AdicionaEvento;
using TorneioAWS.Domain;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace TorneioAWS.UseCase.AdicionaEvento;

public  class AdicionaEventoUseCase : IAdicionaEventoUseCase
{
    private readonly IRepository<Evento> _eventoRepository;
    private readonly IRepository<Competicao> _competicaoRepository;
    private readonly IObterCompeticaoEspecificacao _obterCompeticaoEspecificacao;
    private readonly IRepository<Partida> _partidaRepository;
    private readonly IObterPartidaEspecificacao _obterPartidaEspecificacao;
    private readonly IRepository<Time> _timeRepository;
    private readonly IObterTimeEspecificacao _obterTimeEspecificacao;
    private readonly IConnectionMultiplexer _redis;
    public AdicionaEventoUseCase(IRepository<Evento> eventoRepository,
            IRepository<Competicao> competicaoRepository,
            IObterCompeticaoEspecificacao obterCompeticaoEspecificacao,
            IRepository<Partida> partidaRepository,
            IObterPartidaEspecificacao obterPartidaEspecificacao,
            IRepository<Time> timeRepository,
            IObterTimeEspecificacao obterTimeEspecificacao,
            IConnectionMultiplexer redis)
    {
        _eventoRepository = eventoRepository;
        _competicaoRepository = competicaoRepository;
        _obterCompeticaoEspecificacao = obterCompeticaoEspecificacao;
        _obterPartidaEspecificacao = obterPartidaEspecificacao;
        _partidaRepository = partidaRepository;
        _obterTimeEspecificacao = obterTimeEspecificacao;
        _timeRepository = timeRepository;
        _redis = redis;
    }

    public async Task<IResourceModel> Execute(EventoRequestDto eventoRequest)
    {
        if (eventoRequest == null)
            return null;

        if (eventoRequest.ComepticaoId == null 
        || eventoRequest.PartidaId == null
        || eventoRequest.TimeId == null) {
            return null;
        }

        Competicao competicao = await RecuperaCache<Competicao>(eventoRequest.ComepticaoId.ToString());
        if (competicao == null) {
            competicao = _competicaoRepository.Get(_obterCompeticaoEspecificacao.Execute(eventoRequest.ComepticaoId));
            if (competicao == null) {
                return null;
            } else {
                await AdicionaCache(competicao.CompeticaoId.ToString(), competicao);
            }
        }

        Partida partida = await RecuperaCache<Partida>(eventoRequest.PartidaId.ToString());
        if (partida == null) {
            partida = _partidaRepository.Get(_obterPartidaEspecificacao.Execute(eventoRequest.PartidaId));
            if (partida == null) {
                return null;
            } else {
                await AdicionaCache(partida.PartidaId.ToString(), partida);
            }
        }

        if (!competicao.CompeticaoId.Equals(partida.CompeticaoId))
            return null;

        Time time = _timeRepository.Get(_obterTimeEspecificacao.Execute(eventoRequest.TimeId));
        if (time == null) {
            time = _timeRepository.Get(_obterTimeEspecificacao.Execute(eventoRequest.TimeId));
            if (time == null) {
                return null;
            } else {
                await AdicionaCache(time.TimeId.ToString(), time);
            }
        }

        if (!partida.TimeCasaId.Equals(time.TimeId) && !partida.TimeVisitanteId.Equals(time.TimeId))
            return null;

        Evento evento = new Evento {
            EventoId = Guid.NewGuid(),
            ComepticaoId = eventoRequest.ComepticaoId,
            PartidaId = eventoRequest.PartidaId,
            TimeId = eventoRequest.TimeId,
            TipoEvento = eventoRequest.TipoEvento
        };
        
        _eventoRepository.Add(evento);

        return eventoRequest;
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