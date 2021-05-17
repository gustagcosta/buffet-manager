using Buffet.Data;
using Buffet.Models.Cliente;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoEvento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buffet.Models.Evento
{
    public class EventoService
    {
        private readonly DatabaseContext _databaseContext;

        public EventoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<EventoEntity>> getAll()
        {
            return await _databaseContext.Eventos.ToListAsync();
        }

        public async Task store(string descricao, DateTime inicio, DateTime fim, ClienteEntity cliente, SituacaoEventoEntity situacao, string obs, TipoEventoEntity tipoEvento)
        {
            EventoEntity sce = new EventoEntity();
            sce.Descricao = descricao;
            sce.Inicio = inicio;
            sce.Fim = fim;
            sce.Cliente = cliente;
            sce.SituacaoEvento = situacao;
            sce.TipoEvento = tipoEvento;
            _databaseContext.Eventos.Add(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<EventoEntity> getById(int id)
        {
            return await _databaseContext.Eventos.FindAsync(id);
        }

        public async Task update(int id, string descricao)
        {
            EventoEntity sce = new EventoEntity();
            sce.Descricao = descricao;
            sce.Id = id;
            _databaseContext.Eventos.Update(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task destroy(int id)
        {
            EventoEntity sce = new EventoEntity();
            sce.Id = id;
            _databaseContext.Eventos.Remove(sce);
            await _databaseContext.SaveChangesAsync();
        }
    }
}