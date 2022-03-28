using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;

public interface ISalvarCompeticaoUseCase
{
    IResourceModel Execute(SalvarCompeticaoRequestDto Competicao);
}