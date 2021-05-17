using System.Diagnostics;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Migrations;
using Buffet.Models;
using Buffet.Models.SituacaoConvidado;
using Buffet.Models.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    public class PrivateController : Controller
    {
        private readonly ILogger<PrivateController> _logger;
        private readonly UsuarioService _usuarioService;

        public PrivateController(ILogger<PrivateController> logger, DatabaseContext databaseContext, UsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Help()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Policy()
        {
            ViewBag.Layout = "_LayoutPrivate";
            return View("~/Views/Public/Policy.cshtml");
        }

        [Authorize]
        public IActionResult Terms()
        {
            ViewBag.Layout = "_LayoutPrivate";
            return View("~/Views/Public/Terms.cshtml");
        }
        
        [Authorize]
        public async Task<IActionResult> Panel()
        {
            var acessos = await _usuarioService.getAcessos(HttpContext.User);
            ViewBag.acessos = acessos;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _usuarioService.DeslogarUsuario();
            return Redirect("/Public/Login");
        }
        
        [Authorize]
        public IActionResult Config()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Evento()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Local()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Cliente()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}