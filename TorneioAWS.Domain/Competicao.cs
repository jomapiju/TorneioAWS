using TorneioAWS.Domain.Comum;
using Newtonsoft.Json;

namespace TorneioAWS.Domain;

public class Competicao : IEntity
{
    public Guid CompeticaoId { get; set; }
    public string Nome { get; set; }
    [JsonIgnore]
    public List<Partida> Partidas { get; set; }
    [JsonIgnore]
    public List<Evento> Eventos { get; set; }
}