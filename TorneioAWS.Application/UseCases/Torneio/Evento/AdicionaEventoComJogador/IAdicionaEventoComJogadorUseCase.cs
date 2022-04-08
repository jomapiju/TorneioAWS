
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AdicionaEventoComJogador;

public interface IAdicionaEventoComJogadorUseCase {
    Task<IResourceModel> Execute(EventoComJogadorRequestDto eventoComJogadorRequest);
}