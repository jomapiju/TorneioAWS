using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarTime;

public interface IDeletarTimeUseCase
{
    IResourceModel Execute(Guid id);
}