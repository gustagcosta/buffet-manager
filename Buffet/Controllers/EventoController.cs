using Buffet.Models;
using Buffet.Models.Cliente;
using Buffet.Models.Evento;
using Buffet.Models.Local;
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
        private readonly ClienteService _clienteService;
        private readonly LocalService _localService;
        private readonly SituacaoEventoService _situacaoEventoService;
        private readonly TipoEventoService _tipoEventoService;
        private readonly ILogger<EventoController> _logger;

        public EventoController(EventoService eventoService, ClienteService clienteService, LocalService localService, SituacaoEventoService situacaoEventoService, TipoEventoService tipoEventoService, ILogger<EventoController> logger)
        {
            _eventoService = eventoService;
            _clienteService = clienteService;
            _localService = localService;
            _situacaoEventoService = situacaoEventoService;
            _tipoEventoService = tipoEventoService;
            _logger = logger;
        }




        // GET
        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoService.getAll();
            var indexViewModel = new EventoViewModel();
            indexViewModel.Eventos = eventos;
            return View("~/Views/Private/Evento.cshtml", indexViewModel);
        }

        public async Task<IActionResult> CreateAsync()
        {
            var lvm = new EventoViewModel();
            var locais = await _localService.GetAll();
            var tipos = await _tipoEventoService.getAll();
            lvm.Locais = locais;
            lvm.Situacoes = await _situacaoEventoService.getAll();
            lvm.Clientes = await _clienteService.getAll();
            lvm.tipos = tipos;

            return View("~/Views/Private/CadastroEvento.cshtml", lvm);
        }

        public async Task<IActionResult> EventoFiltroAsync(string buscaDesc, DateTime buscaInicio, DateTime buscaFim)
        {
            var cvm = new EventoViewModel();
            cvm.Eventos = await _eventoService.buscaEventos(buscaDesc, buscaInicio, buscaFim);
            return View("~/Views/Private/Evento.cshtml", cvm);
        }

        public async Task<IActionResult> Store(int id, string descricao, int tipoCliente, DateTime dataInicio, DateTime dataFim,
            DateTime horaInicio, DateTime horaFim, int clienteId, int situacaoId, string obs, int localId)
        {
            if (id == 0)
            {
                var criadoEm = DateTime.Now;
                var tipo = await  _tipoEventoService.getById(tipoCliente);
                var cliente = await _clienteService.getById(clienteId);
                var situacao = await _situacaoEventoService.getById(situacaoId);
                var local = await _localService.GetById(localId);
                var inicio = dataInicio.Date + horaInicio.TimeOfDay;
                var fim = dataFim.Date + horaFim.TimeOfDay;
                await _eventoService.store(descricao, tipo, inicio, fim, cliente, situacao, local,  obs, criadoEm);
            }
            else
            {
                
                var editadoEm = DateTime.Now;
                var tipo = await _tipoEventoService.getById(tipoCliente);
                var cliente = await _clienteService.getById(clienteId);
                var situacao = await _situacaoEventoService.getById(situacaoId);
                var local = await _localService.GetById(localId);
                var inicio = dataInicio.Date + horaInicio.TimeOfDay;
                var fim = dataFim.Date + horaFim.TimeOfDay;
                await _eventoService.update(id, descricao, tipo, inicio, fim, cliente, situacao, local, obs, editadoEm);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var evento = await _eventoService.getById(id);
            var situacoes = await _situacaoEventoService.getAll();
            var listaTipos = await _tipoEventoService.getAll();
            var listaClientes = await _clienteService.getAll();
            var locais = await _localService.GetAll();
            var indexViewModel = new EventoViewModel()
            {
                Situacoes = situacoes,
                id = evento.Id,
                descricao = evento.Descricao,
                tipoEvento = evento.TipoEvento,
                Cliente = evento.Cliente,
                dataInicio = evento.Inicio,
                dataFim = evento.Fim,
                SituacaoEvento = evento.SituacaoEvento,
                tipos = listaTipos,
                Clientes = listaClientes,
                Locais = locais,
                local = evento.Local,
                obs = evento.Observacoes

            };
            
            
            indexViewModel.descricao = evento.Descricao;
            return View("~/Views/Private/CadastroEvento.cshtml", indexViewModel);
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _eventoService.destroy(id);
            var eventos = await _eventoService.getAll();
            var indexViewModel = new EventoViewModel();
            indexViewModel.mensagem = "Deletado com sucesso!";
            indexViewModel.Eventos = eventos;
            return View("~/Views/Private/Evento.cshtml", indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
