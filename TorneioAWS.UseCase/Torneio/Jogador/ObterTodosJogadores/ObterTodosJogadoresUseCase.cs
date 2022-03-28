using TorneioAWS.Application.UseCases.Torneio.ObterTodosJogadores;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterTodosJogadores;
public  class ObterTodosJogadoresUseCase : IObterTodosJogadoresUseCase
{
    private readonly IRepository<Jogador> _jogadorRepository;
    private readonly IObterJogadorEspecificacao _obterJogadorEspecificacao;
    public ObterTodosJogadoresUseCase(IRepository<Jogador> jogadorRepository,
            IObterJogadorEspecificacao obterJogadorEspecificacao)
    {
        _obterJogadorEspecificacao = obterJogadorEspecificacao;
        _jogadorRepository = jogadorRepository;
    }

    public IResourceModel Execute()
    {
        var jogadores = _jogadorRepository.List();

        if (jogadores == null)
            return null;

        return new ObterTodosJogadoresDto {
            Jogadores = jogadores
        };
    }
}