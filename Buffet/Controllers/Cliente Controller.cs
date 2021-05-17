using Buffet.Models;
using Buffet.Models.Cliente;
using Buffet.Models.TipoCliente;
using Buffet.ViewModels.Private.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class CienteController
    {
        private readonly ClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;

        public CienteController(ClienteService clienteService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Clientes = clientes;
            return View("~/Views/Private/Cliente/Index.cshtml", indexViewModel);
        }

        private IActionResult View(string v, IndexViewModel indexViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Store(int id)
        {
            if (id == 0)
            {
                await _clienteService.store();
            }
            else
            {
                await _clienteService.update(id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteService.getById(id);
            var situacoes = await _clienteService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Clientes = situacoes;
            indexViewModel.id = cliente.Id;
            indexViewModel.descricao = cliente.Descricao;
            return View("~/Views/Private/Cliente/Index.cshtml", indexViewModel);
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _clienteService.destroy(id);
            var clientes = await _clienteService.getAll();
            var indexViewModel = new IndexViewModel();
            indexViewModel.mensagem = "Deletado com sucesso!";
            indexViewModel.Clientes = clientes;
            return View("~/Views/Private/Cliente/Index.cshtml", indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
