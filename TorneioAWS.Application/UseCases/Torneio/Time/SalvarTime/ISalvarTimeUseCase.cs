using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarTime;

public interface ISalvarTimeUseCase
{
    IResourceModel Execute(SalvarTimeRequestDto time);
}