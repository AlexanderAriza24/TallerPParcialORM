using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class PersonaService
    {
        private readonly PersonaContext _context;
        public PersonaService(PersonaContext context)
        {
            _context=context;
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                PersonaBd personaBd = MapearPersonaBd(persona);
                _context.Personas.Add(personaBd);
                _context.SaveChanges();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public bool VerificarDuplicado(string Identificacion)
        {
            PersonaBd personaBd = _context.Personas.Find(Identificacion);
            if(personaBd != null)
            {
                return true;
            }
            return false;
        }

        public List<Persona> ConsultarTodos()
        {
            List<PersonaBd> personaBds = _context.Personas.ToList();
            List<Persona> personas = new List<Persona>();

            foreach(PersonaBd personaBd in personaBds)
            {
                personas.Add(MapearPersona(personaBd));
            }
            return personas;
        }

        public PersonaBd MapearPersonaBd(Persona persona)
        {
            PersonaBd personaBd = new PersonaBd();
            personaBd.Identificacion = persona.Identificacion;
            personaBd.Nombres = persona.Nombres;
            personaBd.Apellidos = persona.Apellidos;
            personaBd.Edad = persona.Edad;
            personaBd.Sexo = persona.Sexo;
            personaBd.Departamento = persona.Departamento;
            personaBd.Ciudad = persona.Ciudad;
            personaBd.CodigoAyuda = persona.Ayuda.AyudaId;
            return personaBd;
        }

        public Persona MapearPersona(PersonaBd personaBd)
        {
            Persona persona = new Persona();
            persona.Identificacion = personaBd.Identificacion;
            persona.Nombres = personaBd.Nombres;
            persona.Apellidos = personaBd.Apellidos;
            persona.Edad = personaBd.Edad;
            persona.Sexo = personaBd.Sexo;
            persona.Departamento = personaBd.Departamento;
            persona.Ciudad = personaBd.Ciudad;
            persona.Ayuda = _context.Ayudas.Find(personaBd.Identificacion);
            return persona;
        }
    }

    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}
