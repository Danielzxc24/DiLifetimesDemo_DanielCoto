using DiLifetimesDemo_DanielCoto.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiLifetimesDemo_DanielCoto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SingletonsController : Controller
    {
        private readonly ISafeSingletonService _safeSingleton;

        public SingletonsController(ISafeSingletonService safeSingleton)
        {
            _safeSingleton = safeSingleton;
        }

        [HttpGet("safe-scoped")]
        public IActionResult GetSafeScopedFromSingleton()
        {
            var scopedId = _safeSingleton.GetScopedIdFromNewScope();

            var result = new
            {
                Mensaje = "Ejemplo de como un Singleton puede usar un Scoped sin generar dependencia cautiva",
                SingletonCodigo = _safeSingleton.SingletonId,
                ScopedGenerado = scopedId
            };

            return Ok(result);
        }
    }
}
