using TorneioAWS.Application.UseCases.Torneio.ObterTransferencia;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterTransferencia;
public  class ObterTransferenciaUseCase : IObterTransferenciaUseCase
{
    private readonly IRepository<Transferencia> _transferenciaRepository;
    private readonly IObterTransferenciaEspecificacao _obterTransferenciaEspecificacao;
    public ObterTransferenciaUseCase(IRepository<Transferencia> transferenciaRepository,
            IObterTransferenciaEspecificacao obterTransferenciaEspecificacao)
    {
        _obterTransferenciaEspecificacao = obterTransferenciaEspecificacao;
        _transferenciaRepository = transferenciaRepository;
    }

    public IResourceModel Execute(Guid id)
    {
        var transferencia = _transferenciaRepository.Get(_obterTransferenciaEspecificacao.Execute(id));

        if (transferencia == null)
            return null;

        return new ObterTransferenciaDto {
            TransferenciaId = transferencia.TransferenciaId,
            JogadorId = transferencia.JogadorId,
            DataTransferencia = transferencia.DataTransferencia,
            Valor = transferencia.Valor,
            TimeOrigemId = transferencia.TimeOrigemId,
            TimeDestinoId = transferencia.TimeDestinoId
        };
    }
}