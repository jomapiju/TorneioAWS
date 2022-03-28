using TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SalvarCompeticao;

public  class SalvarCompeticaoUseCase : ISalvarCompeticaoUseCase
{
    private readonly IRepository<Competicao> _competicaoRepository;
    public SalvarCompeticaoUseCase(IRepository<Competicao> competicaoRepository)
    {
        _competicaoRepository = competicaoRepository;
    }

    public IResourceModel Execute(SalvarCompeticaoRequestDto competicaoRequest)
    {

        if (competicaoRequest == null)
            return null;

        if (string.IsNullOrEmpty(competicaoRequest.Nome) ) {
            return null;
        }

        Competicao competicao = new Competicao {
            CompeticaoId = new Guid(),
            Nome = competicaoRequest.Nome
        };
        
        _competicaoRepository.Add(competicao);

        return new SalvarCompeticaoDto {
            CompeticaoId = competicao.CompeticaoId,
            Nome = competicao.Nome
        };
    }
}