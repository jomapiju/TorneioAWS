using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarTransferencia;

public class AlterarTransferenciaDto : IResourceModel
{
    public Guid TransferenciaId { get; set; }
    public Guid JogadorId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataTransferencia { get; set; }
    public Guid TimeOrigemId { get; set; }
    public Guid TimeDestinoId { get; set; }
}