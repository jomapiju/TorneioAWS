using Microsoft.AspNetCore.Mvc;
using EasyNetQ;
using TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;
using TorneioAWS.Application.UseCases.Torneio.AdicionaEvento;

namespace TorneioAWS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private readonly IBus _bus;
    // private readonly IAdicionaEventoUseCase _adicionaEventoUseCase;
    // private readonly IAdicionaEventoComJogadorUseCase _adicionaEventoComJogadorUseCase;
    public EventoController(IBus bus
            // ,IAdicionaEventoUseCase adicionaEventoUseCase
        // ,IAdicionaEventoComJogadorUseCase adicionaEventoComJogadorUseCase
        )
    {
        _bus = bus;
        // _adicionaEventoUseCase = adicionaEventoUseCase;
        // _adicionaEventoComJogadorUseCase = adicionaEventoComJogadorUseCase;
    }

    // [HttpPost("direto")]
    // public ActionResult SalvarEventoDiretoDaPartida([FromBody] SalvarEventoRequestDto novoEvento)
    // {
    //     EventoRequestDto dto = new EventoRequestDto(){
    //         ComepticaoId = novoEvento.ComepticaoId,
    //         PartidaId = novoEvento.PartidaId,
    //         TimeId = novoEvento.TimeId,
    //         TipoEvento = novoEvento.Tipo
    //     };
    //     return Ok(_adicionaEventoUseCase.Execute(dto).Result);
    // }

    [HttpPost("")]
    public ActionResult SalvarEventoDaPartida([FromBody] SalvarEventoRequestDto novoEvento)
    {
        _bus.PubSub.Publish<SalvarEventoRequestDto>(novoEvento);
        return Ok();
    }
}