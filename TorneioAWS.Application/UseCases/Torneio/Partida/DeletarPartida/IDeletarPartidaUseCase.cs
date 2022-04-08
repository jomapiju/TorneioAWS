using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarPartida;

public interface IDeletarPartidaUseCase
{
    string Execute(Guid id);
}