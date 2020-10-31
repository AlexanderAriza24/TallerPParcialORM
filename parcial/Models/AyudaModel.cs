using Entity;

namespace parcial.Models
{
    public class AyudaInputModel
    {
        public string AyudaId {get; set;}
        public int ValorAyuda {get; set;}
        public string Modalidad {get; set;}
        public string Fecha {get; set;}
    
    }

    public class AyudaViewModel : AyudaInputModel
    {
        public AyudaViewModel()
        {

        }
        public AyudaViewModel(Ayuda ayuda)
        {
            AyudaId = ayuda.AyudaId;
            ValorAyuda = ayuda.ValorAyuda;
            Modalidad = ayuda.Modalidad;
            Fecha = ayuda.Fecha;
        }
    }
}