using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Ayuda
    {
        [Key]
        public string AyudaId {get; set;}
        public int ValorAyuda {get; set;}
        public string Modalidad {get; set;}
        public string Fecha {get; set;}
    }
}