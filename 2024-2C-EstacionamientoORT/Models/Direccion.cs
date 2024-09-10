using _2024_2C_EstacionamientoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Direccion
    {
        public int Id { get; set; }

        public String Calle { get; set; }

    
        public long CodPostal { get; set; }

        //Propiedad relacional Obligatoria
        [Required(ErrorMessage = ErrorMsge.Requerido)]
        public int PersonaId { get; set; }


        //Propiedades Navegacionales No Obligatorias
        public Persona Persona
        {
            get; set;
        }
    }
}