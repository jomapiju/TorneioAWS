using Microsoft.Extensions.DependencyInjection;

namespace TorneioAWS.IoC;
public static class DependencyInjection
{
    public static void AddDI(this IServiceCollection services)
    {
        services.AddUseCase();
        services.AddRepository();
        services.AddSpecification();
    }
}