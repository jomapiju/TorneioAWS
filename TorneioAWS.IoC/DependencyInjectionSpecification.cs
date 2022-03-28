using Microsoft.Extensions.DependencyInjection;
using TorneioAWS.Application.Specification.Torneio;
using TorneioAWS.Specification.Torneio.ObterTimeEspecificacao;
using TorneioAWS.Specification.Torneio.ObterJogadorEspecificacao;
using TorneioAWS.Specification.Torneio.ObterCompeticaoEspecificacao;
using TorneioAWS.Specification.Torneio.ObterPartidaEspecificacao;
using TorneioAWS.Specification.Torneio.ObterTransferenciaEspecificacao;

namespace TorneioAWS.IoC;

internal static class DependencyInjectionSpecification
{
    public static void AddSpecification(this IServiceCollection services)
    {
        services.AddScoped<IObterTimeEspecificacao, ObterTimeEspecificacao>();
        services.AddScoped<IObterJogadorEspecificacao, ObterJogadorEspecificacao>();
        services.AddScoped<IObterPartidaEspecificacao, ObterPartidaEspecificacao>();
        services.AddScoped<IObterCompeticaoEspecificacao, ObterCompeticaoEspecificacao>();
        services.AddScoped<IObterTransferenciaEspecificacao, ObterTransferenciaEspecificacao>();
    }
}