using TorneioAWS.Application.UseCases.Torneio.SubstituirJogador;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SubstituirJogador;

public  class SubstituirJogadorUseCase : ISubstituirJogadorUseCase
{
    private readonly IRepository<Jogador> _jogadorRepository;
    private readonly IObterJogadorEspecificacao _obterJogadorEspecificacao;
    public SubstituirJogadorUseCase(IRepository<Jogador> jogadorRepository,
            IObterJogadorEspecificacao obterJogadorEspecificacao)
    {
        _jogadorRepository = jogadorRepository;
        _obterJogadorEspecificacao = obterJogadorEspecificacao;
    }

    public IResourceModel Execute(Guid id, SubstituirJogadorRequestDto jogadorRequest)
    {

        if (jogadorRequest == null)
            return null;


        if (string.IsNullOrEmpty(jogadorRequest.Nome) 
        || jogadorRequest.DataNascimento == null
        || string.IsNullOrEmpty(jogadorRequest.Pais)
        || jogadorRequest.TimeId == null) {
            return null;
        }
        
        Jogador jogador = _jogadorRepository.Get(_obterJogadorEspecificacao.Execute(id));

        if (jogador == null)
            return null;
        
        jogador.Nome = jogadorRequest.Nome;
        jogador.DataNascimento = jogadorRequest.DataNascimento;
        jogador.Pais = jogadorRequest.Pais;
        jogador.TimeId = jogadorRequest.TimeId;

        _jogadorRepository.Update(jogador);

        return new SubstituirJogadorDto {
            JogadorId = jogador.JogadorId,
            Nome = jogador.Nome,
            DataNascimento = jogador.DataNascimento,
            Pais = jogador.Pais,
            TimeId = jogador.TimeId
        };
    }
}