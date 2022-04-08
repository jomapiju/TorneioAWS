using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarJogador;

public interface IDeletarJogadorUseCase
{
    string Execute(Guid id);
}