using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Persona
    {
        public Persona()
        {

        }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

       

        public string Dni { get; set; }
        public string Email { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre}, {Apellido}";
            }

        }

        public Direccion Direccion { get; set; }

        public List<Telefono> Telefonos { get; set; }

    }
}

