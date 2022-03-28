using TorneioAWS.Domain;

namespace TorneioAWS.Specification.Torneio.ObterTransferenciaEspecificacao;

public class ObterTransferenciaEspecificacaoConsulta : Specification<Transferencia>
{
    public ObterTransferenciaEspecificacaoConsulta(Guid guid)
        : base(c => c.TransferenciaId == guid)
    {

    }
}