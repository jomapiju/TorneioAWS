using TorneioAWS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneioAWS.Repository.Mapeamento;

public class TimeMap : IEntityTypeConfiguration<Time>
{
    public void Configure(EntityTypeBuilder<Time> builder)
    {
        builder.ToTable("time", "aws-projeto-final");

        builder.HasKey(t => new { t.TimeId });
        builder.Property(t => t.TimeId)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);
        
        builder.Property(t => t.Localidade)
            .HasColumnName("localidade")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.HasMany(c => c.Jogadores)
            .WithOne(e => e.Time);
    }
}