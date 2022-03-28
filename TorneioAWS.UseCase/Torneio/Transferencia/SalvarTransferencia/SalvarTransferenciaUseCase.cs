using TorneioAWS.Application.UseCases.Torneio.SalvarTransferencia;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SalvarTransferencia;

public  class SalvarTransferenciaUseCase : ISalvarTransferenciaUseCase
{
    private readonly IRepository<Transferencia> _transferenciaRepository;
    public SalvarTransferenciaUseCase(IRepository<Transferencia> transferenciaRepository)
    {
        _transferenciaRepository = transferenciaRepository;
    }

    public IResourceModel Execute(SalvarTransferenciaRequestDto transferenciaRequest)
    {

        if (transferenciaRequest == null)
            return null;

        if (transferenciaRequest.JogadorId == null
        || transferenciaRequest.DataTransferencia == null
        || transferenciaRequest.Valor == null
        || transferenciaRequest.TimeOrigemId == null
        || transferenciaRequest.TimeDestinoId == null) {
            return null;
        }

        Transferencia transferencia = new Transferencia {
            TransferenciaId = new Guid(),
            JogadorId = transferenciaRequest.JogadorId,
            DataTransferencia = transferenciaRequest.DataTransferencia,
            Valor = transferenciaRequest.Valor,
            TimeOrigemId = transferenciaRequest.TimeOrigemId,
            TimeDestinoId = transferenciaRequest.TimeDestinoId
        };
        
        _transferenciaRepository.Add(transferencia);

        return new SalvarTransferenciaDto {
            TransferenciaId = transferencia.TransferenciaId,
            JogadorId = transferencia.JogadorId,
            DataTransferencia = transferencia.DataTransferencia,
            Valor = transferencia.Valor,
            TimeOrigemId = transferencia.TimeOrigemId,
            TimeDestinoId = transferencia.TimeDestinoId
        };
    }
}