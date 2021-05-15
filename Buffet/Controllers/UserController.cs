using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models.Usuario;
using Buffet.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class UserController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly DatabaseContext _databaseContext;

        public UserController(UsuarioService usuarioService, DatabaseContext databaseContext)
        {
            _usuarioService = usuarioService;
            _databaseContext = databaseContext;
        }

        public async Task<ActionResult> Login(UserRegisterRequest request)
        {
            if (request.email == null)
            {
                TempData["error"] = "Email não informado!";
                return Redirect("/Public/Login");
            }

            if (request.password == null)
            {
                TempData["error"] = "Senha não informada!";
                return Redirect("/Public/Login");
            }

            try
            {
                await _usuarioService.AutenticarUsuario(request.email, request.password);
                return Redirect("/Private/Index");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return Redirect("/Public/Login");
            }
        }

        public async Task<ActionResult> Register(UserRegisterRequest request)
        {
            if (request.email == null)
            {
                TempData["error"] = "Email não informado!";
                return Redirect("/Public/Register");
            }

            if (request.password == null)
            {
                TempData["error"] = "Senha não informada!";
                return Redirect("/Public/Register");
            }

            if (request.password != request.passwordConfirm)
            {
                TempData["error"] = "Senhas não coincidem!";
                return Redirect("/Public/Register");
            }

            try
            {
                await _usuarioService.RegistrarUsuario(request.email, request.password);
                TempData["mensagem"] = "Cadastrado com sucesso!";
                return Redirect("/Public/Login");
            }
            catch (CadastrarUsuarioException e)
            {
                TempData["errors"] = e.Erros;
                return Redirect("/Public/Register");
            }
        }

        public async Task<ActionResult> UpdateUser(UserRegisterRequest request)
        {
            // Pegar o usuário pelo ID do usuário logado 
            // Fazer verificações
            // Mudar os atributos
            // Salve
            return Redirect("Private/Index");
        }
    }
}