using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarTime;

public class AlterarTimeRequestDto : IResourceModel
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Localidade { get; set; }
}