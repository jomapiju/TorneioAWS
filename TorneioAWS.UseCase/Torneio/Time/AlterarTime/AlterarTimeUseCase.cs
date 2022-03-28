using Microsoft.AspNetCore.JsonPatch;
using TorneioAWS.Application.UseCases.Torneio.AlterarTime;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.AlterarTime;

public  class AlterarTimeUseCase : IAlterarTimeUseCase
{
    private readonly IRepository<Time> _timeRepository;
    private readonly IObterTimeEspecificacao _obterTimeEspecificacao;
    public AlterarTimeUseCase(IRepository<Time> timeRepository,
            IObterTimeEspecificacao obterTimeEspecificacao)
    {
        _timeRepository = timeRepository;
        _obterTimeEspecificacao = obterTimeEspecificacao;
    }

    public IResourceModel Execute(Guid id, JsonPatchDocument<Time> timePatch)
    {

        if (timePatch == null)
            return null;

        Time time = _timeRepository.Get(_obterTimeEspecificacao.Execute(id));

        if (time == null)
            return null;
        
        timePatch.ApplyTo(time);

        _timeRepository.Update(time);

        return new AlterarTimeDto {
            TimeId = time.TimeId,
            Nome = time.Nome,
            Localidade = time.Localidade
        };
    }
}