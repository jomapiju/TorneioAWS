using TorneioAWS.Application.UseCases.Torneio.ObterTodosCompeticoes;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterTodosCompeticoes;
public  class ObterTodosCompeticoesUseCase : IObterTodosCompeticoesUseCase
{
    private readonly IRepository<Competicao> _competicaoRepository;
    private readonly IObterCompeticaoEspecificacao _obterCompeticaoEspecificacao;
    public ObterTodosCompeticoesUseCase(IRepository<Competicao> competicaoRepository,
            IObterCompeticaoEspecificacao obterCompeticaoEspecificacao)
    {
        _obterCompeticaoEspecificacao = obterCompeticaoEspecificacao;
        _competicaoRepository = competicaoRepository;
    }

    public IResourceModel Execute()
    {
        var competicoes = _competicaoRepository.List();

        if (competicoes == null)
            return null;

        return new ObterTodosCompeticoesDto {
            Competicoes = competicoes
        };
    }
}