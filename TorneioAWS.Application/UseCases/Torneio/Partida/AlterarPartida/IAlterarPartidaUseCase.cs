using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Domain;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarPartida;

public interface IAlterarPartidaUseCase {
    IResourceModel Execute(Guid id, JsonPatchDocument<Partida> PartidaRequest);
}