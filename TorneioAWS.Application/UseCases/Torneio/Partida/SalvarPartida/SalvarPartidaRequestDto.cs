using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarPartida;

public class SalvarPartidaRequestDto : IResourceModel
{
    [Required]
    public Guid TimeCasaId { get; set; }
    [Required]
    public Guid TimeVisitanteId { get; set; }
    [Required]
    public Guid CompeticaoId { get; set; }
}