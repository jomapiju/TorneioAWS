using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;

public class SalvarCompeticaoDto : IResourceModel
{
    public Guid CompeticaoId { get; set; }
    public string Nome { get; set; }
}