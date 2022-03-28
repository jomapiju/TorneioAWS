using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarCompeticao;

public class AlterarCompeticaoRequestDto : IResourceModel
{
    [Required]
    public string Nome { get; set; }
}