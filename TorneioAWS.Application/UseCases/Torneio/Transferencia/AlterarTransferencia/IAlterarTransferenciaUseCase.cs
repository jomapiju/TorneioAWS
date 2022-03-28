using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Domain;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarTransferencia;

public interface IAlterarTransferenciaUseCase {
    IResourceModel Execute(Guid id, JsonPatchDocument<Transferencia> TransferenciaRequest);
}