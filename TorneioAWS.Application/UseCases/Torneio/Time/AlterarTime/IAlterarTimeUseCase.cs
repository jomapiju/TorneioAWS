using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Domain;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarTime;

public interface IAlterarTimeUseCase {
    IResourceModel Execute(Guid id, JsonPatchDocument<Time> timeRequest);
}