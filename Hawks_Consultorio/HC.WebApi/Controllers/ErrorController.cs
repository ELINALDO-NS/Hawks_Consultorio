using HC.Core.Shared.ModelViews.Erro;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HC.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("Error")]
        public ErrorResponse Error()
        {
            var idErro = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            return new ErrorResponse(idErro);
        }
    }
}
