using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirTransferencia;

public interface ISubstituirTransferenciaUseCase {
    IResourceModel Execute(Guid id, SubstituirTransferenciaRequestDto TransferenciaRequest);
}