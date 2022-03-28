using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirPartida;

public class SubstituirPartidaDto : IResourceModel
{
    public Guid PartidaId { get; set; }
    public Guid TimeCasaId { get; set; }
    public Guid TimeVisitanteId { get; set; }
    public Guid CompeticaoId { get; set; }
}