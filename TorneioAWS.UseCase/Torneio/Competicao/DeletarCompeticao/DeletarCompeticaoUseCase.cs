using TorneioAWS.Application.UseCases.Torneio.DeletarCompeticao;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.DeletarCompeticao;
public  class DeletarCompeticaoUseCase : IDeletarCompeticaoUseCase
{
    private readonly IRepository<Competicao> _competicaoRepository;
    private readonly IObterCompeticaoEspecificacao _obterCompeticaoEspecificacao;
    public DeletarCompeticaoUseCase(IRepository<Competicao> competicaoRepository,
            IObterCompeticaoEspecificacao obterCompeticaoEspecificacao)
    {
        _obterCompeticaoEspecificacao = obterCompeticaoEspecificacao;
        _competicaoRepository = competicaoRepository;
    }

    public IResourceModel Execute(Guid id)
    {
        Competicao competicao = _competicaoRepository.Get(_obterCompeticaoEspecificacao.Execute(id));

        if (competicao == null)
            return null;
        
        _competicaoRepository.Remove(competicao);

        return null;
    }
}