using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTime;

public class ObterTimeDto : IResourceModel
{
    public Guid TimeId { get; set; }
    public string Nome { get; set; }
    public string Localidade { get; set; }
}