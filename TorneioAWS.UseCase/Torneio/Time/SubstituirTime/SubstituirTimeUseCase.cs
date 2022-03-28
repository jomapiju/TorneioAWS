using TorneioAWS.Application.UseCases.Torneio.SubstituirTime;
using TorneioAWS.Domain;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Application.ResourceModel;

namespace TorneioAWS.UseCase.Torneio.SubstituirTime;

public  class SubstituirTimeUseCase : ISubstituirTimeUseCase
{
    private readonly IRepository<Time> _timeRepository;
    private readonly IObterTimeEspecificacao _obterTimeEspecificacao;
    public SubstituirTimeUseCase(IRepository<Time> timeRepository,
            IObterTimeEspecificacao obterTimeEspecificacao)
    {
        _timeRepository = timeRepository;
        _obterTimeEspecificacao = obterTimeEspecificacao;
    }

    public IResourceModel Execute(Guid id, SubstituirTimeRequestDto timeRequest)
    {

        if (timeRequest == null)
            return null;


        if (string.IsNullOrEmpty(timeRequest.Nome) || string.IsNullOrEmpty(timeRequest.Localidade)) {
            return null;
        }
        
        Time time = _timeRepository.Get(_obterTimeEspecificacao.Execute(id));

        if (time == null)
            return null;
        
        time.Nome = timeRequest.Nome;
        time.Localidade = timeRequest.Localidade;

        _timeRepository.Update(time);

        return new SubstituirTimeDto {
            TimeId = time.TimeId,
            Nome = time.Nome,
            Localidade = time.Localidade
        };
    }
}