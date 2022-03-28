using Microsoft.EntityFrameworkCore;
using TorneioAWS.Domain;
using TorneioAWS.Repository.Mapeamento;

namespace TorneioAWS.Repository.Comum.Contextos;

public class TorneioContext : DbContext
{
    public TorneioContext(DbContextOptions<TorneioContext> options) : base(options) { }

    public virtual DbSet<Time> Times { get; set; }
    public virtual DbSet<Jogador> Jogadores { get; set; }
    public virtual DbSet<Partida> Partidas { get; set; }
    public virtual DbSet<Competicao> Competicoes { get; set; }
    public virtual DbSet<Transferencia> Transferencias { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.HasDefaultSchema("prev");

        modelBuilder.ApplyConfiguration(new TimeMap());
        modelBuilder.ApplyConfiguration(new JogadorMap());
        modelBuilder.ApplyConfiguration(new PartidaMap());
        modelBuilder.ApplyConfiguration(new CompeticaoMap());
        modelBuilder.ApplyConfiguration(new TransferenciaMap());
    }
}