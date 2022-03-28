using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;
using TorneioAWS.Application.Specification;

namespace TorneioAWS.Specification.Torneio.ObterCompeticaoEspecificacao;

public class ObterCompeticaoEspecificacao : IObterCompeticaoEspecificacao
{
    public ISpecification<Competicao> Execute(Guid guid)
    {
        return new ObterCompeticaoEspecificacaoConsulta(guid);
    }
}