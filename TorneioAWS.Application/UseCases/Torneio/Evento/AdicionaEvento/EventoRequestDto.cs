using TorneioAWS.Domain.Enumeradores;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AdicionaEvento;

public class EventoRequestDto : IResourceModel
{
    public Guid ComepticaoId { get; set; }
    public Guid PartidaId { get; set; }
    public Guid TimeId { get; set; }
    public TipoEvento TipoEvento { get; set; }

}