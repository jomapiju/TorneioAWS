using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirTransferencia;

public class SubstituirTransferenciaDto : IResourceModel
{
    public Guid TransferenciaId { get; set; }
    public Guid JogadorId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataTransferencia { get; set; }
    public Guid TimeOrigemId { get; set; }
    public Guid TimeDestinoId { get; set; }
}