using TorneioAWS.Domain.Comum;
using Newtonsoft.Json;

namespace TorneioAWS.Domain;

public class Transferencia  : IEntity
{
    public Guid TransferenciaId { get; set; }
    public Guid JogadorId { get; set; }
    public Jogador Jogador { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataTransferencia { get; set; }
    public Guid TimeOrigemId { get; set; }
    public Time TimeOrigem { get; set; }
    public Guid TimeDestinoId { get; set; }
    public Time TimeDestino { get; set; }
}