using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.ObterCompeticao;
public interface IObterCompeticaoUseCase
{
    IResourceModel Execute(Guid id);
}