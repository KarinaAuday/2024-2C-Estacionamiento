using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Telefono
    {
        public int Id { get; set; }

   
        public int CodArea { get; set; }

       
        public string Numero { get; set; }

        public bool Principal { get; set; }

     
        public TipoTelefono Tipo { get; set; }


       



        public int PersonaId { get; set; }

        public Persona Persona { get; set; }

        //public Cliente Cliente { get; set; }

        [NotMapped]
        public string NumeroCompleto { get { return $"({CodArea}) - {Numero}"; } }
    }
}