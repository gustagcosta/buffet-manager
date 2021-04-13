using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Cliente;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoEvento;

namespace Buffet.Models
{
    public class EventoEntity
    {
        [Key] public int Id;
        [Required] public TipoEventoEntity TipoEvento;
        [Required] public string Descricao;
        [Required] public DateTime Inicio;
        [Required] public DateTime Fim;
        [Required] public ClienteEntity Cliente;
        [Required] public SituacaoEventoEntity SituacaoEvento;
        [Required] public string Observacoes;
        [Required] public DateTime CriadoEm;
        [Required] public DateTime EditadoEm;
    }
}