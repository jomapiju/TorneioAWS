using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EasyNetQ;
using StackExchange.Redis;

namespace TorneioAWS.IoC;
public static class DependencyInjection
{
    public static void AddDI(this IServiceCollection services)
    {
        services.AddUseCase();
        services.AddRepository();
        services.AddSpecification();
        
        services.AddSingleton(RabbitHutch.CreateBus("host=localhost"));
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("127.0.0.1:6379,password=eYVX7EwVmmxKPCDmwMtyKVge8oLd2t81,connectTimeout=10000"));

    }
}