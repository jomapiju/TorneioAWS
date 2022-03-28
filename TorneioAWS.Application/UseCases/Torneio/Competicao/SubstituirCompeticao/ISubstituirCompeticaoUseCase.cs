using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirCompeticao;

public interface ISubstituirCompeticaoUseCase {
    IResourceModel Execute(Guid id, SubstituirCompeticaoRequestDto CompeticaoRequest);
}