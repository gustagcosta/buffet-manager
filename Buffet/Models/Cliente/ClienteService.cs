using Buffet.Data;
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

        public async Task store()
        {
           ClienteEntity ce = new ClienteEntity();
           
            _databaseContext.Clientes.Add(ce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<EventoEntity> getById(int id)
        {
            return await _databaseContext.Eventos.FindAsync(id);
        }

        // public async Task update(int id)
        // {
        //     ClienteEntity ce = new ClienteEntity();
        //     ce.Descricao = descricao;
        //     ce.Id = id;
        //     _databaseContext.Eventos.Update(sce);
        //     await _databaseContext.SaveChangesAsync();
        // }

        public async Task destroy(int id)
        {
            EventoEntity sce = new EventoEntity();
            sce.Id = id;
            _databaseContext.Eventos.Remove(sce);
            await _databaseContext.SaveChangesAsync();
        }
    }
}