using System;
using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Acesso
{
    public class AcessoEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string NomeUsuario { get; set; }
        [Required] public DateTime AcessadoEm { get; set; }
    }
}