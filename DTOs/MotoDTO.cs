using MotoPuntoBack.Models;

namespace MotoPuntoBack.DTOs
{
    public class MotoDTO
    {
        public int Idmoto { get; set; }
        public string ?Nombre { get; set; }
        public string ?MarcaDescripcion { get; set; }  // Del IdmarcaNavigation.Descripcion
 
        public double Cilindrada { get; set; }
        public string ?Motor { get; set; }
        public string? Potencia { get; set; }
        public string? Suspenciond { get; set; }
        public string? Suspenciont { get; set; }
        public string? Torque { get; set; }
        public string? Alimentacion { get; set; }
        public string? Encendido { get; set; }
        public string? Iluminacion { get; set; }
        public double Tanquel { get; set; }
        public string? Transmision { get; set; }
        public string ?Cajacambio { get; set; }
        public double? Peso { get; set; }
        public double Precio { get; set; }
        public string ?Tipomoto { get; set; }
        public string? Neumaticot { get; set; }
        public string? Neumaticod { get; set; }

        public string? Refrigeracion { get; set; }
        public string? Aceite { get; set; }

        public virtual List<ImagenDTO> Imagens { get; set; } = new List<ImagenDTO>();
    }


    public class PostMotoDTO
    {
       
        public string? Nombre { get; set; }
        public int? IdMarca { get; set; }  // Del IdmarcaNavigation.Descripcion


        public string? Motor { get; set; }
        public double? Cilindrada { get; set; } = 0.0f;

        public string? Aceite { get; set; } 
        public string? Potencia { get; set; }
        public string? Suspenciond { get; set; }
        public string? Suspenciont { get; set; }
        public string? Combustible { get; set; }
        public string? Alimentacion { get; set; }
        public string? Encendido { get; set; }
        public string? Iluminacion { get; set; }
        public double? Tanquel { get; set; }
        public string? Transmision { get; set; }
        public string? Cajacambio { get; set; }
   
        public double? Precio { get; set; }
        public string? Tipomoto { get; set; }
        public string? Neumaticot { get; set; }
        public string? Neumaticod { get; set; }

        public string? Refrigeracion { get; set; }
        public List<ImagenDTO>? Imagenes { get; set; }

       // public virtual ICollection<Imagen> Imagens { get; set; } = new List<Imagen>();
    }
}
