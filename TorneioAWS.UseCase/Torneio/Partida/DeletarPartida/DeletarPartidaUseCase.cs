using TorneioAWS.Application.UseCases.Torneio.DeletarPartida;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.DeletarPartida;
public  class DeletarPartidaUseCase : IDeletarPartidaUseCase
{
    private readonly IRepository<Partida> _partidaRepository;
    private readonly IObterPartidaEspecificacao _obterPartidaEspecificacao;
    public DeletarPartidaUseCase(IRepository<Partida> partidaRepository,
            IObterPartidaEspecificacao obterPartidaEspecificacao)
    {
        _obterPartidaEspecificacao = obterPartidaEspecificacao;
        _partidaRepository = partidaRepository;
    }

    public string Execute(Guid id)
    {
        Partida partida = _partidaRepository.Get(_obterPartidaEspecificacao.Execute(id));

        if (partida == null)
            return null;
        
        _partidaRepository.Remove(partida);

        return "Sucesso";
    }
}