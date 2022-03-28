using TorneioAWS.Application.UseCases.Torneio.SalvarJogador;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SalvarJogador;

public  class SalvarJogadorUseCase : ISalvarJogadorUseCase
{
    private readonly IRepository<Jogador> _jogadorRepository;
    public SalvarJogadorUseCase(IRepository<Jogador> jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }

    public IResourceModel Execute(SalvarJogadorRequestDto jogadorRequest)
    {

        if (jogadorRequest == null)
            return null;

        if (string.IsNullOrEmpty(jogadorRequest.Nome) 
        || jogadorRequest.DataNascimento == null
        || string.IsNullOrEmpty(jogadorRequest.Pais)
        || jogadorRequest.TimeId == null) {
            return null;
        }

        Jogador jogador = new Jogador {
            JogadorId = new Guid(),
            Nome = jogadorRequest.Nome,
            DataNascimento = jogadorRequest.DataNascimento,
            Pais = jogadorRequest.Pais,
            TimeId = jogadorRequest.TimeId
        };
        
        _jogadorRepository.Add(jogador);

        return new SalvarJogadorDto {
            JogadorId = jogador.JogadorId,
            Nome = jogador.Nome,
            DataNascimento = jogador.DataNascimento,
            Pais = jogador.Pais,
            TimeId = jogador.TimeId
        };
    }
}