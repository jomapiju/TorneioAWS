using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Application.UseCases.Torneio.AlterarCompeticao;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.AlterarCompeticao;

public  class AlterarCompeticaoUseCase : IAlterarCompeticaoUseCase
{
    private readonly IRepository<Competicao> _competicaoRepository;
    private readonly IObterCompeticaoEspecificacao _obterCompeticaoEspecificacao;
    public AlterarCompeticaoUseCase(IRepository<Competicao> competicaoRepository,
            IObterCompeticaoEspecificacao obterCompeticaoEspecificacao)
    {
        _competicaoRepository = competicaoRepository;
        _obterCompeticaoEspecificacao = obterCompeticaoEspecificacao;
    }

    public IResourceModel Execute(Guid id, JsonPatchDocument<Competicao> competicaoPatch)
    {

        if (competicaoPatch == null)
            return null;

        Competicao competicao = _competicaoRepository.Get(_obterCompeticaoEspecificacao.Execute(id));

        if (competicao == null)
            return null;
        
        competicaoPatch.ApplyTo(competicao);

        _competicaoRepository.Update(competicao);

        return new AlterarCompeticaoDto {
            CompeticaoId = competicao.CompeticaoId,
            Nome = competicao.Nome
        };
    }
}