using TorneioAWS.Application.UseCases.Torneio.SalvarTime;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SalvarTime;

public  class SalvarTimeUseCase : ISalvarTimeUseCase
{
    private readonly IRepository<Time> _timeRepository;
    public SalvarTimeUseCase(IRepository<Time> timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public IResourceModel Execute(SalvarTimeRequestDto timeRequest)
    {

        if (timeRequest == null)
            return null;

        if (string.IsNullOrEmpty(timeRequest.Nome) || string.IsNullOrEmpty(timeRequest.Localidade)) {
            return null;
        }

        Time time = new Time {
            TimeId = new Guid(),
            Nome = timeRequest.Nome,
            Localidade = timeRequest.Localidade
        };
        
        _timeRepository.Add(time);

        return new SalvarTimeDto {
            TimeId = time.TimeId,
            Nome = time.Nome,
            Localidade = time.Localidade
        };
    }
}