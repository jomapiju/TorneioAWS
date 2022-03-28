using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirCompeticao;

public class SubstituirCompeticaoDto : IResourceModel
{
    public Guid CompeticaoId { get; set; }
    public string Nome { get; set; }
}