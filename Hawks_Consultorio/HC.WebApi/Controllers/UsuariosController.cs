using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Usuario;
using HC.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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
        [Route("login")]
        public async Task<IActionResult> Login( Usuario usuario)
        {
            var UsuarioLogado = await manager.ValidaUsuarioGeraTokemAsync(usuario);
            if (UsuarioLogado != null)
            {
                return Ok(UsuarioLogado);
            }
            return Unauthorized();
        }
        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            
            var usuario = await manager.GetAsync(User.Identity.Name);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Post(NovoUsuario usuario)
        {
            var usuarioInserido = await manager.InsertAsync(usuario);
            return CreatedAtAction(nameof(Get), new { login = usuario.Login }, usuarioInserido);
        }
    }
}
