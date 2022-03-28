using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosJogadores;

public interface IObterTodosJogadoresUseCase
{
    IResourceModel Execute();
}