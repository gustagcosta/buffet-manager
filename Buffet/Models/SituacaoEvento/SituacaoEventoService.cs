using System.Collections.Generic;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.SituacaoEvento
{
    public class SituacaoEventoService
    {
        private readonly DatabaseContext _databaseContext;

        public SituacaoEventoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<SituacaoEventoEntity>> getAll()
        {
            return await _databaseContext.SituacoesEventos.ToListAsync();
        }

        public async Task store(string descricao)
        {
            SituacaoEventoEntity sce = new SituacaoEventoEntity();
            sce.Descricao = descricao;
            _databaseContext.SituacoesEventos.Add(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<SituacaoEventoEntity> getById(int id)
        {
            return await _databaseContext.SituacoesEventos.FindAsync(id);
        }

        public async Task update(int id, string descricao)
        {
            SituacaoEventoEntity sce = new SituacaoEventoEntity();
            sce.Descricao = descricao;
            sce.Id = id;
            _databaseContext.SituacoesEventos.Update(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task destroy(int id)
        {
            SituacaoEventoEntity sce = new SituacaoEventoEntity();
            sce.Id = id;
            _databaseContext.SituacoesEventos.Remove(sce);
            await _databaseContext.SaveChangesAsync();
        }
    }
}