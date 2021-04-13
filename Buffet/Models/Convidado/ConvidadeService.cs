using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.SituacaoConvidado;

namespace Buffet.Models.Convidado
{
    public class ConvidadeService
    {
        [Key] public int Id;
        [Required] public string Nome;
        [Required] public string Email;
        [Required] public string Cpf;
        [Required] public DateTime DataNascimento;
        [Required] public EventoEntity Evento;
        [Required] public SituacaoConvidadoEntity SituacaoConvidado;
        [Required] public DateTime CriadoEm;
        [Required] public DateTime EditadoEm;
    }
}