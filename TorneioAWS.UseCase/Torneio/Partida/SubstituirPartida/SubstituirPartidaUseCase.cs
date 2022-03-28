using TorneioAWS.Application.UseCases.Torneio.SubstituirPartida;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SubstituirPartida;

public  class SubstituirPartidaUseCase : ISubstituirPartidaUseCase
{
    private readonly IRepository<Partida> _partidaRepository;
    private readonly IObterPartidaEspecificacao _obterPartidaEspecificacao;
    public SubstituirPartidaUseCase(IRepository<Partida> partidaRepository,
            IObterPartidaEspecificacao obterPartidaEspecificacao)
    {
        _partidaRepository = partidaRepository;
        _obterPartidaEspecificacao = obterPartidaEspecificacao;
    }

    public IResourceModel Execute(Guid id, SubstituirPartidaRequestDto partidaRequest)
    {

        if (partidaRequest == null)
            return null;


        if (partidaRequest.TimeCasaId == null
        || partidaRequest.TimeVisitanteId == null
        || partidaRequest.CompeticaoId == null) {
            return null;
        }
        
        Partida partida = _partidaRepository.Get(_obterPartidaEspecificacao.Execute(id));

        if (partida == null)
            return null;
        
        partida.TimeCasaId = partidaRequest.TimeCasaId;
        partida.TimeVisitanteId = partidaRequest.TimeVisitanteId;
        partida.CompeticaoId = partidaRequest.CompeticaoId;

        _partidaRepository.Update(partida);

        return new SubstituirPartidaDto {
            PartidaId = partida.PartidaId,
            TimeCasaId = partida.TimeCasaId,
            TimeVisitanteId = partida.TimeVisitanteId,
            CompeticaoId = partida.CompeticaoId
        };
    }
}