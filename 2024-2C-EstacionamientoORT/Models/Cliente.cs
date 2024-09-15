using _2024_2C_EstacionamientoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Cliente : Persona
    {

        public Cliente() { }

        [Required(ErrorMessage = ErrorMsge.Requerido)]
        [Display(Name = "Numero Cuil")]
        public long Cuil { get; set; }

        //public Direccion Direccion { get; set; }

        public List<ClienteVehiculo> VehiculosAutorizados { get; set; }

    }
}
