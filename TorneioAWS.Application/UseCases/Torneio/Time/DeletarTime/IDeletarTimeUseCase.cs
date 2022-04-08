using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarTime;

public interface IDeletarTimeUseCase
{
    string Execute(Guid id);
}