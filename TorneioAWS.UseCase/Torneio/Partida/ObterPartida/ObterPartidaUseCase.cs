using TorneioAWS.Application.UseCases.Torneio.ObterPartida;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterPartida;
public  class ObterPartidaUseCase : IObterPartidaUseCase
{
    private readonly IRepository<Partida> _partidaRepository;
    private readonly IObterPartidaEspecificacao _obterPartidaEspecificacao;
    public ObterPartidaUseCase(IRepository<Partida> partidaRepository,
            IObterPartidaEspecificacao obterPartidaEspecificacao)
    {
        _obterPartidaEspecificacao = obterPartidaEspecificacao;
        _partidaRepository = partidaRepository;
    }

    public IResourceModel Execute(Guid id)
    {
        var partida = _partidaRepository.Get(_obterPartidaEspecificacao.Execute(id));

        if (partida == null)
            return null;

        return new ObterPartidaDto {
            PartidaId = partida.PartidaId,
            TimeCasaId = partida.TimeCasaId,
            TimeVisitanteId = partida.TimeVisitanteId,
            CompeticaoId = partida.CompeticaoId
        };
    }
}