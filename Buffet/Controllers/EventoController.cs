using Buffet.Models;
using Buffet.Models.Cliente;
using Buffet.Models.Evento;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoEvento;
using Buffet.ViewModels.Private.Evento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class EventoController : Controller
    {
        private readonly EventoService _eventoService;
        private readonly ILogger<EventoController> _logger;

        public EventoController(EventoService eventoService, ILogger<EventoController> logger)
        {
            _eventoService = eventoService;
            _logger = logger;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Eventos = eventos;
            return View("~/Views/Private/Evento/Index.cshtml", indexViewModel);
        }

        public async Task<IActionResult> Store(int id, string descricao, DateTime inicio, DateTime fim, ClienteEntity cliente, SituacaoEventoEntity situacao, string obs, TipoEventoEntity tipoEvento)
        {
            if (id == 0)
            {
                await _eventoService.store(descricao,inicio, fim, cliente, situacao, obs, tipoEvento);
            }
            else
            {
                await _eventoService.update(id, descricao);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var evento = await _eventoService.getById(id);
            var situacoes = await _eventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Eventos = situacoes;
            indexViewModel.id = evento.Id;
            indexViewModel.descricao = evento.Descricao;
            return View("~/Views/Private/Evento/Index.cshtml", indexViewModel);
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _eventoService.destroy(id);
            var eventos = await _eventoService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.mensagem = "Deletado com sucesso!";
            indexViewModel.Eventos = eventos;
            return View("~/Views/Private/Evento/Index.cshtml", indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
