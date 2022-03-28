using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirPartida;

public interface ISubstituirPartidaUseCase {
    IResourceModel Execute(Guid id, SubstituirPartidaRequestDto PartidaRequest);
}