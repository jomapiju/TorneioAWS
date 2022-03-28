using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Domain;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarJogador;

public interface IAlterarJogadorUseCase {
    IResourceModel Execute(Guid id, JsonPatchDocument<Jogador> JogadorRequest);
}