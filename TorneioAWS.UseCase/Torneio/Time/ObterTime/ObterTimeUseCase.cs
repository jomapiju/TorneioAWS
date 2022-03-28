using TorneioAWS.Application.UseCases.Torneio.ObterTime;
using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Domain;

namespace TorneioAWS.UseCase.Torneio.ObterTime;
public  class ObterTimeUseCase : IObterTimeUseCase
{
    private readonly IRepository<Time> _timeRepository;
    private readonly IObterTimeEspecificacao _obterTimeEspecificacao;
    public ObterTimeUseCase(IRepository<Time> timeRepository,
            IObterTimeEspecificacao obterTimeEspecificacao)
    {
        _obterTimeEspecificacao = obterTimeEspecificacao;
        _timeRepository = timeRepository;
    }

    public IResourceModel Execute(Guid id)
    {
        var time = _timeRepository.Get(_obterTimeEspecificacao.Execute(id));

        if (time == null)
            return null;

        return new ObterTimeDto {
            TimeId = time.TimeId,
            Nome = time.Nome,
            Localidade = time.Localidade
        };
    }
}