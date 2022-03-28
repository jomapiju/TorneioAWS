using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosPartidas;

public class ObterTodosPartidasDto : IResourceModel
{
    public IEnumerable<Partida> Partidas { get; set; }
}