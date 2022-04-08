using TorneioAWS.Application.UseCases.Torneio.DeletarTime;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.DeletarTime;
public  class DeletarTimeUseCase : IDeletarTimeUseCase
{
    private readonly IRepository<Time> _timeRepository;
    private readonly IObterTimeEspecificacao _obterTimeEspecificacao;
    public DeletarTimeUseCase(IRepository<Time> timeRepository,
            IObterTimeEspecificacao obterTimeEspecificacao)
    {
        _obterTimeEspecificacao = obterTimeEspecificacao;
        _timeRepository = timeRepository;
    }

    public string Execute(Guid id)
    {
        Time time = _timeRepository.Get(_obterTimeEspecificacao.Execute(id));

        if (time == null)
            return null;
        
        _timeRepository.Remove(time);

        return "Sucesso";
    }
}