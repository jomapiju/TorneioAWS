using TorneioAWS.Application.UseCases.Torneio.ObterJogador;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterJogador;
public  class ObterJogadorUseCase : IObterJogadorUseCase
{
    private readonly IRepository<Jogador> _jogadorRepository;
    private readonly IObterJogadorEspecificacao _obterJogadorEspecificacao;
    public ObterJogadorUseCase(IRepository<Jogador> jogadorRepository,
            IObterJogadorEspecificacao obterJogadorEspecificacao)
    {
        _obterJogadorEspecificacao = obterJogadorEspecificacao;
        _jogadorRepository = jogadorRepository;
    }

    public IResourceModel Execute(Guid id)
    {
        var jogador = _jogadorRepository.Get(_obterJogadorEspecificacao.Execute(id));

        if (jogador == null)
            return null;

        return new ObterJogadorDto {
            JogadorId = jogador.JogadorId,
            Nome = jogador.Nome,
            DataNascimento = jogador.DataNascimento,
            Pais = jogador.Pais,
            Time = jogador.Time
        };
    }
}