using System.Diagnostics;
using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly DatabaseContext _databaseContext;

        public UserController(ILogger<UserController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Policy()
        {
            ViewBag.Layout = "_LayoutUser";
            return View("~/Views/Home/Policy.cshtml");
        }

        public IActionResult Terms()
        {
            ViewBag.Layout = "_LayoutUser";
            return View("~/Views/Home/Terms.cshtml");
        }

        public IActionResult Panel()
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