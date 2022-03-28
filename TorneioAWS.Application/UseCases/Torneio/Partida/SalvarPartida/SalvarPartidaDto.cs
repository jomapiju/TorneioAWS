using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarPartida;

public class SalvarPartidaDto : IResourceModel
{
    public Guid PartidaId { get; set; }
    public Guid TimeCasaId { get; set; }
    public Guid TimeVisitanteId { get; set; }
    public Guid CompeticaoId { get; set; }
}