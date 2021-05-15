using System.Collections.Generic;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.SituacaoConvidado
{
    public class SituacaoConvidadoService
    {
        private readonly DatabaseContext _databaseContext;

        public SituacaoConvidadoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<SituacaoConvidadoEntity>> getAll()
        {
            return await _databaseContext.SituacoesConvidados.ToListAsync();
        }

        public async Task store(string descricao)
        {
            SituacaoConvidadoEntity sce = new SituacaoConvidadoEntity();
            sce.Descricao = descricao;
            _databaseContext.SituacoesConvidados.Add(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<SituacaoConvidadoEntity> getById(int id)
        {
            return await _databaseContext.SituacoesConvidados.FindAsync(id);
        }

        public async Task update(int id, string descricao)
        {
            SituacaoConvidadoEntity sce = new SituacaoConvidadoEntity();
            sce.Descricao = descricao;
            sce.Id = id;
            _databaseContext.SituacoesConvidados.Update(sce);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task destroy(int id)
        {
            SituacaoConvidadoEntity sce = new SituacaoConvidadoEntity();
            sce.Id = id;
            _databaseContext.SituacoesConvidados.Remove(sce);
            await _databaseContext.SaveChangesAsync();
        }
    }
}