using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.ObterJogador;
public interface IObterJogadorUseCase
{
    IResourceModel Execute(Guid id);
}