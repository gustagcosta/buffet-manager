using System.Collections.Generic;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.TipoEvento
{
    public class TipoEventoService
    {
        private readonly DatabaseContext _databaseContext;
        
        public TipoEventoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<TipoEventoEntity>> getAll()
        {
            return await _databaseContext.TiposEventos.ToListAsync();
        }

        public async Task store(string descricao)
        {
            TipoEventoEntity sce = new TipoEventoEntity();
            sce.Descricao = descricao;
            _databaseContext.TiposEventos.Add(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<TipoEventoEntity> getById(int id)
        {
            return await _databaseContext.TiposEventos.FindAsync(id);
        }

        public async Task update(int id, string descricao)
        {
            TipoEventoEntity sce = new TipoEventoEntity();
            sce.Descricao = descricao;
            sce.Id = id;
            _databaseContext.TiposEventos.Update(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task destroy(int id)
        {
            TipoEventoEntity sce = new TipoEventoEntity();
            sce.Id = id;
            _databaseContext.TiposEventos.Remove(sce);
            await _databaseContext.SaveChangesAsync();
        }
    }
}