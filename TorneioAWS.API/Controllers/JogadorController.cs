using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using StackExchange.Redis;
using Newtonsoft.Json;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosJogadores;
using TorneioAWS.Application.UseCases.Torneio.ObterJogador;
using TorneioAWS.Application.UseCases.Torneio.SalvarJogador;
using TorneioAWS.Application.UseCases.Torneio.SubstituirJogador;
using TorneioAWS.Application.UseCases.Torneio.AlterarJogador;
using TorneioAWS.Application.UseCases.Torneio.DeletarJogador;

using TorneioAWS.Domain;

namespace TorneioAWS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JogadorController : ControllerBase
{
    private readonly IObterTodosJogadoresUseCase _obterTodosJogadoresUseCase;
    private readonly IObterJogadorUseCase _obterJogadorUseCase;
    private readonly ISalvarJogadorUseCase _salvarJogadorUseCase;
    private readonly ISubstituirJogadorUseCase _substituirJogadorUseCase;
    private readonly IAlterarJogadorUseCase _alterarJogadorUseCase;
    private readonly IDeletarJogadorUseCase _deletarJogadorUseCase;
    private readonly ILogger<JogadorController> _logger;
    private readonly IConnectionMultiplexer _redis;

    public JogadorController(
        IObterTodosJogadoresUseCase obterTodosJogadoresUseCase,
        IObterJogadorUseCase obterJogadorUseCase, 
        ISalvarJogadorUseCase salvarJogadorUseCase,
        ISubstituirJogadorUseCase substituirJogadorUseCase,
        IAlterarJogadorUseCase alterarJogadorUseCase,
        IDeletarJogadorUseCase deletarJogadorUseCase,
        ILogger<JogadorController> logger,
        IConnectionMultiplexer redis)
    {
        _logger = logger;
        _obterTodosJogadoresUseCase = obterTodosJogadoresUseCase;
        _obterJogadorUseCase = obterJogadorUseCase;
        _salvarJogadorUseCase = salvarJogadorUseCase;
        _substituirJogadorUseCase = substituirJogadorUseCase;
        _alterarJogadorUseCase = alterarJogadorUseCase;
        _deletarJogadorUseCase = deletarJogadorUseCase;
        _redis = redis;
    }

    [HttpGet("")]
    public async Task<ActionResult> ObterTodosJogadores()
    {
        var jogadores = await GetJogadores<ObterTodosJogadoresDto>("Jogadores");
        

        if (jogadores == null) {
            jogadores = (ObterTodosJogadoresDto) _obterTodosJogadoresUseCase.Execute();
            await AddJogadores("Jogadores", jogadores);
        }

        if (jogadores == null)
            return NotFound();

        return Ok(jogadores);
    }

    [HttpGet("{id}")]
    public ActionResult ObterJogador([FromRoute] Guid id)
    {
        var Jogador = _obterJogadorUseCase.Execute(id);

        if (Jogador == null)
            return NotFound();

        return Ok(Jogador);
    }

    [HttpPost("")]
    public ActionResult SalvarJogador([FromBody] SalvarJogadorRequestDto novoJogador)
    {
        SalvarJogadorDto Jogador = (SalvarJogadorDto) _salvarJogadorUseCase.Execute(novoJogador);

        if (Jogador == null)
            return BadRequest();

        return CreatedAtAction(nameof(ObterJogador), new { id = Jogador.JogadorId }, Jogador);
    }

    [HttpPut("{id}")]
    public ActionResult SubstituirJogador([FromRoute] Guid id, [FromBody] SubstituirJogadorRequestDto JogadorAlterado)
    {
        var Jogador = _substituirJogadorUseCase.Execute(id, JogadorAlterado);

        if (Jogador == null)
            return BadRequest();

        return Ok(Jogador);
    }

    [HttpPatch("{id}")]
    public ActionResult AlterarPropriedadeJogador([FromRoute] Guid id, [FromBody] JsonPatchDocument<Jogador> patchJogador)
    {
        var Jogador = _alterarJogadorUseCase.Execute(id, patchJogador);

        if (Jogador == null)
            return BadRequest();

        return Ok(Jogador);
    }

    [HttpDelete("{id}")]
    public ActionResult DeletarJogador([FromRoute] Guid id)
    {
        var Jogador = _deletarJogadorUseCase.Execute(id);

        if (Jogador == null)
            return BadRequest();

        return Ok(Jogador);
    }

    private async Task AddJogadores(string key, object valor)
        => await _redis.GetDatabase().StringSetAsync(key, JsonConvert.SerializeObject(valor), TimeSpan.FromMinutes(10), When.NotExists)
        .ConfigureAwait(false);

    private async Task<T> GetJogadores<T>(string key) 
    {
        RedisValue rv = await _redis.GetDatabase().StringGetAsync(key).ConfigureAwait(false);
        if (!rv.HasValue)
            return default;
        T rgv = JsonConvert.DeserializeObject<T>(rv);
        return rgv;
    }
}