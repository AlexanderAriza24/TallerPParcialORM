using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Ayuda
    {
        [Key]
        public string AyudaId {get; set;}
        public int ValorApoyo {get; set;}
        public string Modalidad {get; set;}
        public string Fecha {get; set;}
        public string PersonaId {get; set;}
    }
}