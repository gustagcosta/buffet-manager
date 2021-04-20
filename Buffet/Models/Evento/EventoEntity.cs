using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Cliente;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoEvento;

namespace Buffet.Models
{
    public class EventoEntity
    {
        [Key] public int Id { get; set; }
        [Required] public TipoEventoEntity TipoEvento { get; set; }
        [Required] public string Descricao { get; set; }
        [Required] public DateTime Inicio { get; set; }
        [Required] public DateTime Fim { get; set; }
        [Required] public ClienteEntity Cliente { get; set; }
        [Required] public SituacaoEventoEntity SituacaoEvento { get; set; }
        [Required] public string Observacoes { get; set; }
        [Required] public DateTime CriadoEm { get; set; }
        [Required] public DateTime EditadoEm { get; set; }
    }
}