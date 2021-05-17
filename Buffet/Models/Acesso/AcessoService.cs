using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.AspNetCore.Identity;
using Buffet.Models.Usuario;

namespace Buffet.Models.Acesso
{
    public class AcessoService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UsuarioService _usuarioService;

        public AcessoService(DatabaseContext databaseContext, UsuarioService usuarioService)
        { 
            _databaseContext = databaseContext;
            _usuarioService = usuarioService;
        }
        public async Task RegistrarLog(ClaimsPrincipal httpContextUser)
        {
            var acesso = new AcessoEntity
            {
                NomeUsuario = httpContextUser.Identity.Name, AcessadoEm = DateTime.Now
            };
            _databaseContext.Add(acesso);
            await _databaseContext.SaveChangesAsync();
        }
    }
}