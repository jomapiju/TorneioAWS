using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Application.UseCases.Torneio.AlterarJogador;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.AlterarJogador;

public  class AlterarJogadorUseCase : IAlterarJogadorUseCase
{
    private readonly IRepository<Jogador> _jogadorRepository;
    private readonly IObterJogadorEspecificacao _obterJogadorEspecificacao;
    public AlterarJogadorUseCase(IRepository<Jogador> jogadorRepository,
            IObterJogadorEspecificacao obterJogadorEspecificacao)
    {
        _jogadorRepository = jogadorRepository;
        _obterJogadorEspecificacao = obterJogadorEspecificacao;
    }

    public IResourceModel Execute(Guid id, JsonPatchDocument<Jogador> jogadorPatch)
    {

        if (jogadorPatch == null)
            return null;

        Jogador jogador = _jogadorRepository.Get(_obterJogadorEspecificacao.Execute(id));

        if (jogador == null)
            return null;
        
        jogadorPatch.ApplyTo(jogador);

        _jogadorRepository.Update(jogador);

        return new AlterarJogadorDto {
            JogadorId = jogador.JogadorId,
            Nome = jogador.Nome,
            DataNascimento = jogador.DataNascimento,
            Pais = jogador.Pais,
            TimeId = jogador.TimeId
        };
    }
}