using TorneioAWS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneioAWS.Repository.Mapeamento;

public class TransferenciaMap : IEntityTypeConfiguration<Transferencia>
{
    public void Configure(EntityTypeBuilder<Transferencia> builder)
    {
        builder.ToTable("transferencia", "aws-projeto-final");
        builder.HasKey(t => new { t.TransferenciaId });

        builder.HasOne(p => p.Jogador)
            .WithMany(b => b.Transferencias)
            .HasForeignKey(p => p.JogadorId);

        builder.Property(t => t.TransferenciaId)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.JogadorId)
            .IsRequired()
            .HasColumnName("jogador")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("decimal");

        builder.Property(t => t.DataTransferencia)
            .HasColumnName("data")
            .HasColumnType("datetime2");
        
        builder.Property(t => t.TimeOrigemId)
            .IsRequired()
            .HasColumnName("timeOrigem")
            .HasColumnType("uniqueidentifier");
        
        builder.Property(t => t.TimeDestinoId)
            .IsRequired()
            .HasColumnName("timeDestino")
            .HasColumnType("uniqueidentifier");
    }
}