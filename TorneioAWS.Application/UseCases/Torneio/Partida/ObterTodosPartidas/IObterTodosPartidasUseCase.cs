using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosPartidas;

public interface IObterTodosPartidasUseCase
{
    IResourceModel Execute();
}