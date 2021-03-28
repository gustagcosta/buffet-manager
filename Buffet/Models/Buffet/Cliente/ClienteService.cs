using System;
using System.Collections.Generic;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteService
    {
        public List<ClienteEntity> get()
        {
            var listaDeClientes = new List<ClienteEntity>();

            var c1 = new ClienteEntity();

            c1.Id = 1;
            c1.Nome = "Matheus";
            c1.DataNascimento = DateTime.Now;
            c1.Idade = 17;

            var c2 = new ClienteEntity();

            c2.Id = 2;
            c2.Nome = "Daniel";
            c2.DataNascimento = DateTime.Now;
            c2.Idade = 19;

            listaDeClientes.Add(c1);
            listaDeClientes.Add(c2);

            return listaDeClientes;
        }
    }
}