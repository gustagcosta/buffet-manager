using System;
using System.ComponentModel.DataAnnotations;
using Buffet.Models.Endereco;
using Buffet.Models.TipoCliente;

namespace Buffet.Models.Cliente
{
    public class ClienteEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Nome { get; set; }
        [Required] public TipoClienteEntity TipoCliente { get; set; }
        [Required] public string Email { get; set; }
        [Required] public EnderecoEntity Endereco { get; set; }
        [Required] public string Observacoes { get; set; }
        [Required] public DateTime CriadoEm { get; set; }
        [Required] public DateTime EditadoEm { get; set; }

        public ClienteEntity(string nome,  string email,  string observacoes, DateTime criadoEm)
        {
            Nome = nome;
            Email = email;
            Observacoes = observacoes;
            CriadoEm = criadoEm;
        }

        public ClienteEntity()
        {
        }
    }
}