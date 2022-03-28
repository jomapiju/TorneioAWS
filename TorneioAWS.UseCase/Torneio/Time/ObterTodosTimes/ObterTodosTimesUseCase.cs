using TorneioAWS.Application.UseCases.Torneio.ObterTodosTimes;
using TorneioAWS.Application.UseCases.Torneio.ObterTime;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterTodosTimes;
public  class ObterTodosTimesUseCase : IObterTodosTimesUseCase
{
    private readonly IRepository<Time> _timeRepository;
    public ObterTodosTimesUseCase(IRepository<Time> timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public IResourceModel Execute()
    {
        var time = _timeRepository.List();

        if (time == null)
            return null;

        return new ObterTodosTimesDto {
            Times = time
        };
    }
}