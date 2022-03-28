namespace TorneioAWS.Repository.Comum.Contextos;

public static class TorneioContextFabric
{
    public static TorneioContext Create(string[] args)
    {
        return new TorneioContextBuilder().CreateDbContext(args);
    }
}