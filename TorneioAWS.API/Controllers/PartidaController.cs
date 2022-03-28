using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosPartidas;
using TorneioAWS.Application.UseCases.Torneio.ObterPartida;
using TorneioAWS.Application.UseCases.Torneio.SalvarPartida;
using TorneioAWS.Application.UseCases.Torneio.SubstituirPartida;
using TorneioAWS.Application.UseCases.Torneio.AlterarPartida;
using TorneioAWS.Application.UseCases.Torneio.DeletarPartida;

using TorneioAWS.Domain;

namespace TorneioAWS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PartidaController : ControllerBase
{
    private readonly IObterTodosPartidasUseCase _obterTodosPartidasUseCase;
    private readonly IObterPartidaUseCase _obterPartidaUseCase;
    private readonly ISalvarPartidaUseCase _salvarPartidaUseCase;
    private readonly ISubstituirPartidaUseCase _substituirPartidaUseCase;
    private readonly IAlterarPartidaUseCase _alterarPartidaUseCase;
    private readonly IDeletarPartidaUseCase _deletarPartidaUseCase;
    private readonly ILogger<PartidaController> _logger;

    public PartidaController(
        IObterTodosPartidasUseCase obterTodosPartidasUseCase,
        IObterPartidaUseCase obterPartidaUseCase, 
        ISalvarPartidaUseCase salvarPartidaUseCase,
        ISubstituirPartidaUseCase substituirPartidaUseCase,
        IAlterarPartidaUseCase alterarPartidaUseCase,
        IDeletarPartidaUseCase deletarPartidaUseCase,
        ILogger<PartidaController> logger)
    {
        _logger = logger;
        _obterTodosPartidasUseCase = obterTodosPartidasUseCase;
        _obterPartidaUseCase = obterPartidaUseCase;
        _salvarPartidaUseCase = salvarPartidaUseCase;
        _substituirPartidaUseCase = substituirPartidaUseCase;
        _alterarPartidaUseCase = alterarPartidaUseCase;
        _deletarPartidaUseCase = deletarPartidaUseCase;
    }

    [HttpGet("")]
    public ActionResult ObterTodosTime()
    {
        var time = _obterTodosPartidasUseCase.Execute();

        if (time == null)
            return NotFound();

        return Ok(time);
    }

    [HttpGet("{id}")]
    public ActionResult ObterPartida([FromRoute] Guid id)
    {
        var Partida = _obterPartidaUseCase.Execute(id);

        if (Partida == null)
            return NotFound();

        return Ok(Partida);
    }

    [HttpPost("")]
    public ActionResult SalvarPartida([FromBody] SalvarPartidaRequestDto novoPartida)
    {
        SalvarPartidaDto Partida = (SalvarPartidaDto) _salvarPartidaUseCase.Execute(novoPartida);

        if (Partida == null)
            return BadRequest();

        return CreatedAtAction(nameof(ObterPartida), new { id = Partida.PartidaId }, Partida);
    }

    [HttpPut("{id}")]
    public ActionResult SubstituirPartida([FromRoute] Guid id, [FromBody] SubstituirPartidaRequestDto PartidaAlterado)
    {
        var Partida = _substituirPartidaUseCase.Execute(id, PartidaAlterado);

        if (Partida == null)
            return BadRequest();

        return Ok(Partida);
    }

    [HttpPatch("{id}")]
    public ActionResult AlterarPropriedadePartida([FromRoute] Guid id, [FromBody] JsonPatchDocument<Partida> patchPartida)
    {
        var Partida = _alterarPartidaUseCase.Execute(id, patchPartida);

        if (Partida == null)
            return BadRequest();

        return Ok(Partida);
    }

    [HttpDelete("{id}")]
    public ActionResult DeletarPartida([FromRoute] Guid id)
    {
        var Partida = _deletarPartidaUseCase.Execute(id);

        if (Partida == null)
            return BadRequest();

        return Ok();
    }
}