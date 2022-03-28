using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using TorneioAWS.Application.UseCases.Torneio.ObterTime;
using TorneioAWS.Application.UseCases.Torneio.ObterTodosTimes;
using TorneioAWS.Application.UseCases.Torneio.SalvarTime;
using TorneioAWS.Application.UseCases.Torneio.SubstituirTime;
using TorneioAWS.Application.UseCases.Torneio.AlterarTime;
using TorneioAWS.Application.UseCases.Torneio.DeletarTime;

using TorneioAWS.Domain;

namespace TorneioAWS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeController : ControllerBase
{
    private readonly IObterTimeUseCase _obterTimeUseCase;
    private readonly IObterTodosTimesUseCase _obterTodosTimesUseCase;
    private readonly ISalvarTimeUseCase _salvarTimeUseCase;
    private readonly ISubstituirTimeUseCase _substituirTimeUseCase;
    private readonly IAlterarTimeUseCase _alterarTimeUseCase;
    private readonly IDeletarTimeUseCase _deletarTimeUseCase;
    private readonly ILogger<TimeController> _logger;

    public TimeController(IObterTodosTimesUseCase obterTodosTimesUseCase,
        IObterTimeUseCase obterTimeUseCase, 
        ISalvarTimeUseCase salvarTimeUseCase,
        ISubstituirTimeUseCase substituirTimeUseCase,
        IAlterarTimeUseCase alterarTimeUseCase,
        IDeletarTimeUseCase deletarTimeUseCase,
        ILogger<TimeController> logger)
    {
        _logger = logger;
        _obterTodosTimesUseCase = obterTodosTimesUseCase;
        _obterTimeUseCase = obterTimeUseCase;
        _salvarTimeUseCase = salvarTimeUseCase;
        _substituirTimeUseCase = substituirTimeUseCase;
        _alterarTimeUseCase = alterarTimeUseCase;
        _deletarTimeUseCase = deletarTimeUseCase;
    }

    [HttpGet("")]
    public ActionResult ObterTodosTime()
    {
        var time = _obterTodosTimesUseCase.Execute();

        if (time == null)
            return NotFound();

        return Ok(time);
    }

    [HttpGet("{id}")]
    public ActionResult ObterTime([FromRoute] Guid id)
    {
        var time = _obterTimeUseCase.Execute(id);

        if (time == null)
            return NotFound();

        return Ok(time);
    }

    [HttpPost("")]
    public ActionResult SalvarTime([FromBody] SalvarTimeRequestDto novoTime)
    {
        SalvarTimeDto time = (SalvarTimeDto) _salvarTimeUseCase.Execute(novoTime);

        if (time == null)
            return BadRequest();

        return CreatedAtAction(nameof(ObterTime), new { id = time.TimeId }, time);
    }

    [HttpPut("{id}")]
    public ActionResult SubstituirTime([FromRoute] Guid id, [FromBody] SubstituirTimeRequestDto timeAlterado)
    {
        var time = _substituirTimeUseCase.Execute(id, timeAlterado);

        if (time == null)
            return BadRequest();

        return Ok(time);
    }

    [HttpPatch("{id}")]
    public ActionResult AlterarPropriedadeTime([FromRoute] Guid id, [FromBody] JsonPatchDocument<Time> patchTime)
    {
        var time = _alterarTimeUseCase.Execute(id, patchTime);

        if (time == null)
            return BadRequest();

        return Ok(time);
    }

    [HttpDelete("{id}")]
    public ActionResult DeletarTime([FromRoute] Guid id)
    {
        var time = _deletarTimeUseCase.Execute(id);

        if (time == null)
            return BadRequest();

        return Ok();
    }
}