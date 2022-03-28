using TorneioAWS.Application.UseCases.Torneio.ObterTodosTransferencias;
using TorneioAWS.Application.UseCases.Torneio.ObterTransferencia;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterTodosTransferencias;
public  class ObterTodosTransferenciasUseCase : IObterTodosTransferenciasUseCase
{
    private readonly IRepository<Transferencia> _transferenciaRepository;
    public ObterTodosTransferenciasUseCase(IRepository<Transferencia> transferenciaRepository)
    {
        _transferenciaRepository = transferenciaRepository;
    }

    public IResourceModel Execute()
    {
        var transferencias = _transferenciaRepository.List();

        if (transferencias == null)
            return null;

        return new ObterTodosTransferenciasDto {
            Transferencias = transferencias
        };
    }
}