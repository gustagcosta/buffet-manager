using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models.Acesso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.Usuario
{
    public class UsuarioService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly DatabaseContext _databaseContext;

        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, DatabaseContext databaseContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _databaseContext = databaseContext;
        }

        public async Task AutenticarUsuario(string email, string senha)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, senha, false, false);

            if (!resultado.Succeeded)
            {
                throw new Exception("Usuário ou senha inválidos");
            }
        }
        
        public async Task DeslogarUsuario()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegistrarUsuario(string email, string senha)
        {
            var novoUsuario = new Usuario()
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(novoUsuario, senha);

            if (!resultado.Succeeded)
            {
                var listaErros = resultado.Errors.Select(error => error.Description).ToList();

                throw new CadastrarUsuarioException(listaErros);
            }
        }


        public async Task<Usuario> GetInfoUsuario(ClaimsPrincipal httpContextUser)
        {
            return await _userManager.GetUserAsync(httpContextUser);
        }

        public async Task UpdateUsuario(ClaimsPrincipal httpContextUser, string oldPassword, string newPassword)
        {
            var u = await _userManager.GetUserAsync(httpContextUser);

            var resultado = await _userManager.ChangePasswordAsync(u, oldPassword, newPassword);
            
            if (!resultado.Succeeded)
            {
                var listaErros = resultado.Errors.Select(error => error.Description).ToList();

                throw new UpdateUsuarioException(listaErros);
            }
        }

        public async Task<List<AcessoEntity>> getAcessos(ClaimsPrincipal httpContextUser)
        {
            var u = await _userManager.GetUserAsync(httpContextUser);
            var acessos = await _databaseContext.Acessos.ToListAsync();
            return acessos.Where(a => a.NomeUsuario == u.UserName).ToList();
        }
    }
}