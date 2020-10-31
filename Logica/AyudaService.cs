using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class AyudaService
    {
        private readonly PersonaContext _context;
        public AyudaService(PersonaContext context)
        {
            _context = context;
        }

        public GuardarAyudaResponse Guardar(Ayuda ayuda)
        {
            try
            {
                _context.Ayudas.Add(ayuda);
                _context.SaveChanges();
                return new GuardarAyudaResponse(ayuda);
            }catch(Exception e)
            {
                return new GuardarAyudaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public List<Ayuda> ConsultarTodos()
        {
            List<Ayuda> ayudas = _context.Ayudas.ToList();
            return ayudas;
        }

        public bool VerificarAyuda(int valor)
        {
            int saldoAsignado = Total();
            if(saldoAsignado + valor > 600000000)
            {
                return true;
            }
            return false;
        }

        public int Total()
        {
            int total =0;
            List<Ayuda> ayudas = _context.Ayudas.ToList();
            foreach(Ayuda ayuda in ayudas)
            {
                total +=ayuda.ValorAyuda;
            }
            return total;
        }
    }

    public class GuardarAyudaResponse 
    {
        public GuardarAyudaResponse(Ayuda ayuda)
        {
            Ayuda = ayuda;
            Error = false;
        }

        public GuardarAyudaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Ayuda Ayuda { get; set; }
    } 
}