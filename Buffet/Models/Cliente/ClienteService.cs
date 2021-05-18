using Buffet.Data;
using Buffet.Models.Endereco;
using Buffet.Models.TipoCliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buffet.Models.Cliente
{
    public class ClienteService
    {
        private readonly DatabaseContext _databaseContext;

        public ClienteService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<ClienteEntity>> getAll()
        {
            return await _databaseContext.Clientes.ToListAsync();
        }

        public async Task store(string nomeCliente, string tipoCliente,
                                                string emailCliente, string enderecoRuaCliente, string enderecoBairroCliente, string enderecoEstadoCliente,
                                                string enderecoCidadeCliente, int enderecoNumCliente, string obsCliente, DateTime criadoEm)
        {
            EnderecoEntity endereco = new EnderecoEntity(enderecoEstadoCliente, enderecoCidadeCliente, enderecoBairroCliente, enderecoRuaCliente, enderecoNumCliente);
            TipoClienteEntity tipo = new TipoClienteEntity(tipoCliente);
            ClienteEntity ce = new ClienteEntity(nomeCliente, emailCliente, obsCliente, criadoEm);
            ce.TipoCliente = tipo;
            ce.Endereco = endereco;
            _databaseContext.Clientes.Add(ce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<ClienteEntity> getById(int id)
        {
            return await _databaseContext.Clientes.FindAsync(id);
        }

        //public async Task update(int id)
        //{
        //    ClienteEntity ce = new ClienteEntity();
        //    ce.Id = id;
        //    _databaseContext.Clientes.Update(ce);
        //    await _databaseContext.SaveChangesAsync();
        //}

        public async Task destroy(int id)
        {
            ClienteEntity ce = new ClienteEntity();
            ce.Id = id;
            _databaseContext.Clientes.Remove(ce);
            await _databaseContext.SaveChangesAsync();
        }
    }
}