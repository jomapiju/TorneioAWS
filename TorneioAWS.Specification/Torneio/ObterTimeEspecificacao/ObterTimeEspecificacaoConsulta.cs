using TorneioAWS.Domain;

namespace TorneioAWS.Specification.Torneio.ObterTimeEspecificacao;

public class ObterTimeEspecificacaoConsulta : Specification<Time>
{
    public ObterTimeEspecificacaoConsulta(Guid guid)
        : base(c => c.TimeId == guid)
    {

    }
}