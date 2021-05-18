using Buffet.Data;
using System.Threading.Tasks;

namespace Buffet.Models.TipoCliente
{
    public class TipoClienteService 
    {
        private readonly DatabaseContext _databaseContext;

        public TipoClienteService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public async Task<TipoClienteEntity> getById(int id)
        {
            return await _databaseContext.TiposClientes.FindAsync(id);
        }

    }
}