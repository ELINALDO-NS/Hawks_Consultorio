using HC.Core.Domain;
using HC.Core.Shared.ModelViews;
using HC.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
       private readonly IClienteManager _clienteManager;

        public ClientesController(IClienteManager clienteManager)
        {
            _clienteManager = clienteManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _clienteManager.GetClientesAsync());
        }

    
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _clienteManager.GetClienteAsync(id));
        }

        
        [HttpPost]
        public async Task<IActionResult> Post (NovoCliente novocliente)
        {
            var ClienteInserido = await _clienteManager.InsertClienteAsync(novocliente);

            return CreatedAtAction(nameof(Get),new {id = ClienteInserido.Id}, ClienteInserido);
        }

        
        [HttpPut]
        public async Task<IActionResult> Put(AlteraCliente alteracliente)
        {
            var ClienteAtualizado = await _clienteManager.UpdateClienteAsync(alteracliente);
            if (ClienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(ClienteAtualizado);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
