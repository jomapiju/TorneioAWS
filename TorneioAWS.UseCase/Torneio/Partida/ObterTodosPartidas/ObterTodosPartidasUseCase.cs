using TorneioAWS.Application.UseCases.Torneio.ObterTodosPartidas;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterTodosPartidas;
public  class ObterTodosPartidasUseCase : IObterTodosPartidasUseCase
{
    private readonly IRepository<Partida> _partidaRepository;
    private readonly IObterPartidaEspecificacao _obterPartidaEspecificacao;
    public ObterTodosPartidasUseCase(IRepository<Partida> partidaRepository,
            IObterPartidaEspecificacao obterPartidaEspecificacao)
    {
        _obterPartidaEspecificacao = obterPartidaEspecificacao;
        _partidaRepository = partidaRepository;
    }

    public IResourceModel Execute()
    {
        var partidas = _partidaRepository.List();

        if (partidas == null)
            return null;

        return new ObterTodosPartidasDto {
            Partidas = partidas
        };
    }
}