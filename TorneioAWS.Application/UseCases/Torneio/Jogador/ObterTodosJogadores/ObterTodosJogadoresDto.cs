using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosJogadores;

public class ObterTodosJogadoresDto : IResourceModel
{
    public IEnumerable<Jogador> Jogadores { get; set; }
}