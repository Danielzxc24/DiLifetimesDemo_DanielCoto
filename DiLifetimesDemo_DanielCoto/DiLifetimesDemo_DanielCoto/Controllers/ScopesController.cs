using DiLifetimesDemo_DanielCoto.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiLifetimesDemo_DanielCoto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScopesController : Controller
    {
        private readonly IScopedService _requestScoped;
        private readonly IServiceScopeFactory _scopeFactory;

        public ScopesController(
            IScopedService requestScoped,
            IServiceScopeFactory scopeFactory)
        {
            _requestScoped = requestScoped;
            _scopeFactory = scopeFactory;
        }

        [HttpGet("compare")]
        public IActionResult CompareScopes()
        {
            using var scope = _scopeFactory.CreateScope();

            var manualScoped = scope.ServiceProvider
                                    .GetRequiredService<IScopedService>();

            var result = new
            {
                Mensaje = "Comparación entre el servicio Scoped del request actual y uno generado en un scope manual",
                RequestActual = _requestScoped.Codigo,
                ScopedManual = manualScoped.Codigo,
                Nota = "los valores deben ser diferentes porque pertenecen a scopes distintos"
            };

            return Ok(result);
        }
    }
}
