using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using parcial.Models;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;
        public PersonaController(PersonaContext context)
        {
            _personaService = new PersonaService(context);
        }
        
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var personas = _personaService.ConsultarTodos().Select(p=> new PersonaViewModel(p));
            return personas;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<bool> VerificarDuplicado(string identificacion)
        {
            var respuesta = _personaService.VerificarDuplicado(identificacion);
            if(respuesta) return true;
            return false;
        }

        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }

        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            {
                Identificacion = personaInput.Identificacion,
                Nombres = personaInput.Nombres,
                Apellidos = personaInput.Apellidos,
                Edad = personaInput.Edad,
                Sexo = personaInput.Sexo,
                Departamento = personaInput.Departamento,
                Ciudad = personaInput.Ciudad,
                Ayuda = personaInput.Ayuda,
            };
            return persona;
        }
    }
}