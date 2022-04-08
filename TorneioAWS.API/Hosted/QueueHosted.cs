using EasyNetQ;
using TorneioAWS.Application.UseCases.Torneio.AdicionaEvento;
using TorneioAWS.Application.UseCases.Torneio.AdicionaEventoComJogador;
using TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;
using TorneioAWS.Domain.Enumeradores;

namespace TorneioAWS.Common.Hosted;

public class QueueHosted : BackgroundService
{
    private readonly ILogger<QueueHosted> _logger;
    private readonly IBus _bus;

    public IServiceProvider Services { get; }

    public QueueHosted(IServiceProvider services, ILogger<QueueHosted> logger,
        IBus bus

        )
    {
        _logger = logger;
        _bus = bus;
        Services = services;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _bus.PubSub.Subscribe<SalvarEventoRequestDto>("", HandleTextMessage);
    }

    async void HandleTextMessage(SalvarEventoRequestDto evento)
    {
        _logger.LogInformation("TipoEvento: {0}", evento.Tipo);
        if(evento.Tipo.Equals(TipoEvento.Gol) 
        || evento.Tipo.Equals(TipoEvento.Advertencia)) {
            _logger.LogInformation("Jogador do Evento: {0}", evento.JogadorEventoId);
            using (var scope = Services.CreateScope())
            {
                var _adicionaEventoComJogadorUseCase = 
                    scope.ServiceProvider
                        .GetRequiredService<IAdicionaEventoComJogadorUseCase>();
                _logger.LogInformation("scope com um jogador");
                await _adicionaEventoComJogadorUseCase.Execute(HidrataEventoComJogadorDto(evento));
            }
        } else if (evento.Tipo.Equals(TipoEvento.Substituicao)) {
            _logger.LogInformation("Entra: {0}", evento.JogadorEventoId);
            _logger.LogInformation("Sai: {0}", evento.NovoJogadorId);
            using (var scope = Services.CreateScope())
            {
                var _adicionaEventoComJogadorUseCase = 
                    scope.ServiceProvider
                        .GetRequiredService<IAdicionaEventoComJogadorUseCase>();
                        
                _logger.LogInformation("scope com jogadores");

                await _adicionaEventoComJogadorUseCase.Execute(HidrataEventoComJogadorDto(evento));
            }
        } else {
            //ChamarAddEvComJogador
            using (var scope = Services.CreateScope())
            {
                var _adicionaEventoUseCase = 
                    scope.ServiceProvider
                        .GetRequiredService<IAdicionaEventoUseCase>();

                _logger.LogInformation("scope sem jogador");
                await _adicionaEventoUseCase.Execute(HidrataEventoDto(evento));
            }
        }
    }

    private EventoRequestDto HidrataEventoDto(SalvarEventoRequestDto controllerDto) {
        EventoRequestDto dto = new EventoRequestDto(){
            ComepticaoId = controllerDto.ComepticaoId,
            PartidaId = controllerDto.PartidaId,
            TimeId = controllerDto.TimeId,
            TipoEvento = controllerDto.Tipo
        };
        return dto;
    }
    private EventoComJogadorRequestDto HidrataEventoComJogadorDto(SalvarEventoRequestDto controllerDto) {
        EventoComJogadorRequestDto dto = new EventoComJogadorRequestDto(){
            ComepticaoId = controllerDto.ComepticaoId,
            PartidaId = controllerDto.PartidaId,
            TimeId = controllerDto.TimeId,
            TipoEvento = controllerDto.Tipo,
            JogadorPrincipalId = (Guid)controllerDto.JogadorEventoId,
            JogadorSecundarioId = controllerDto.NovoJogadorId
        };
        return dto;
    }

}