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
using Buffet.ViewModels.Private.Local;

namespace Buffet.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly TipoClienteService _tipoClienteService;
        private readonly EnderecoService _enderecoService;
        private readonly EventoService _eventoService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ClienteService clienteService, TipoClienteService tipoClienteService, EnderecoService enderecoService,
            EventoService eventoService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _tipoClienteService = tipoClienteService;
            _enderecoService = enderecoService;
            _eventoService = eventoService;
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

        public async Task<IActionResult> ClientesFiltroAsync(string buscaNome, string buscaEmail)
        {

            var cvm = new ClienteViewModel();
            cvm.Clientes = await _clienteService.buscaClientes(buscaNome, buscaEmail);
            return View("~/Views/Private/ListaCliente.cshtml", cvm);
        }


        public async Task<IActionResult> Store(int id, string nomeCliente, string tipoCliente,
                                                string emailCliente, string enderecoRuaCliente, string enderecoBairroCliente, string enderecoEstadoCliente,
                                                string enderecoCidadeCliente, int enderecoNumCliente, string obsCliente)
        {
            if (id == 0)
            {
                var criadoEm = DateTime.Today;
                await _clienteService.store(nomeCliente, tipoCliente, emailCliente, enderecoRuaCliente, enderecoBairroCliente, enderecoEstadoCliente,
                                            enderecoCidadeCliente, enderecoNumCliente, obsCliente, criadoEm);
            }
            else
            {
                var editadoEm = DateTime.Today;
                var eventos = _eventoService.getEventosByCliente(id);
                await _clienteService.update(id, nomeCliente, tipoCliente, emailCliente, enderecoRuaCliente, enderecoBairroCliente, enderecoEstadoCliente,
                    enderecoCidadeCliente, enderecoNumCliente, obsCliente, editadoEm, eventos);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteService.getById(id);
            var enderecoCliente = await _enderecoService.getById(cliente.Endereco.Id);
            var lvm = new ClienteViewModel()
            {
                id = cliente.Id,
                nome = cliente.Nome,
                email = cliente.Email,
                Clientes = await _clienteService.getAll(),
                Bairro = enderecoCliente.Bairro,
                Cidade = enderecoCliente.Cidade,
                obs = cliente.Observacoes,
                Estado = enderecoCliente.Estado,
                Numero = enderecoCliente.Numero,
                Rua = enderecoCliente.Rua
            };
            return View("~/Views/Private/CadastroCliente.cshtml", lvm);
        }

        public async Task<IActionResult> Destroy(int id)
        {
            var clientes = await _clienteService.getAll();
            var cliente =  _clienteService.getByIdToDestroy(id);
            var clienteViewModel = new ClienteViewModel();
            var listaEventos = _eventoService.getEventosByCliente(id);
            
            if(listaEventos.Count > 0) 
            {
                clienteViewModel.mensagem = "Cliente com evento agendado não pode ser excluído!";
                clienteViewModel.Clientes = clientes;
                return View("~/Views/Private/ListaCliente.cshtml", clienteViewModel);
            }

            await _clienteService.destroy(cliente);
            clienteViewModel.mensagem = "Deletado com sucesso!";
            clienteViewModel.Clientes = clientes;
            return View("~/Views/Private/ListaCliente.cshtml", clienteViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult VerEventos(int id)
        {
            List<EventoEntity> eventos = _eventoService.GetEventosByIdCliente(id);
            var elv = new EventosLocalViewModel();
            elv.Eventos = eventos;
            return View("~/Views/Private/EventosCliente.cshtml", elv);
        }
    }
}
