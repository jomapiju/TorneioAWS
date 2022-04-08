using TorneioAWS.Domain.Enumeradores;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AdicionaEventoComJogador;

public class EventoComJogadorRequestDto : IResourceModel
{
    public Guid ComepticaoId { get; set; }
    public Guid PartidaId { get; set; }
    public Guid TimeId { get; set; }
    public TipoEvento TipoEvento { get; set; }
    public Guid JogadorPrincipalId { get; set; }
    public Guid? JogadorSecundarioId { get; set; }
}