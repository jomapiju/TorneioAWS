using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;
using TorneioAWS.Application.Specification;

namespace TorneioAWS.Specification.Torneio.ObterJogadorEspecificacao;

public class ObterJogadorEspecificacao : IObterJogadorEspecificacao
{
    public ISpecification<Jogador> Execute(Guid guid)
    {
        return new ObterJogadorEspecificacaoConsulta(guid);
    }
}