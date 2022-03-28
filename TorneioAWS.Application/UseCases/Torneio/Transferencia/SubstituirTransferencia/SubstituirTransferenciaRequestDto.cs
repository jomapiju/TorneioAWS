using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirTransferencia;

public class SubstituirTransferenciaRequestDto : IResourceModel
{
    [Required]
    public Guid JogadorId { get; set; }
    [Required]
    public decimal Valor { get; set; }
    [Required]
    public DateTime DataTransferencia { get; set; }
    [Required]
    public Guid TimeOrigemId { get; set; }
    [Required]
    public Guid TimeDestinoId { get; set; }
}