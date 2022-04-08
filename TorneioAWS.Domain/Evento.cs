using TorneioAWS.Domain.Comum;
using Newtonsoft.Json;
using TorneioAWS.Domain.Enumeradores;

namespace TorneioAWS.Domain;

public class Evento : IEntity
{
    public Guid EventoId { get; set; }
    public Competicao? Competicao { get; set; }
    public Guid ComepticaoId { get; set; }
    public Partida? Partida { get; set; }
    public Guid PartidaId { get; set; }    
    public Time? Time { get; set; }
    public Guid TimeId { get; set; }
    public TipoEvento TipoEvento { get; set; }
    public Jogador? JogadorPrincipal { get; set; }
    public Guid? JogadorPrincipalId { get; set; }
    public Jogador? JogadorSecundario { get; set; }
    public Guid? JogadorSecundarioId { get; set; }

}