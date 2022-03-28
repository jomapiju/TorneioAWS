using TorneioAWS.Application.ResourceModel;
using TorneioAWS.Domain;

namespace TorneioAWS.Application.UseCases.Torneio.ObterTodosTimes;

public class ObterTodosTimesDto : IResourceModel
{
    public IEnumerable<Time> Times { get; set; }
}