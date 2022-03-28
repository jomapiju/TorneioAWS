using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarJogador;

public interface IDeletarJogadorUseCase
{
    IResourceModel Execute(Guid id);
}