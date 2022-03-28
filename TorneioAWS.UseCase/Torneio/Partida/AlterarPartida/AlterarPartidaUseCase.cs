using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Application.UseCases.Torneio.AlterarPartida;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.AlterarPartida;

public  class AlterarPartidaUseCase : IAlterarPartidaUseCase
{
    private readonly IRepository<Partida> _partidaRepository;
    private readonly IObterPartidaEspecificacao _obterPartidaEspecificacao;
    public AlterarPartidaUseCase(IRepository<Partida> partidaRepository,
            IObterPartidaEspecificacao obterPartidaEspecificacao)
    {
        _partidaRepository = partidaRepository;
        _obterPartidaEspecificacao = obterPartidaEspecificacao;
    }

    public IResourceModel Execute(Guid id, JsonPatchDocument<Partida> partidaPatch)
    {

        if (partidaPatch == null)
            return null;

        Partida partida = _partidaRepository.Get(_obterPartidaEspecificacao.Execute(id));

        if (partida == null)
            return null;
        
        partidaPatch.ApplyTo(partida);

        _partidaRepository.Update(partida);

        return new AlterarPartidaDto {
            PartidaId = partida.PartidaId,
            TimeCasaId = partida.TimeCasaId,
            TimeVisitanteId = partida.TimeVisitanteId,
            CompeticaoId = partida.CompeticaoId
        };
    }
}