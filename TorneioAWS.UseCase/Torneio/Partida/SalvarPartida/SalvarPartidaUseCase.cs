using TorneioAWS.Application.UseCases.Torneio.SalvarPartida;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SalvarPartida;

public  class SalvarPartidaUseCase : ISalvarPartidaUseCase
{
    private readonly IRepository<Partida> _partidaRepository;
    public SalvarPartidaUseCase(IRepository<Partida> partidaRepository)
    {
        _partidaRepository = partidaRepository;
    }

    public IResourceModel Execute(SalvarPartidaRequestDto partidaRequest)
    {

        if (partidaRequest == null)
            return null;

        if (partidaRequest.TimeCasaId == null
        || partidaRequest.TimeVisitanteId == null
        || partidaRequest.CompeticaoId == null) {
            return null;
        }

        Partida partida = new Partida {
            PartidaId = new Guid(),
            TimeCasaId = partidaRequest.TimeCasaId,
            TimeVisitanteId = partidaRequest.TimeVisitanteId,
            CompeticaoId = partidaRequest.CompeticaoId
        };
        
        _partidaRepository.Add(partida);

        return new SalvarPartidaDto {
            PartidaId = partida.PartidaId,
            TimeCasaId = partida.TimeCasaId,
            TimeVisitanteId = partida.TimeVisitanteId,
            CompeticaoId = partida.CompeticaoId
        };
    }
}