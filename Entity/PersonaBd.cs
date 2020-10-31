using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class PersonaBd
    {
        [Key]
        public string Identificacion {get; set;}
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string Sexo {get; set;}
        public int Edad {get; set;}
        public string Departamento {get; set;}
        public string Ciudad {get; set;}
        public string CodigoAyuda {get; set;}
    }
}