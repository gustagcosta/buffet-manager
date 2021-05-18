using Buffet.Models.Cliente;
using Buffet.Models.Endereco;
using Buffet.Models.TipoCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Private.Cliente
{
    public class ClienteViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string tipoCliente { get; set; }
        public string email { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string obs { get; set; }
        public List<ClienteEntity> Clientes { get; internal set; }
        public string mensagem { get; internal set; }

        public ClienteViewModel(int id, string nome, string tipoCliente, string email, string estado, string cidade, string bairro, string rua, int numero, string obs)
        {
            this.id = id;
            this.nome = nome;
            this.tipoCliente = tipoCliente;
            this.email = email;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            this.obs = obs;
        }

        public ClienteViewModel()
        {
        }
    }
}
