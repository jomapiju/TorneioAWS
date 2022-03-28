namespace TorneioAWS.Application.UseCases.Torneio.ObterTime;
using TorneioAWS.Application.ResourceModel;

public interface IObterTimeUseCase
{
    IResourceModel Execute(Guid id);
}