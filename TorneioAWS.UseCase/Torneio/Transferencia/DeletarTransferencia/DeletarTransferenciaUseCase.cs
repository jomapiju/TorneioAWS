using TorneioAWS.Application.UseCases.Torneio.DeletarTransferencia;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.DeletarTransferencia;
public  class DeletarTransferenciaUseCase : IDeletarTransferenciaUseCase
{
    private readonly IRepository<Transferencia> _transferenciaRepository;
    private readonly IObterTransferenciaEspecificacao _obterTransferenciaEspecificacao;
    public DeletarTransferenciaUseCase(IRepository<Transferencia> transferenciaRepository,
            IObterTransferenciaEspecificacao obterTransferenciaEspecificacao)
    {
        _obterTransferenciaEspecificacao = obterTransferenciaEspecificacao;
        _transferenciaRepository = transferenciaRepository;
    }

    public string Execute(Guid id)
    {
        Transferencia transferencia = _transferenciaRepository.Get(_obterTransferenciaEspecificacao.Execute(id));

        if (transferencia == null)
            return null;
        
        _transferenciaRepository.Remove(transferencia);

        return "Sucesso";
    }
}