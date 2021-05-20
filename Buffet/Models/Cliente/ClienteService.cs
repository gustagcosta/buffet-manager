using Buffet.Data;
using Buffet.Models.Endereco;
using Buffet.Models.TipoCliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            EnderecoEntity endereco = new EnderecoEntity();
            endereco.Cidade = enderecoCidadeCliente;
            endereco.Estado = enderecoEstadoCliente;
            endereco.Bairro= enderecoBairroCliente;
            endereco.Rua= enderecoRuaCliente;
            endereco.Numero= enderecoNumCliente;
            TipoClienteEntity tipo = new TipoClienteEntity(tipoCliente);
            ClienteEntity ce = new ClienteEntity(nomeCliente, emailCliente, obsCliente, criadoEm);
            ce.TipoCliente = tipo;
            ce.Endereco = endereco;
            await _databaseContext.Clientes.AddAsync(ce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<ClienteEntity> getById(int id)
        {
            var cliente = await _databaseContext.Clientes.FindAsync(id);
            var enderecos = await _databaseContext.Enderecos.ToListAsync();
            var eventos = await _databaseContext.Eventos.ToListAsync();
            foreach (var e in enderecos.Where(e => cliente.Endereco.Id == e.Id))
            {
                cliente.Endereco = e;
            }

            
            return cliente;
        }
        
        public  ClienteEntity getByIdToDestroy(int id)
        {
            ClienteEntity cliente = _databaseContext.Clientes.Find(id);
            return cliente;
        }

        public async Task update(int id, string nomeCliente, string tipoCliente,
                                                string emailCliente, string enderecoRuaCliente, string enderecoBairroCliente, string enderecoEstadoCliente,
                                                string enderecoCidadeCliente, int enderecoNumCliente, string obsCliente, DateTime editadoEm, List<EventoEntity> eventos)
        {
            ClienteEntity ce = await _databaseContext.Clientes.FindAsync(id);
            EnderecoEntity endereco = new EnderecoEntity();
            TipoClienteEntity tipo = new TipoClienteEntity();

            endereco.Bairro = enderecoBairroCliente;
            endereco.Rua = enderecoRuaCliente;
            endereco.Cidade = enderecoCidadeCliente;
            endereco.Estado = enderecoEstadoCliente;
            endereco.Numero = enderecoNumCliente;
            tipo.Descricao = tipoCliente;
            ce.TipoCliente = tipo;
            ce.Endereco = endereco;
            ce.EditadoEm = editadoEm;
            ce.Observacoes = obsCliente;
            ce.Nome = nomeCliente;
            ce.Eventos = eventos;
            
            _databaseContext.Clientes.Update(ce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task destroy(ClienteEntity ce)
        {
             _databaseContext.Clientes.Remove(ce);
            await _databaseContext.SaveChangesAsync();
        }
        
        public async Task<List<ClienteEntity>> buscaClientes(string nome, string email)
        {


            var listaClientes = _databaseContext.Clientes.AsQueryable();

            if(nome != null)
            {
                listaClientes = listaClientes.Where(c => c.Nome.Contains(nome));
            }
            if(email != null)
            {
                listaClientes = listaClientes.Where(c => c.Email.Contains(email));
            }


            await _databaseContext.SaveChangesAsync();
            return listaClientes.ToList();
        }
    }
}