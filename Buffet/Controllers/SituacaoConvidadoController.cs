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
        
        public async Task<IActionResult> Store(string descricao, int id)
        {
            if (id == 0)
            {
                await _situacaoConvidadoService.store(descricao);
            }
            else
            {
                await _situacaoConvidadoService.update(id, descricao);
            }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var situacao = await _situacaoConvidadoService.getById(id);
            var situacoes = await _situacaoConvidadoService.getAll();
            var scvm = new IndexViewModel();
            scvm.Situacoes = situacoes;
            scvm.id = situacao.Id;
            scvm.descricao = situacao.Descricao;
            return View("~/Views/Private/SituacaoConvidado/Index.cshtml", scvm);
        }
        
        public async Task<IActionResult> Destroy(int id)
        {
            await _situacaoConvidadoService.destroy(id);
            var situacoes = await _situacaoConvidadoService.getAll();
            var scvm = new IndexViewModel();
            scvm.mensagem = "Deletado com sucesso!";
            scvm.Situacoes = situacoes;
            return View("~/Views/Private/SituacaoConvidado/Index.cshtml", scvm);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}