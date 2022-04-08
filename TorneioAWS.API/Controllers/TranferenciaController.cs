using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using TorneioAWS.Application.UseCases.Torneio.ObterTransferencia;
using TorneioAWS.Application.UseCases.Torneio.ObterTodosTransferencias;
using TorneioAWS.Application.UseCases.Torneio.SalvarTransferencia;
using TorneioAWS.Application.UseCases.Torneio.SubstituirTransferencia;
using TorneioAWS.Application.UseCases.Torneio.AlterarTransferencia;
using TorneioAWS.Application.UseCases.Torneio.DeletarTransferencia;

using TorneioAWS.Domain;

namespace TorneioAWS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransferenciaController : ControllerBase
{
    private readonly IObterTransferenciaUseCase _obterTransferenciaUseCase;
    private readonly IObterTodosTransferenciasUseCase _obterTodosTransferenciasUseCase;
    private readonly ISalvarTransferenciaUseCase _salvarTransferenciaUseCase;
    private readonly ISubstituirTransferenciaUseCase _substituirTransferenciaUseCase;
    private readonly IAlterarTransferenciaUseCase _alterarTransferenciaUseCase;
    private readonly IDeletarTransferenciaUseCase _deletarTransferenciaUseCase;
    private readonly ILogger<TransferenciaController> _logger;

    public TransferenciaController(IObterTodosTransferenciasUseCase obterTodosTransferenciasUseCase,
        IObterTransferenciaUseCase obterTransferenciaUseCase, 
        ISalvarTransferenciaUseCase salvarTransferenciaUseCase,
        ISubstituirTransferenciaUseCase substituirTransferenciaUseCase,
        IAlterarTransferenciaUseCase alterarTransferenciaUseCase,
        IDeletarTransferenciaUseCase deletarTransferenciaUseCase,
        ILogger<TransferenciaController> logger)
    {
        _logger = logger;
        _obterTodosTransferenciasUseCase = obterTodosTransferenciasUseCase;
        _obterTransferenciaUseCase = obterTransferenciaUseCase;
        _salvarTransferenciaUseCase = salvarTransferenciaUseCase;
        _substituirTransferenciaUseCase = substituirTransferenciaUseCase;
        _alterarTransferenciaUseCase = alterarTransferenciaUseCase;
        _deletarTransferenciaUseCase = deletarTransferenciaUseCase;
    }

    [HttpGet("")]
    public ActionResult ObterTodosTransferencia()
    {
        var Transferencia = _obterTodosTransferenciasUseCase.Execute();

        if (Transferencia == null)
            return NotFound();

        return Ok(Transferencia);
    }

    [HttpGet("{id}")]
    public ActionResult ObterTransferencia([FromRoute] Guid id)
    {
        var Transferencia = _obterTransferenciaUseCase.Execute(id);

        if (Transferencia == null)
            return NotFound();

        return Ok(Transferencia);
    }

    [HttpPost("")]
    public ActionResult SalvarTransferencia([FromBody] SalvarTransferenciaRequestDto novoTransferencia)
    {
        SalvarTransferenciaDto Transferencia = (SalvarTransferenciaDto) _salvarTransferenciaUseCase.Execute(novoTransferencia);

        if (Transferencia == null)
            return BadRequest();

        return CreatedAtAction(nameof(ObterTransferencia), new { id = Transferencia.TransferenciaId }, Transferencia);
    }

    [HttpPut("{id}")]
    public ActionResult SubstituirTransferencia([FromRoute] Guid id, [FromBody] SubstituirTransferenciaRequestDto TransferenciaAlterado)
    {
        var Transferencia = _substituirTransferenciaUseCase.Execute(id, TransferenciaAlterado);

        if (Transferencia == null)
            return BadRequest();

        return Ok(Transferencia);
    }

    [HttpPatch("{id}")]
    public ActionResult AlterarPropriedadeTransferencia([FromRoute] Guid id, [FromBody] JsonPatchDocument<Transferencia> patchTransferencia)
    {
        var Transferencia = _alterarTransferenciaUseCase.Execute(id, patchTransferencia);

        if (Transferencia == null)
            return BadRequest();

        return Ok(Transferencia);
    }

    [HttpDelete("{id}")]
    public ActionResult DeletarTransferencia([FromRoute] Guid id)
    {
        var Transferencia = _deletarTransferenciaUseCase.Execute(id);

        if (Transferencia == null)
            return BadRequest();

        return Ok(Transferencia);
    }
}