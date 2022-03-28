using TorneioAWS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneioAWS.Repository.Mapeamento;

public class CompeticaoMap : IEntityTypeConfiguration<Competicao>
{
    public void Configure(EntityTypeBuilder<Competicao> builder)
    {
        builder.ToTable("competicao", "aws-projeto-final");
        
        builder.HasKey(t => new { t.CompeticaoId });
        builder.Property(t => t.CompeticaoId)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(50)")
            .HasMaxLength(100);

        builder.HasMany(c => c.Partidas)
            .WithOne(e => e.Competicao);
    }
}