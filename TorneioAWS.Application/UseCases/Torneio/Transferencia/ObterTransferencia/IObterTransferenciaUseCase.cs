namespace TorneioAWS.Application.UseCases.Torneio.ObterTransferencia;
using TorneioAWS.Application.ResourceModel;

public interface IObterTransferenciaUseCase
{
    IResourceModel Execute(Guid id);
}