using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosCompeticoes;
using TorneioAWS.Application.UseCases.Torneio.ObterCompeticao;
using TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;
using TorneioAWS.Application.UseCases.Torneio.SubstituirCompeticao;
using TorneioAWS.Application.UseCases.Torneio.AlterarCompeticao;
using TorneioAWS.Application.UseCases.Torneio.DeletarCompeticao;

using TorneioAWS.Domain;

namespace TorneioAWS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CompeticaoController : ControllerBase
{
    private readonly IObterTodosCompeticoesUseCase _obterTodosCompeticoesUseCase;
    private readonly IObterCompeticaoUseCase _obterCompeticaoUseCase;
    private readonly ISalvarCompeticaoUseCase _salvarCompeticaoUseCase;
    private readonly ISubstituirCompeticaoUseCase _substituirCompeticaoUseCase;
    private readonly IAlterarCompeticaoUseCase _alterarCompeticaoUseCase;
    private readonly IDeletarCompeticaoUseCase _deletarCompeticaoUseCase;
    private readonly ILogger<CompeticaoController> _logger;

    public CompeticaoController(
        IObterTodosCompeticoesUseCase obterTodosCompeticoesUseCase,
        IObterCompeticaoUseCase obterCompeticaoUseCase, 
        ISalvarCompeticaoUseCase salvarCompeticaoUseCase,
        ISubstituirCompeticaoUseCase substituirCompeticaoUseCase,
        IAlterarCompeticaoUseCase alterarCompeticaoUseCase,
        IDeletarCompeticaoUseCase deletarCompeticaoUseCase,
        ILogger<CompeticaoController> logger)
    {
        _logger = logger;
        _obterTodosCompeticoesUseCase = obterTodosCompeticoesUseCase;
        _obterCompeticaoUseCase = obterCompeticaoUseCase;
        _salvarCompeticaoUseCase = salvarCompeticaoUseCase;
        _substituirCompeticaoUseCase = substituirCompeticaoUseCase;
        _alterarCompeticaoUseCase = alterarCompeticaoUseCase;
        _deletarCompeticaoUseCase = deletarCompeticaoUseCase;
    }

    [HttpGet("")]
    public ActionResult ObterTodosTime()
    {
        var time = _obterTodosCompeticoesUseCase.Execute();

        if (time == null)
            return NotFound();

        return Ok(time);
    }

    [HttpGet("{id}")]
    public ActionResult ObterCompeticao([FromRoute] Guid id)
    {
        var Competicao = _obterCompeticaoUseCase.Execute(id);

        if (Competicao == null)
            return NotFound();

        return Ok(Competicao);
    }

    [HttpPost("")]
    public ActionResult SalvarCompeticao([FromBody] SalvarCompeticaoRequestDto novoCompeticao)
    {
        SalvarCompeticaoDto Competicao = (SalvarCompeticaoDto) _salvarCompeticaoUseCase.Execute(novoCompeticao);

        if (Competicao == null)
            return BadRequest();

        return CreatedAtAction(nameof(ObterCompeticao), new { id = Competicao.CompeticaoId }, Competicao);
    }

    [HttpPut("{id}")]
    public ActionResult SubstituirCompeticao([FromRoute] Guid id, [FromBody] SubstituirCompeticaoRequestDto CompeticaoAlterado)
    {
        var Competicao = _substituirCompeticaoUseCase.Execute(id, CompeticaoAlterado);

        if (Competicao == null)
            return BadRequest();

        return Ok(Competicao);
    }

    [HttpPatch("{id}")]
    public ActionResult AlterarPropriedadeCompeticao([FromRoute] Guid id, [FromBody] JsonPatchDocument<Competicao> patchCompeticao)
    {
        var Competicao = _alterarCompeticaoUseCase.Execute(id, patchCompeticao);

        if (Competicao == null)
            return BadRequest();

        return Ok(Competicao);
    }

    [HttpDelete("{id}")]
    public ActionResult DeletarCompeticao([FromRoute] Guid id)
    {
        var Competicao = _deletarCompeticaoUseCase.Execute(id);

        if (Competicao == null)
            return BadRequest();

        return Ok(Competicao);
    }
}