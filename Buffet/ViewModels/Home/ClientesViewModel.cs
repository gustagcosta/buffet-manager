using System.Collections.Generic;
using Buffet.Models.Buffet.Cliente;

namespace Buffet.ViewModels.Home
{
    public class ClientesViewModel
    {
        private string mensagem;
        private List<ClienteEntity> clientes;

        public string Mensagem
        {
            get => mensagem;
            set => mensagem = value;
        }

        public List<ClienteEntity> Clientes
        {
            get => clientes;
            set => clientes = value;
        }
    }
}