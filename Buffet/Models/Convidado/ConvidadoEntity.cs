using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.SituacaoConvidado;

namespace Buffet.Models.Convidado
{
    public class ConvidadoEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Nome { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Cpf { get; set; }
        [Required] public DateTime DataNascimento { get; set; }
        [Required] public EventoEntity Evento { get; set; }
        [Required] public SituacaoConvidadoEntity SituacaoConvidado { get; set; }
        [Required] public DateTime CriadoEm { get; set; }
        [Required] public DateTime EditadoEm { get; set; }
    }
}