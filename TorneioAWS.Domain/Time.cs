using TorneioAWS.Domain.Comum;
using Newtonsoft.Json;

namespace TorneioAWS.Domain;

public class Time : IEntity
{
    public Guid TimeId { get; set; }
    public string Nome { get; set; }
    public string Localidade { get; set; }
    [JsonIgnore]
    public List<Jogador> Jogadores { get; set; }
}