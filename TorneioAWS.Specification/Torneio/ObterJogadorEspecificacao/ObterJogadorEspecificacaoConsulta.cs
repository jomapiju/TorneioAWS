using TorneioAWS.Domain;

namespace TorneioAWS.Specification.Torneio.ObterJogadorEspecificacao;

public class ObterJogadorEspecificacaoConsulta : Specification<Jogador>
{
    public ObterJogadorEspecificacaoConsulta(Guid guid)
        : base(c => c.JogadorId == guid)
    {

    }
}