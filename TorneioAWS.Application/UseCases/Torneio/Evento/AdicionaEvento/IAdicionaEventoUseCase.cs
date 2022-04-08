
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AdicionaEvento;

public interface IAdicionaEventoUseCase {
    Task<IResourceModel> Execute(EventoRequestDto eventoRequest);
}