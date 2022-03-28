using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirTime;

public class SubstituirTimeRequestDto : IResourceModel
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Localidade { get; set; }
}