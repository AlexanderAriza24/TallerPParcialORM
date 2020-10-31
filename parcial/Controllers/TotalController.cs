using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalController : ControllerBase
    {
        private readonly AyudaService _ayudaService;
        public TotalController(PersonaContext context)
        {
            _ayudaService = new AyudaService(context);
        }

        [HttpGet]
        public ActionResult<int> TotalAyuda()
        {
            var total = _ayudaService.Total();
            return total;
        }
    }
}