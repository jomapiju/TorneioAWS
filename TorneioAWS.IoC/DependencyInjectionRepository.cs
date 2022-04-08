using Microsoft.Extensions.DependencyInjection;
using TorneioAWS.Application.Repository;
using TorneioAWS.Domain;
using TorneioAWS.Repository.Repositorios;

namespace TorneioAWS.IoC;

internal static class DependencyInjectionRepository
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Time>, TimeRepositorio>();
        services.AddScoped<IRepository<Jogador>, JogadorRepositorio>();
        services.AddScoped<IRepository<Competicao>, CompeticaoRepositorio>();
        services.AddScoped<IRepository<Partida>, PartidaRepositorio>();
        services.AddScoped<IRepository<Transferencia>, TransferenciaRepositorio>();
        services.AddScoped<IRepository<Evento>, EventoRepositorio>();
    }
}