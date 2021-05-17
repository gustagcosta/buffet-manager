using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models.Endereco;
using Buffet.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.Local
{
    public class LocalService
    {
        private readonly DatabaseContext _databaseContext;

        public LocalService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<LocalEntity>> GetAll()
        {
            return await _databaseContext.Locais.ToListAsync();
        }

        public async Task store(StoreEnderecoRequest request)
        {
            LocalEntity le = new LocalEntity();
            EnderecoEntity ee = new EnderecoEntity();
            le.Descricao = request.Descricao;
            ee.Bairro = request.Bairro;
            ee.Cidade = request.Cidade;
            ee.Estado = request.Estado;
            ee.Numero = request.Numero;
            ee.Rua = request.Rua;
            le.Endereco = ee;
            await _databaseContext.Locais.AddAsync(le);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task update(int requestId, StoreEnderecoRequest request)
        {
            var local = await _databaseContext.Locais.FindAsync(requestId);
            var endereco = new EnderecoEntity();
            local.Descricao = request.Descricao;
            endereco.Bairro = request.Bairro;
            endereco.Cidade = request.Cidade;
            endereco.Estado = request.Estado;
            endereco.Rua = request.Rua;
            endereco.Numero = request.Numero;
            local.Endereco = endereco;
            _databaseContext.Locais.Update(local);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<LocalEntity> GetById(int id)
        {
            var local = await _databaseContext.Locais.FindAsync(id);
            var enderecos = await _databaseContext.Enderecos.ToListAsync();
            foreach (var e in enderecos.Where(e => local.Endereco.Id == e.Id))
            {
                local.Endereco = e;
            }
            return local;
        }

        public async Task destroy(int id)
        {
            LocalEntity le = new LocalEntity();
            le.Id = id;
            _databaseContext.Locais.Remove(le);
            await _databaseContext.SaveChangesAsync();
        }
    }
}