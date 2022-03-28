using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Domain;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarCompeticao;

public interface IAlterarCompeticaoUseCase {
    IResourceModel Execute(Guid id, JsonPatchDocument<Competicao> CompeticaoRequest);
}