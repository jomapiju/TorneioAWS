using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarCompeticao;

public interface IDeletarCompeticaoUseCase
{
    IResourceModel Execute(Guid id);
}