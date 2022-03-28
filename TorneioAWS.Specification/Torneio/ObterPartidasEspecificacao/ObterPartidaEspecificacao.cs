using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;
using TorneioAWS.Application.Specification;

namespace TorneioAWS.Specification.Torneio.ObterPartidaEspecificacao;

public class ObterPartidaEspecificacao : IObterPartidaEspecificacao
{
    public ISpecification<Partida> Execute(Guid guid)
    {
        return new ObterPartidaEspecificacaoConsulta(guid);
    }
}