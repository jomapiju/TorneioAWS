using TorneioAWS.Domain;

namespace TorneioAWS.Specification.Torneio.ObterPartidaEspecificacao;

public class ObterPartidaEspecificacaoConsulta : Specification<Partida>
{
    public ObterPartidaEspecificacaoConsulta(Guid guid)
        : base(c => c.PartidaId == guid)
    {

    }
}