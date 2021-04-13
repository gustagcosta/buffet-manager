using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Cliente;

namespace Buffet.Models.ClienteJuridico
{
    public class ClienteJuridicoEntity
    {
        [Key] public int Id;
        [Required] private ClienteEntity Cliente;
        [Required] public string Cpf { get; set; }
        [Required] public DateTime DataNascimento { get; set; }
    }
}