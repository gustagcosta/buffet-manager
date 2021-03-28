using System;
using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        [Key] public int Id { get; set; }
        [Required] public String Nome { get; set; }
        [Required] public DateTime DataNascimento { get; set; }
        [Required] public int Idade { get; set; }
    }
}