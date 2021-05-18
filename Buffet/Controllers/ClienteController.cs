using Buffet.Models;
using Buffet.Models.Cliente;
using Buffet.Models.Endereco;
using Buffet.Models.Evento;
using Buffet.Models.TipoCliente;
using Buffet.ViewModels.Private.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly TipoClienteService _tipoClienteService;
        private readonly EnderecoService _enderecoService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ClienteService clienteService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
            
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.getAll();
            var clienteViewModel = new ClienteViewModel();
            clienteViewModel.Clientes = clientes;
            return View("~/Views/Private/ListaCliente.cshtml", clienteViewModel);
        }

        public IActionResult Create()
        {
            var cvm = new ClienteViewModel();
            return View("~/Views/Private/CadastroCliente.cshtml", cvm);
        }


        public async Task<IActionResult> Store(int id, string nomeCliente, string tipoCliente, 
                                                string emailCliente, string enderecoRuaCliente, string enderecoBairroCliente, string enderecoEstadoCliente,
                                                string enderecoCidadeCliente, int enderecoNumCliente, string obsCliente, DateTime criadoEm)
        {
            if (id == 0)
            {
                criadoEm = DateTime.Today;
                await _clienteService.store(nomeCliente, tipoCliente, emailCliente, enderecoRuaCliente, enderecoBairroCliente, enderecoEstadoCliente, 
                                            enderecoCidadeCliente, enderecoNumCliente, obsCliente, criadoEm);
            }
            else
            {
                //await _clienteService.update(id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteService.getById(id);
            EnderecoEntity endereco = await _enderecoService.getById(cliente.Endereco.Id);
            TipoClienteEntity tipo = await _tipoClienteService.getById(cliente.TipoCliente.Id);
            var clienteViewModel = new ClienteViewModel(id, cliente.Nome,
                tipo.Descricao, cliente.Email, endereco.Estado, endereco.Cidade, endereco.Bairro, endereco.Rua, endereco.Numero, cliente.Observacoes);
            return View("~/Views/Private/CadastroCliente.cshtml", clienteViewModel);
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _clienteService.destroy(id);
            var clientes = await _clienteService.getAll();
            var clienteViewModel = new ClienteViewModel();
            clienteViewModel.mensagem = "Deletado com sucesso!";
            clienteViewModel.Clientes = clientes;
            return View("~/Views/Private/ListaCliente.cshtml", clienteViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
