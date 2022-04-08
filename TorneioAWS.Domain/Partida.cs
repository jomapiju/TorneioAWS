using TorneioAWS.Domain.Comum;
using Newtonsoft.Json;

namespace TorneioAWS.Domain;

public class Partida : IEntity
{
    public Guid PartidaId { get; set; }
    public Guid TimeCasaId { get; set; }
    public Time TimeCasa { get; set; }
    public Guid TimeVisitanteId { get; set; }
    public Time TimeVisitante { get; set; }
    public Guid CompeticaoId { get; set; }
    public Competicao Competicao { get; set; }

    
    [JsonIgnore]
    public List<Evento> Eventos { get; set; }
}