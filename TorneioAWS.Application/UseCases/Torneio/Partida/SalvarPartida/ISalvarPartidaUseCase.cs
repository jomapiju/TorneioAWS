using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarPartida;

public interface ISalvarPartidaUseCase
{
    IResourceModel Execute(SalvarPartidaRequestDto Partida);
}