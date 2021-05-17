using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models.Acesso;
using Buffet.Models.Usuario;
using Buffet.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class UserController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly AcessoService _acessoService;

        public UserController(UsuarioService usuarioService, AcessoService acessoService)
        {
            _usuarioService = usuarioService;
            _acessoService = acessoService;
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
                await _acessoService.RegistrarLog(HttpContext.User);
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

        public async Task<ActionResult> UpdateUser(UserUpdateRequest request)
        {
            if (request.newPasswordConfirm != request.newPassword)
            {
                ViewBag.error = "Novas senhas não coincidem!";
                return View("~/Views/Private/Panel.cshtml");
            }

            try
            {
                await _usuarioService.UpdateUsuario(HttpContext.User, request.oldPassword, request.newPassword);
                ViewBag.mensagem = "Editado com sucesso!";
                return View("~/Views/Private/Panel.cshtml");
            }
            catch (UpdateUsuarioException e)
            {
                ViewBag.erros = e.Erros;
                return View("~/Views/Private/Panel.cshtml");
            }
        }
    }
}