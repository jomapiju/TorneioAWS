using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarJogador;

public class AlterarJogadorRequestDto : IResourceModel
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public string Pais { get; set; }
    [Required]
    public Guid TimeId { get; set; }
}