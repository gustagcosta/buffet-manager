using Buffet.Models;
using Buffet.Models.Cliente;
using Buffet.Models.ClienteFisico;
using Buffet.Models.ClienteJuridico;
using Buffet.Models.Convidado;
using Buffet.Models.Endereco;
using Buffet.Models.Local;
using Buffet.Models.SituacaoConvidado;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoCliente;
using Buffet.Models.TipoEvento;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<ClienteFisicoEntity> ClientesFisicos { get; set; }
        public DbSet<ClienteJuridicoEntity> ClientesJuridicos { get; set; }
        public DbSet<ConvidadoEntity> Convidados { get; set; }
        public DbSet<EnderecoEntity> Enderecos { get; set; }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<LocalEntity> Locais { get; set; }
        public DbSet<SituacaoConvidadoEntity> SituacoesConvidados { get; set; }
        public DbSet<SituacaoEventoEntity> SituacoesEventos { get; set; }
        public DbSet<TipoClienteEntity> TiposClientes { get; set; }
        public DbSet<TipoEventoEntity> TiposEventos {get; set; }
    }
}