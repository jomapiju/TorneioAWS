using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirCompeticao;

public class SubstituirCompeticaoRequestDto : IResourceModel
{
    [Required]
    public string Nome { get; set; }
}