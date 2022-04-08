using Microsoft.Extensions.DependencyInjection;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosTimes;
using TorneioAWS.UseCase.Torneio.ObterTodosTimes;

using TorneioAWS.Application.UseCases.Torneio.ObterTime;
using TorneioAWS.UseCase.Torneio.ObterTime;

using TorneioAWS.Application.UseCases.Torneio.SalvarTime;
using TorneioAWS.UseCase.Torneio.SalvarTime;

using TorneioAWS.Application.UseCases.Torneio.SubstituirTime;
using TorneioAWS.UseCase.Torneio.SubstituirTime;

using TorneioAWS.Application.UseCases.Torneio.AlterarTime;
using TorneioAWS.UseCase.Torneio.AlterarTime;

using TorneioAWS.Application.UseCases.Torneio.DeletarTime;
using TorneioAWS.UseCase.Torneio.DeletarTime;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosJogadores;
using TorneioAWS.UseCase.Torneio.ObterTodosJogadores;

using TorneioAWS.Application.UseCases.Torneio.ObterJogador;
using TorneioAWS.UseCase.Torneio.ObterJogador;

using TorneioAWS.Application.UseCases.Torneio.SalvarJogador;
using TorneioAWS.UseCase.Torneio.SalvarJogador;

using TorneioAWS.Application.UseCases.Torneio.SubstituirJogador;
using TorneioAWS.UseCase.Torneio.SubstituirJogador;

using TorneioAWS.Application.UseCases.Torneio.AlterarJogador;
using TorneioAWS.UseCase.Torneio.AlterarJogador;

using TorneioAWS.Application.UseCases.Torneio.DeletarJogador;
using TorneioAWS.UseCase.Torneio.DeletarJogador;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosTransferencias;
using TorneioAWS.UseCase.Torneio.ObterTodosTransferencias;

using TorneioAWS.Application.UseCases.Torneio.ObterTransferencia;
using TorneioAWS.UseCase.Torneio.ObterTransferencia;

using TorneioAWS.Application.UseCases.Torneio.SalvarTransferencia;
using TorneioAWS.UseCase.Torneio.SalvarTransferencia;

using TorneioAWS.Application.UseCases.Torneio.SubstituirTransferencia;
using TorneioAWS.UseCase.Torneio.SubstituirTransferencia;

using TorneioAWS.Application.UseCases.Torneio.AlterarTransferencia;
using TorneioAWS.UseCase.Torneio.AlterarTransferencia;

using TorneioAWS.Application.UseCases.Torneio.DeletarTransferencia;
using TorneioAWS.UseCase.Torneio.DeletarTransferencia;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosCompeticoes;
using TorneioAWS.UseCase.Torneio.ObterTodosCompeticoes;

using TorneioAWS.Application.UseCases.Torneio.ObterCompeticao;
using TorneioAWS.UseCase.Torneio.ObterCompeticao;

using TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;
using TorneioAWS.UseCase.Torneio.SalvarCompeticao;

using TorneioAWS.Application.UseCases.Torneio.SubstituirCompeticao;
using TorneioAWS.UseCase.Torneio.SubstituirCompeticao;

using TorneioAWS.Application.UseCases.Torneio.AlterarCompeticao;
using TorneioAWS.UseCase.Torneio.AlterarCompeticao;

using TorneioAWS.Application.UseCases.Torneio.DeletarCompeticao;
using TorneioAWS.UseCase.Torneio.DeletarCompeticao;

using TorneioAWS.Application.UseCases.Torneio.ObterTodosPartidas;
using TorneioAWS.UseCase.Torneio.ObterTodosPartidas;

using TorneioAWS.Application.UseCases.Torneio.ObterPartida;
using TorneioAWS.UseCase.Torneio.ObterPartida;

using TorneioAWS.Application.UseCases.Torneio.SalvarPartida;
using TorneioAWS.UseCase.Torneio.SalvarPartida;

using TorneioAWS.Application.UseCases.Torneio.SubstituirPartida;
using TorneioAWS.UseCase.Torneio.SubstituirPartida;

