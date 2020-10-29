using Entity;

namespace parcial.Models
{
    public class PersonaInputModel
    {
        public string Identificacion {get; set;}
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string Sexo {get; set;}
        public int Edad {get; set;}
        public string Departamento {get; set;}
        public string Ciudad {get; set;}
        public Ayuda Ayuda {get; set;}
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombres = persona.Nombres;
            Apellidos = persona.Apellidos;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            Ayuda = persona.Ayuda;
        }
    }
    
}