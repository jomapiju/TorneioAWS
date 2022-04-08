using TorneioAWS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneioAWS.Repository.Mapeamento;

public class EventoMap : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.ToTable("evento", "aws-projeto-final");

        builder.HasKey(t => new { t.EventoId });

        builder.HasOne(p => p.Competicao)
            .WithMany(b => b.Eventos)
            .HasForeignKey(p => p.EventoId);

        builder.HasOne(p => p.Partida)
            .WithMany(b => b.Eventos)
            .HasForeignKey(p => p.PartidaId);

        builder.HasOne(p => p.Time)
            .WithMany(b => b.Eventos)
            .HasForeignKey(p => p.TimeId);

        // builder.HasOne(p => p.JogadorPrincipal)
        //     .WithMany(b => b.Eventos)
        //     .HasForeignKey(p => p.JogadorPrincipalId);        
        
        // builder.HasOne(p => p.JogadorSecundario)
        //     .WithMany(b => b.Eventos)
        //     .HasForeignKey(p => p.JogadorSecundarioId);

        builder.Property(t => t.EventoId)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uniqueidentifier");
        
        builder.Property(t => t.ComepticaoId)
            .IsRequired()
            .HasColumnName("competicao")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.PartidaId)
            .IsRequired()
            .HasColumnName("partida")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.TimeId)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.TipoEvento)
            .IsRequired()
            .HasColumnName("tipo_evento")
            .HasColumnType("int");

        builder.Property(t => t.JogadorPrincipalId)
            .IsRequired()
            .HasColumnName("jogador_principal")
            .HasColumnType("uniqueidentifier");
        
        builder.Property(t => t.JogadorSecundarioId)
            .HasColumnName("jogador_secundario")
            .HasColumnType("uniqueidentifier");
    }
}