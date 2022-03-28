using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace TorneioAWS.Repository.Comum.Contextos;
internal class TorneioContextBuilder : IDesignTimeDbContextFactory<TorneioContext>
{
    // public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

    public TorneioContext CreateDbContext(string[] args)
    {
        TorneioContext torneioContext = null;
        if (args.Length == 1)
        {
            var arg = string.IsNullOrEmpty(args[0]) ? args[0] : args[0].Trim();
            torneioContext = new TorneioContext(new DbContextOptionsBuilder<TorneioContext>()
                // .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseMySQL(arg).Options);
        }
        return torneioContext;
    }
}