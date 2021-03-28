using System.Diagnostics;
using Buffet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class UserController : Controller
    {
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