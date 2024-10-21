using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }


        [RegularExpression(@"^[A-Za-z0-9]{6,7}$", ErrorMessage = "La patente debe tener entre 6 y 7 caracteres alfanuméricos.")]

        public int Patente { get; set; }

        [Required]
        [Display(Name = "Marca Auto")]
        public string Marca { get; set; }


       
        public string Color { get; set; }


         public int AnioFabricacion { get; set; } = DateTime.Now.Year;

        public List<ClienteVehiculo> PersonasAutorizadas { get; set; }



        public Vehiculo(int patente, string marca, string color)
        {
            this.Patente = patente;
            this.Marca = marca;
            this.Color = color;

        }
        public Vehiculo()
        {
                
        }
    }

   
}
