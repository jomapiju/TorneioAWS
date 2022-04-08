using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.DeletarTransferencia;

public interface IDeletarTransferenciaUseCase
{
    string Execute(Guid id);
}