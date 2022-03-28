using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirTime;

public interface ISubstituirTimeUseCase {
    IResourceModel Execute(Guid id, SubstituirTimeRequestDto timeRequest);
}