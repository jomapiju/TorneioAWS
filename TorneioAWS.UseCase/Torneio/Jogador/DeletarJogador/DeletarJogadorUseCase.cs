using TorneioAWS.Application.UseCases.Torneio.DeletarJogador;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.DeletarJogador;
public  class DeletarJogadorUseCase : IDeletarJogadorUseCase
{
    private readonly IRepository<Jogador> _jogadorRepository;
    private readonly IObterJogadorEspecificacao _obterJogadorEspecificacao;
    public DeletarJogadorUseCase(IRepository<Jogador> jogadorRepository,
            IObterJogadorEspecificacao obterJogadorEspecificacao)
    {
        _obterJogadorEspecificacao = obterJogadorEspecificacao;
        _jogadorRepository = jogadorRepository;
    }

    public IResourceModel Execute(Guid id)
    {
        Jogador jogador = _jogadorRepository.Get(_obterJogadorEspecificacao.Execute(id));

        if (jogador == null)
            return null;
        
        _jogadorRepository.Remove(jogador);

        return null;
    }
}