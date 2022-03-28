using TorneioAWS.Application.UseCases.Torneio.SubstituirTransferencia;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SubstituirTransferencia;

public  class SubstituirTransferenciaUseCase : ISubstituirTransferenciaUseCase
{
    private readonly IRepository<Transferencia> _transferenciaRepository;
    private readonly IObterTransferenciaEspecificacao _obterTransferenciaEspecificacao;
    public SubstituirTransferenciaUseCase(IRepository<Transferencia> transferenciaRepository,
            IObterTransferenciaEspecificacao obterTransferenciaEspecificacao)
    {
        _transferenciaRepository = transferenciaRepository;
        _obterTransferenciaEspecificacao = obterTransferenciaEspecificacao;
    }

    public IResourceModel Execute(Guid id, SubstituirTransferenciaRequestDto transferenciaRequest)
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
        
        Transferencia transferencia = _transferenciaRepository.Get(_obterTransferenciaEspecificacao.Execute(id));

        if (transferencia == null)
            return null;
        
        transferencia.JogadorId = transferenciaRequest.JogadorId;
        transferencia.DataTransferencia = transferenciaRequest.DataTransferencia;
        transferencia.Valor = transferenciaRequest.Valor;
        transferencia.TimeOrigemId = transferenciaRequest.TimeOrigemId;
        transferencia.TimeDestinoId = transferenciaRequest.TimeDestinoId;

        _transferenciaRepository.Update(transferencia);

        return new SubstituirTransferenciaDto {
            TransferenciaId = transferencia.TransferenciaId,
            JogadorId = transferencia.JogadorId,
            DataTransferencia = transferencia.DataTransferencia,
            Valor = transferencia.Valor,
            TimeOrigemId = transferencia.TimeOrigemId,
            TimeDestinoId = transferencia.TimeDestinoId
        };
    }
}