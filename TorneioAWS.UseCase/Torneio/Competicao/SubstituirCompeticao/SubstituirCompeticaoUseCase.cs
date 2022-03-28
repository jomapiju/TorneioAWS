using TorneioAWS.Application.UseCases.Torneio.SubstituirCompeticao;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SubstituirCompeticao;

public  class SubstituirCompeticaoUseCase : ISubstituirCompeticaoUseCase
{
    private readonly IRepository<Competicao> _competicaoRepository;
    private readonly IObterCompeticaoEspecificacao _obterCompeticaoEspecificacao;
    public SubstituirCompeticaoUseCase(IRepository<Competicao> competicaoRepository,
            IObterCompeticaoEspecificacao obterCompeticaoEspecificacao)
    {
        _competicaoRepository = competicaoRepository;
        _obterCompeticaoEspecificacao = obterCompeticaoEspecificacao;
    }

    public IResourceModel Execute(Guid id, SubstituirCompeticaoRequestDto competicaoRequest)
    {

        if (competicaoRequest == null)
            return null;


        if (string.IsNullOrEmpty(competicaoRequest.Nome) ) {
            return null;
        }
        
        Competicao competicao = _competicaoRepository.Get(_obterCompeticaoEspecificacao.Execute(id));

        if (competicao == null)
            return null;
        
        competicao.Nome = competicaoRequest.Nome;

        _competicaoRepository.Update(competicao);

        return new SubstituirCompeticaoDto {
            CompeticaoId = competicao.CompeticaoId,
            Nome = competicao.Nome
        };
    }
}