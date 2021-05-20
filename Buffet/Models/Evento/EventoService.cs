using Buffet.Data;
using Buffet.Models.Cliente;
using Buffet.Models.Local;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoEvento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task store(string descricao, TipoEventoEntity tipo, DateTime inicio, DateTime fim, ClienteEntity cliente, SituacaoEventoEntity situacao, 
                LocalEntity local, string obs, DateTime criadoEm)
        {
            EventoEntity sce = new EventoEntity();
            sce.Cliente = cliente;
            sce.CriadoEm = criadoEm;
            sce.Descricao = descricao;
            sce.Fim = fim;
            sce.Inicio = inicio;
            sce.Local = local;
            sce.SituacaoEvento = situacao;
            sce.TipoEvento = tipo;
            sce.Observacoes = obs;
            _databaseContext.Eventos.Add(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<EventoEntity> getById(int id)
        {
            return await _databaseContext.Eventos.FindAsync(id);
        }

        public List<EventoEntity> getEventosByCliente(int id)
        {
            var eventos = _databaseContext.Eventos.AsQueryable();

            eventos = eventos.Where(eventos => eventos.Cliente.Id == id);

            return eventos.ToList();
        }

        public async Task update(int id, string descricao, TipoEventoEntity tipo, DateTime inicio, DateTime fim, ClienteEntity cliente, 
            SituacaoEventoEntity situacao, LocalEntity local, string obs, DateTime editadoEm)
        {
            EventoEntity sce = await getById(id);
            sce.Descricao = descricao;
            sce.TipoEvento = tipo;
            sce.Inicio = inicio;
            sce.Fim = fim;
            sce.Cliente = cliente;
            sce.SituacaoEvento = situacao;
            sce.Local = local;
            sce.Observacoes = obs;
            sce.EditadoEm = editadoEm;
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

        public async Task<List<EventoEntity>> buscaEventos(string desc, DateTime inicio, DateTime fim)
        {

            var listaEventos = _databaseContext.Eventos.AsQueryable();

            if (desc != null)
            {
                listaEventos = listaEventos.Where(e => e.Descricao.Contains(desc));
            }
            
            if (inicio != DateTime.MinValue)
            {
                listaEventos = listaEventos.Where(c => c.Inicio >= (inicio));
            }
            
            if (fim != DateTime.MaxValue)
            {
                listaEventos = listaEventos.Where(c => c.Fim <= (fim));
            }
            
            await _databaseContext.SaveChangesAsync();
            
            return listaEventos.ToList();
        }

        public async Task<List<EventoEntity>> GetEventosByLocal(int id)
        {
            var eventos = _databaseContext.Eventos.Include( e => e.Local).ToList();
            return eventos.Where(e => e.Local.Id == id).ToList();
        }
        
        public List<EventoEntity> GetEventosByIdCliente(int id)
        {
            var eventos = _databaseContext.Eventos.Include( e => e.Cliente).ToList();
            return eventos.Where(e => e.Cliente.Id == id).ToList();
        }
    }
}