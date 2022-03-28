using TorneioAWS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneioAWS.Repository.Mapeamento;

public class PartidaMap : IEntityTypeConfiguration<Partida>
{
    public void Configure(EntityTypeBuilder<Partida> builder)
    {
        builder.ToTable("partida", "aws-projeto-final");
        builder.HasKey(t => new { t.PartidaId });

        builder.HasOne(p => p.Competicao)
            .WithMany(b => b.Partidas)
            .HasForeignKey(p => p.CompeticaoId);

        
        builder.Property(t => t.PartidaId)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uniqueidentifier");

            
        builder.Property(t => t.TimeCasaId)
            .IsRequired()
            .HasColumnName("time_casa")
            .HasColumnType("uniqueidentifier");

            
        builder.Property(t => t.TimeVisitanteId)
            .IsRequired()
            .HasColumnName("time_visitante")
            .HasColumnType("uniqueidentifier");

            
        builder.Property(t => t.CompeticaoId)
            .IsRequired()
            .HasColumnName("competicao")
            .HasColumnType("uniqueidentifier");
    }
}