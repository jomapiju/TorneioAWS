using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;
using TorneioAWS.Application.Specification;

namespace TorneioAWS.Specification.Torneio.ObterTimeEspecificacao;

public class ObterTimeEspecificacao : IObterTimeEspecificacao
{
    public ISpecification<Time> Execute(Guid guid)
    {
        return new ObterTimeEspecificacaoConsulta(guid);
    }
}