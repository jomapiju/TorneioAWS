using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarJogador;

public interface ISalvarJogadorUseCase
{
    IResourceModel Execute(SalvarJogadorRequestDto Jogador);
}