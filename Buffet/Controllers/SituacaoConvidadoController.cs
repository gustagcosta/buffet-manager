using System.Diagnostics;
using System.Threading.Tasks;
using Buffet.Models;
using Buffet.Models.SituacaoConvidado;
using Buffet.RequestModels;
using Buffet.ViewModels.Private.SituacaoConvidado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    public class SituacaoConvidadoController : Controller
    {
        private readonly SituacaoConvidadoService _situacaoConvidadoService;
        private readonly ILogger<SituacaoConvidadoController> _logger;
        
        public SituacaoConvidadoController(SituacaoConvidadoService situacaoConvidadoService, ILogger<SituacaoConvidadoController> logger)
        {
            _situacaoConvidadoService = situacaoConvidadoService;
            _logger = logger;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var situacoes = await _situacaoConvidadoService.getAll();
            var scvm = new IndexViewModel();
            scvm.Situacoes = situacoes;
            return View("~/Views/Private/SituacaoConvidado/Index.cshtml", scvm);
        }
        
        public async Task<IActionResult> Store(ConfigRequestStore crs)
        {
            await _situacaoConvidadoService.store(crs.descricao);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit()
        {
            // var situacoes = await _situacaoConvidadoService.getAll();
            // var scvm = new IndexViewModel();
            // scvm.Situacoes = situacoes;
            return View("~/Views/Private/SituacaoConvidado/Index.cshtml");
        }
        
        public async Task<IActionResult> Destroy()
        {
            // var situacoes = await _situacaoConvidadoService.getAll();
            // var scvm = new IndexViewModel();
            // scvm.Situacoes = situacoes;
            return View("~/Views/Private/SituacaoConvidado/Index.cshtml");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}