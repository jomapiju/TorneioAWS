using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarTime;

public class SalvarTimeRequestDto : IResourceModel
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Localidade { get; set; }
}