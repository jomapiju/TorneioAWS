using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosCompeticoes;

public interface IObterTodosCompeticoesUseCase
{
    IResourceModel Execute();
}