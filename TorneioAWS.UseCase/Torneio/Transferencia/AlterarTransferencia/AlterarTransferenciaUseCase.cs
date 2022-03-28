using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Application.UseCases.Torneio.AlterarTransferencia;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.AlterarTransferencia;

public  class AlterarTransferenciaUseCase : IAlterarTransferenciaUseCase
{
    private readonly IRepository<Transferencia> _transferenciaRepository;
    private readonly IObterTransferenciaEspecificacao _obterTransferenciaEspecificacao;
    public AlterarTransferenciaUseCase(IRepository<Transferencia> transferenciaRepository,
            IObterTransferenciaEspecificacao obterTransferenciaEspecificacao)
    {
        _transferenciaRepository = transferenciaRepository;
        _obterTransferenciaEspecificacao = obterTransferenciaEspecificacao;
    }

    public IResourceModel Execute(Guid id, JsonPatchDocument<Transferencia> transferenciaPatch)
    {

        if (transferenciaPatch == null)
            return null;

        Transferencia transferencia = _transferenciaRepository.Get(_obterTransferenciaEspecificacao.Execute(id));

        if (transferencia == null)
            return null;
        
        transferenciaPatch.ApplyTo(transferencia);

        _transferenciaRepository.Update(transferencia);

        return new AlterarTransferenciaDto {
            TransferenciaId = transferencia.TransferenciaId,
            JogadorId = transferencia.JogadorId,
            DataTransferencia = transferencia.DataTransferencia,
            Valor = transferencia.Valor,
            TimeOrigemId = transferencia.TimeOrigemId,
            TimeDestinoId = transferencia.TimeDestinoId
        };
    }
}