using TorneioAWS.Application.UseCases.Torneio.AlterarPartida;
using TorneioAWS.UseCase.Torneio.AlterarPartida;

using TorneioAWS.Application.UseCases.Torneio.DeletarPartida;
using TorneioAWS.UseCase.Torneio.DeletarPartida;

using TorneioAWS.Application.UseCases.Torneio.AdicionaEvento;
using TorneioAWS.UseCase.AdicionaEvento;

using TorneioAWS.Application.UseCases.Torneio.AdicionaEventoComJogador;
using TorneioAWS.UseCase.AdicionaEventoComJogador;

namespace TorneioAWS.IoC;
internal static class DependencyInjectionUseCase
{
    public static void AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<IObterTodosTimesUseCase, ObterTodosTimesUseCase>();
        services.AddScoped<IObterTimeUseCase, ObterTimeUseCase>();
        services.AddScoped<ISalvarTimeUseCase, SalvarTimeUseCase>();
        services.AddScoped<ISubstituirTimeUseCase, SubstituirTimeUseCase>();
        services.AddScoped<IAlterarTimeUseCase, AlterarTimeUseCase>();
        services.AddScoped<IDeletarTimeUseCase, DeletarTimeUseCase>();

        services.AddScoped<IObterTodosJogadoresUseCase, ObterTodosJogadoresUseCase>();
        services.AddScoped<IObterJogadorUseCase, ObterJogadorUseCase>();
        services.AddScoped<ISalvarJogadorUseCase, SalvarJogadorUseCase>();
        services.AddScoped<ISubstituirJogadorUseCase, SubstituirJogadorUseCase>();
        services.AddScoped<IAlterarJogadorUseCase, AlterarJogadorUseCase>();
        services.AddScoped<IDeletarJogadorUseCase, DeletarJogadorUseCase>();

        services.AddScoped<IObterTodosTransferenciasUseCase, ObterTodosTransferenciasUseCase>();
        services.AddScoped<IObterTransferenciaUseCase, ObterTransferenciaUseCase>();
        services.AddScoped<ISalvarTransferenciaUseCase, SalvarTransferenciaUseCase>();
        services.AddScoped<ISubstituirTransferenciaUseCase, SubstituirTransferenciaUseCase>();
        services.AddScoped<IAlterarTransferenciaUseCase, AlterarTransferenciaUseCase>();
        services.AddScoped<IDeletarTransferenciaUseCase, DeletarTransferenciaUseCase>();

        services.AddScoped<IObterTodosCompeticoesUseCase, ObterTodosCompeticoesUseCase>();
        services.AddScoped<IObterCompeticaoUseCase, ObterCompeticaoUseCase>();
        services.AddScoped<ISalvarCompeticaoUseCase, SalvarCompeticaoUseCase>();
        services.AddScoped<ISubstituirCompeticaoUseCase, SubstituirCompeticaoUseCase>();
        services.AddScoped<IAlterarCompeticaoUseCase, AlterarCompeticaoUseCase>();
        services.AddScoped<IDeletarCompeticaoUseCase, DeletarCompeticaoUseCase>();
        
        services.AddScoped<IObterTodosPartidasUseCase, ObterTodosPartidasUseCase>();
        services.AddScoped<IObterPartidaUseCase, ObterPartidaUseCase>();
        services.AddScoped<ISalvarPartidaUseCase, SalvarPartidaUseCase>();
        services.AddScoped<ISubstituirPartidaUseCase, SubstituirPartidaUseCase>();
        services.AddScoped<IAlterarPartidaUseCase, AlterarPartidaUseCase>();
        services.AddScoped<IDeletarPartidaUseCase, DeletarPartidaUseCase>();

        services.AddScoped<IAdicionaEventoUseCase, AdicionaEventoUseCase>();
        services.AddScoped<IAdicionaEventoComJogadorUseCase, AdicionaEventoComJogadorUseCase>();
    }
}