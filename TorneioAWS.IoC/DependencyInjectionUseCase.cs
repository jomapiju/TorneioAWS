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

    }
}