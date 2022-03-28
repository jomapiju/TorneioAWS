using TorneioAWS.Application.UseCases.Torneio.ObterCompeticao;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterCompeticao;
public  class ObterCompeticaoUseCase : IObterCompeticaoUseCase
{
    private readonly IRepository<Competicao> _competicaoRepository;
    private readonly IObterCompeticaoEspecificacao _obterCompeticaoEspecificacao;
    public ObterCompeticaoUseCase(IRepository<Competicao> competicaoRepository,
            IObterCompeticaoEspecificacao obterCompeticaoEspecificacao)
    {
        _obterCompeticaoEspecificacao = obterCompeticaoEspecificacao;
        _competicaoRepository = competicaoRepository;
    }

    public IResourceModel Execute(Guid id)
    {
        var competicao = _competicaoRepository.Get(_obterCompeticaoEspecificacao.Execute(id));

        if (competicao == null)
            return null;

        return new ObterCompeticaoDto {
            CompeticaoId = competicao.CompeticaoId,
            Nome = competicao.Nome
        };
    }
}