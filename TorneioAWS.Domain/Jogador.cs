using TorneioAWS.Domain.Comum;
using Newtonsoft.Json;

namespace TorneioAWS.Domain;

public class Jogador : IEntity
{
    public Guid JogadorId { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Pais { get; set; }
    public Time? Time { get; set; }
    public Guid TimeId { get; set; }
    [JsonIgnore]
    public List<Transferencia> Transferencias { get; set; }
    [JsonIgnore]
    public List<Evento> Eventos { get; set; }
}