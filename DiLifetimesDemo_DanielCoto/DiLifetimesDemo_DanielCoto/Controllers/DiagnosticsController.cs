using DiLifetimesDemo_DanielCoto.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiLifetimesDemo_DanielCoto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticsController : Controller
    {
        private readonly ITransientService _transient1;
        private readonly ITransientService _transient2;

        private readonly IScopedService _scoped1;
        private readonly IScopedService _scoped2;

        private readonly ISingletonService _singleton1;
        private readonly ISingletonService _singleton2;

        public DiagnosticsController(
            ITransientService transient1,
            ITransientService transient2,
            IScopedService scoped1,
            IScopedService scoped2,
            ISingletonService singleton1,
            ISingletonService singleton2)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        [HttpGet("lifetimes")]
        public IActionResult GetLifetimes()
        {
            var result = new
            {
                Mensaje = "Demostración de cómo se comportan los diferentes lifetimes en un mismo request",

                Transients = new
                {
                    Comentario = "Por cada solicitud genera una instancia completamente nueva",
                    Instancia1 = _transient1.Codigo,
                    Instancia2 = _transient2.Codigo
                },

                Scoped = new
                {
                    Comentario = "En el mismo request deben ser iguales, ya que comparten scope",
                    Instancia1 = _scoped1.Codigo,
                    Instancia2 = _scoped2.Codigo
                },

                Singleton = new
                {
                    Comentario = "Son idénticos en este request y seguirán siendo iguales entre diferentes requests",
                    Instancia1 = _singleton1.Codigo,
                    Instancia2 = _singleton2.Codigo
                }
            };

            return Ok(result);
        }
    }
}
