using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosCompeticoes;

public class ObterTodosCompeticoesDto : IResourceModel
{
    public IEnumerable<Competicao> Competicoes { get; set; }
}