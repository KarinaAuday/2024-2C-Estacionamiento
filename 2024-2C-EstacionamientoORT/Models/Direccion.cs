using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Direccion
    {
        public int Id { get; set; }

        public String Calle { get; set; }

    
        public long CodPostal { get; set; }

        public Persona Persona
        {
            get; set;
        }
    }
}