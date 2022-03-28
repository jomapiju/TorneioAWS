using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.ObterPartida;
public interface IObterPartidaUseCase
{
    IResourceModel Execute(Guid id);
}