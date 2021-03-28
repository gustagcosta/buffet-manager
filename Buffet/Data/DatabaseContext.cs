using Buffet.Models.Buffet.Cliente;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ClienteEntity> Clientes { get; set; }
    }
}