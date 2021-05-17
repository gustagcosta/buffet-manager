using System.Diagnostics;
using System.Threading.Tasks;
using Buffet.Models;
using Buffet.Models.TipoEvento;
using Buffet.ViewModels.Private.TipoEvento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buffet.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly TipoEventoService _tipoEventoService;
        private readonly ILogger<TipoEventoController> _logger;
        
        public TipoEventoController(TipoEventoService tipoEventoService, ILogger<TipoEventoController> logger)
        {
            _tipoEventoService = tipoEventoService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var tipos = await _tipoEventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Tipos = tipos;
            return View("~/Views/Private/TipoEvento/Index.cshtml", indexViewModel);
        }
        
        public async Task<IActionResult> Store(string descricao, int id)
        {
            if (id == 0)
            {
                await _tipoEventoService.store(descricao);
            }
            else
            {
                await _tipoEventoService.update(id, descricao);
            }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var tipo = await _tipoEventoService.getById(id);
            var tipos = await _tipoEventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Tipos = tipos;
            indexViewModel.id = tipo.Id;
            indexViewModel.descricao = tipo.Descricao;
            return View("~/Views/Private/TipoEvento/Index.cshtml", indexViewModel);
        }
        
        public async Task<IActionResult> Destroy(int id)
        {
            await _tipoEventoService.destroy(id);
            var tipos = await _tipoEventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.mensagem = "Deletado com sucesso!";
            indexViewModel.Tipos = tipos;
            return View("~/Views/Private/TipoEvento/Index.cshtml", indexViewModel);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}