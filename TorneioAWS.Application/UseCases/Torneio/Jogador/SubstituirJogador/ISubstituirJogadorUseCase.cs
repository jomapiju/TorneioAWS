using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirJogador;

public interface ISubstituirJogadorUseCase {
    IResourceModel Execute(Guid id, SubstituirJogadorRequestDto JogadorRequest);
}