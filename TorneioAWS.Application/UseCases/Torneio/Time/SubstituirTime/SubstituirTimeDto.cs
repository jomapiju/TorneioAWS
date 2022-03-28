using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SubstituirTime;

public class SubstituirTimeDto : IResourceModel
{
    public Guid TimeId { get; set; }
    public string Nome { get; set; }
    public string Localidade { get; set; }
}