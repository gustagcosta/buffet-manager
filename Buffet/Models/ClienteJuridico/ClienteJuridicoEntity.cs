using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Cliente;

namespace Buffet.Models.ClienteJuridico
{
    public class ClienteJuridicoEntity
    {
        [Key] public int Id { get; set; }
        [Required] private ClienteEntity Cliente { get; set; }
        [Required] public string Cpf { get; set; }
        [Required] public DateTime DataNascimento { get; set; }
    }
}