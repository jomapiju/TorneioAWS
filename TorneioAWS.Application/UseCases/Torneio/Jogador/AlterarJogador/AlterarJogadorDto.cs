using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarJogador;

public class AlterarJogadorDto : IResourceModel
{
    public Guid JogadorId { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Pais { get; set; }
    public Guid TimeId { get; set; }
}