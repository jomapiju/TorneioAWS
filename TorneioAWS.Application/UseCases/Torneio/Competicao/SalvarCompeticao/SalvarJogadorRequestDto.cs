using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;

public class SalvarCompeticaoRequestDto : IResourceModel
{
    [Required]
    public string Nome { get; set; }
}