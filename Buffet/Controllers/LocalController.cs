using System.Collections.Generic;
using System.Threading.Tasks;
using Buffet.Models;
using Buffet.Models.Endereco;
using Buffet.Models.Evento;
using Buffet.Models.Local;
using Buffet.RequestModels;
using Buffet.ViewModels.Private.Local;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class LocalController : Controller
    {
        private readonly LocalService _localService;
        private readonly EnderecoService _enderecoService;
        private readonly EventoService _eventoService;

        public LocalController(LocalService localService, EnderecoService enderecoService, EventoService eventoService)
        {
            _localService = localService;
            _enderecoService = enderecoService;
            _eventoService = eventoService;
        }

        public async Task<IActionResult> Index(string descricao)
        {
            var allLocais = await _localService.GetAll();
            var locais = new List<LocalEntity>();
            foreach (var l in allLocais)
            {
                if (descricao == null || l.Descricao.Contains(descricao))
                {
                    locais.Add(l);
                }
            }
            var lvm = new LocalViewModel {Locais = locais};
            return View("~/Views/Private/Local/Local.cshtml", lvm);
        }

        public IActionResult Create()
        {
            var lvm = new LocalViewModel();
            return View("~/Views/Private/Local/CreateLocal.cshtml", lvm);
        }

        public async Task<IActionResult> Store(StoreEnderecoRequest request)
        {
            if (request.Id == 0)
            {
                await _localService.store(request);
            }
            else
            {
                await _localService.update(request.Id, request);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var local = await _localService.GetById(id);
            var endereco = await _enderecoService.getById(local.Endereco.Id);
            var lvm = new LocalViewModel()
            {
                Id = local.Id,
                Locais = await _localService.GetAll(),
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Descricao = local.Descricao,
                Estado = endereco.Estado,
                Numero = endereco.Numero,
                Rua = endereco.Rua
            };
            return View("~/Views/Private/Local/CreateLocal.cshtml", lvm);
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _localService.destroy(id);
            var locais = await _localService.GetAll();
            var localViewModel = new LocalViewModel() {Locais = locais};
            return View("~/Views/Private/Local/Local.cshtml", localViewModel);
        }

        public async Task<IActionResult> VerEventos(int id)
        {
            List<EventoEntity> eventos =  await _eventoService.GetEventosByLocal(id);
            EventosLocalViewModel elv = new EventosLocalViewModel();
            elv.Eventos = eventos;
            return View("~/Views/Private/Local/EventosLocal.cshtml", elv);
        }
    }
}