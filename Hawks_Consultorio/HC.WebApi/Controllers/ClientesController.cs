using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Cliente;
using HC.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogTimings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
       private readonly IClienteManager _clienteManager;
       private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger)
        {
            _clienteManager = clienteManager;
            _logger = logger;
        }
        /// <summary>
        /// Retorna todos os cliente cadastrados na base
        /// </summary>

        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteManager.GetClientesAsync();
            if (clientes.Any())
            {
                return Ok(clientes);
            }

            return NotFound();
        }

    /// <summary>
    /// Retona um cliente consultado pelo id
    /// </summary>
    /// <param name="id" example = "123"></param>

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
           
            return Ok(await _clienteManager.GetClienteAsync(id));
        }

        /// <summary>
        /// Insere um novo cliente
        /// </summary>
        /// <param name="novocliente"></param>

        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post (NovoCliente novocliente)
        {
            _logger.LogInformation("Objeto recebido {@novocliente}",novocliente);
            ClienteView ClienteInserido;
            using (Operation.Time("Tempo de adição do cliente "))
            {
                 ClienteInserido = await _clienteManager.InsertClienteAsync(novocliente);
            }
            return CreatedAtAction(nameof(Get),new {id = ClienteInserido.Id}, ClienteInserido);
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="alteracliente"></param>

        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlteraCliente alteracliente)
        {
            var ClienteAtualizado = await _clienteManager.UpdateClienteAsync(alteracliente);
            if (ClienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(ClienteAtualizado);
        }

       /// <summary>
       /// Exclui um cliente 
       /// </summary>
       /// <param name="id" example= "123"></param>

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
           var clienteExcluido =  await _clienteManager.DeleteClienteAsync(id);
            if (clienteExcluido == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
