using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarTime;

public class SalvarTimeDto : IResourceModel
{
    public Guid TimeId { get; set; }
    public string Nome { get; set; }
    public string Localidade { get; set; }
}