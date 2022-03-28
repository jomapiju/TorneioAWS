using TorneioAWS.Domain;

namespace TorneioAWS.Specification.Torneio.ObterCompeticaoEspecificacao;

public class ObterCompeticaoEspecificacaoConsulta : Specification<Competicao>
{
    public ObterCompeticaoEspecificacaoConsulta(Guid guid)
        : base(c => c.CompeticaoId == guid)
    {

    }
}