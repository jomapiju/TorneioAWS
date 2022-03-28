using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.ObterCompeticao;

public class ObterCompeticaoDto : IResourceModel
{
    public Guid CompeticaoId { get; set; }
    public string Nome { get; set; }
}