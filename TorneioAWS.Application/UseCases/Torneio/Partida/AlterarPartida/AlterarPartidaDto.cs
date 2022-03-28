using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarPartida;

public class AlterarPartidaDto : IResourceModel
{
    public Guid PartidaId { get; set; }
    public Guid TimeCasaId { get; set; }
    public Guid TimeVisitanteId { get; set; }
    public Guid CompeticaoId { get; set; }
}