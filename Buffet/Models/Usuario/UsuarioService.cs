using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Usuario
{
    public class UsuarioService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task AutenticarUsuario(string email, string senha)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, senha, false, false);

            if (!resultado.Succeeded)
            {
                throw new Exception("Usuário ou senha inválidos");
            }
        }

        public async Task RegistrarUsuario(string email, string senha)
        {
            var NovoUsuario = new Usuario()
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(NovoUsuario, senha);

            if (!resultado.Succeeded)
            {
                var listaErros = new List<string>();

                foreach (var error in resultado.Errors)
                {
                    listaErros.Add(error.Description);
                }

                throw new CadastrarUsuarioException(listaErros);
            }
        }
    }
}