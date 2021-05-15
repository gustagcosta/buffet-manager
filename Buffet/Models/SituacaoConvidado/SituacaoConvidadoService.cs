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
    }
}