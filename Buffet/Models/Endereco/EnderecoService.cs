using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.Endereco
{
    public class EnderecoService
    {
        private readonly DatabaseContext _databaseContext;

        public EnderecoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<EnderecoEntity> getById(int id)
        {
            return await _databaseContext.Enderecos.FindAsync(id);
        }
    }
}