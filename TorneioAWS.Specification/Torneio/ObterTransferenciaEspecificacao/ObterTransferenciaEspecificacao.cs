using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;
using TorneioAWS.Application.Specification;

namespace TorneioAWS.Specification.Torneio.ObterTransferenciaEspecificacao;

public class ObterTransferenciaEspecificacao : IObterTransferenciaEspecificacao
{
    public ISpecification<Transferencia> Execute(Guid guid)
    {
        return new ObterTransferenciaEspecificacaoConsulta(guid);
    }
}