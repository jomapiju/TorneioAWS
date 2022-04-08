using TorneioAWS.Application.ResourceModel;
using System.ComponentModel.DataAnnotations;
using TorneioAWS.Domain.Enumeradores;

namespace TorneioAWS.Application.UseCases.Torneio.SalvarCompeticao;

public class SalvarEventoRequestDto : IResourceModel
{
    [Required]
    public Guid ComepticaoId { get; set; }
    [Required]
    public Guid PartidaId { get; set; }
    [Required]
    public Guid TimeId { get; set; }
    [Required]
    public TipoEvento Tipo { get; set; }
    public Guid? JogadorEventoId { get; set; }
    public Guid? NovoJogadorId { get; set; }
}