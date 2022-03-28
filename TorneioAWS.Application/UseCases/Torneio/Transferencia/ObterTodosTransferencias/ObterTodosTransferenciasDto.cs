using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosTransferencias;

public class ObterTodosTransferenciasDto : IResourceModel
{
    public IEnumerable<Transferencia> Transferencias { get; set; }
}