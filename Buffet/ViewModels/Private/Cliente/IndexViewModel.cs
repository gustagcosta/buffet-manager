using Buffet.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Private.Cliente
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoClienteEntity TipoCliente { get; set; }
        public string Email { get; set; }
        public EnderecoEntity Endereco { get; set; }
        public string Observacoes { get; set; }
        public List<ClienteEntity> Clientes { get; internal set; }
        public string mensagem { get; internal set; }
    }
}
