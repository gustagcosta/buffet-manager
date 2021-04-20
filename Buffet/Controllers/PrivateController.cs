using System.Diagnostics;
using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    public class PrivateController : Controller
    {
        private readonly ILogger<PrivateController> _logger;
        private readonly DatabaseContext _databaseContext;

        public PrivateController(ILogger<PrivateController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [Authorize]
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
            ViewBag.Layout = "_LayoutPrivate";
            return View("~/Views/Public/Policy.cshtml");
        }

        public IActionResult Terms()
        {
            ViewBag.Layout = "_LayoutPrivate";
            return View("~/Views/Public/Terms.cshtml");
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