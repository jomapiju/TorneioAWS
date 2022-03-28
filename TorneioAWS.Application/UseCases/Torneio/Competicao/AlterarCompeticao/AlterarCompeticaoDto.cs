using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.AlterarCompeticao;

public class AlterarCompeticaoDto : IResourceModel
{
    public Guid CompeticaoId { get; set; }
    public string Nome { get; set; }
}