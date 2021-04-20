using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Buffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.ViewModels.Public;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Controllers
{
    public class PublicController : Controller
    {
        private readonly ILogger<PublicController> _logger;
        private readonly DatabaseContext _databaseContext;

        public PublicController(ILogger<PublicController> logger, DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.Error = (string) TempData["error"];
            lvm.Mensagem = (string) TempData["mensagem"];
            return View(lvm);
        }

        public IActionResult Policy()
        {
            ViewBag.Layout = "_LayoutPublic";
            return View();
        }

        public IActionResult Recovery()
        {
            return View();
        }

        public IActionResult Register()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.Error = (string) TempData["error"];
            rvm.Errors = (string[]) TempData["errors"];
            return View(rvm);
        }

        public IActionResult Terms()
        {
            ViewBag.Layout = "_LayoutPublic";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}