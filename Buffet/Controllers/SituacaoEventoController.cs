using System.Diagnostics;
using System.Threading.Tasks;
using Buffet.Models;
using Buffet.Models.SituacaoEvento;
using Buffet.ViewModels.Private.SituacaoEvento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    public class SituacaoEventoController : Controller
    {
        private readonly SituacaoEventoService _situacaoEventoService;
        private readonly ILogger<SituacaoEventoController> _logger;
        
        public SituacaoEventoController(SituacaoEventoService situacaoEventoService, ILogger<SituacaoEventoController> logger)
        {
            _situacaoEventoService = situacaoEventoService;
            _logger = logger;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var situacoes = await _situacaoEventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Situacoes = situacoes;
            return View("~/Views/Private/SituacaoEvento/Index.cshtml", indexViewModel);
        }
        
        public async Task<IActionResult> Store(string descricao, int id)
        {
            if (id == 0)
            {
                await _situacaoEventoService.store(descricao);
            }
            else
            {
                await _situacaoEventoService.update(id, descricao);
            }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var situacao = await _situacaoEventoService.getById(id);
            var situacoes = await _situacaoEventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Situacoes = situacoes;
            indexViewModel.id = situacao.Id;
            indexViewModel.descricao = situacao.Descricao;
            return View("~/Views/Private/SituacaoEvento/Index.cshtml", indexViewModel);
        }
        
        public async Task<IActionResult> Destroy(int id)
        {
            await _situacaoEventoService.destroy(id);
            var situacoes = await _situacaoEventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.mensagem = "Deletado com sucesso!";
            indexViewModel.Situacoes = situacoes;
            return View("~/Views/Private/SituacaoEvento/Index.cshtml", indexViewModel);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}