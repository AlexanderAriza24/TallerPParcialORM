using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using parcial.Models;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AyudaController : ControllerBase
    {
        private readonly AyudaService _ayudaService;
        public AyudaController(PersonaContext context)
        {
            _ayudaService = new AyudaService(context);
        }

        // GET: api/Ayuda
        [HttpGet]
        public IEnumerable<AyudaViewModel> Gets()
        {
            var ayudas = _ayudaService.ConsultarTodos().Select(p=> new AyudaViewModel(p));
            return ayudas;
        }

        // POST: api/Ayuda
        [HttpPost]
        public ActionResult<AyudaViewModel> Post(AyudaInputModel ayudaInput)
        {
            Ayuda ayuda = MapearAyuda(ayudaInput);
            var response = _ayudaService.Guardar(ayuda);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Ayuda);
        }

        [HttpGet("{saldoValidar}")]
        public ActionResult<bool> VerificarAyuda(int saldoValidar)
        {
            var respuesta = _ayudaService.VerificarAyuda(saldoValidar);
            if(respuesta) return true;
            return false;
        }

        private Ayuda MapearAyuda(AyudaInputModel ayudaInput)
        {
            var ayuda = new Ayuda
            {
                AyudaId = ayudaInput.AyudaId,
                ValorAyuda = ayudaInput.ValorAyuda,
                Modalidad = ayudaInput.Modalidad,
                Fecha = ayudaInput.Fecha,
            };
            return ayuda;
        }
    }
}