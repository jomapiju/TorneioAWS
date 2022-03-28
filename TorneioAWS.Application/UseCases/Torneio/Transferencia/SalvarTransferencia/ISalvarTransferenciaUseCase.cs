using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarTransferencia;

public interface ISalvarTransferenciaUseCase
{
    IResourceModel Execute(SalvarTransferenciaRequestDto Transferencia);
}