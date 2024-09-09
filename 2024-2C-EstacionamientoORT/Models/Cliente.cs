using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Cliente : Persona
    {

        public Cliente() { }

        public long Cuil { get; set; }

        //public Direccion Direccion { get; set; }

        public List<ClienteVehiculo> VehiculosAutorizados { get; set; }

    }
}
