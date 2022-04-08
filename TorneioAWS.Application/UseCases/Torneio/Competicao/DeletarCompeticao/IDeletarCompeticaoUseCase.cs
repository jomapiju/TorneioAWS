using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarCompeticao;

public interface IDeletarCompeticaoUseCase
{
    string Execute(Guid id);
}