using TorneioAWS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneioAWS.Repository.Mapeamento;

public class JogadorMap : IEntityTypeConfiguration<Jogador>
{
    public void Configure(EntityTypeBuilder<Jogador> builder)
    {
        builder.ToTable("jogador", "aws-projeto-final");

        builder.HasKey(t => new { t.JogadorId });

        builder.HasOne(p => p.Time)
            .WithMany(b => b.Jogadores)
            .HasForeignKey(p => p.TimeId);

        builder.Property(t => t.JogadorId)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.DataNascimento)
            .HasColumnName("dataNascimento")
            .HasColumnType("datetime2");
        
        builder.Property(t => t.Pais)
            .HasColumnName("pais")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.TimeId)
            .IsRequired()
            .HasColumnName("timeId")
            .HasColumnType("uniqueidentifier");

        builder.HasMany(c => c.Transferencias)
            .WithOne(e => e.Jogador);

        builder.HasMany(c => c.Eventos)
            .WithOne(e => e.JogadorPrincipal);
    }
}