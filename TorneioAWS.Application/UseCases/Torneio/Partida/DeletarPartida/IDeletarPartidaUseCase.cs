using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarPartida;

public interface IDeletarPartidaUseCase
{
    IResourceModel Execute(Guid id);
}