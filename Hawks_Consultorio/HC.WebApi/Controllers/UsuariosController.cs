using HC.Core.Domain;
using HC.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioManager manager;
        public UsuariosController(IUsuarioManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Route("ValidaUsuario")]
        public async Task<IActionResult> ValidaUsuario( Usuario usuario)
        {
            var valido = await manager.ValidaSenhaAsync(usuario);
            if (valido)
            {
                return Ok();
            }
            return Unauthorized();
        }
        [HttpGet("{login}")]
        public string Get(string login)
        {
            return "value";
        }
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            var usuarioInserido = await manager.InsertAsync(usuario);
            return CreatedAtAction(nameof(Get), new { login = usuario.Login }, usuarioInserido);
        }
    }
}
