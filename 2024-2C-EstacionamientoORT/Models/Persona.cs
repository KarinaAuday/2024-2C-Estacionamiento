using System.ComponentModel.DataAnnotations;
using _2024_2C_EstacionamientoORT.Helpers;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Persona
    {
        public Persona() {}



        public int Id { get; set; }

        [Required (ErrorMessage = ErrorMsge.Requerido )]
        [Display (Name = "Nombre")]
        [StringLength(100, MinimumLength = 2 ,  ErrorMessage = ErrorMsge.Longitud)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = ErrorMsge.SoloLetras)]

        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsge.Requerido)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMsge.Longitud)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = ErrorMsge.Requerido)]
        [Display (Name = "Documento")]

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten numeros")]
        public string Dni { get; set; }

        [Required(ErrorMessage = ErrorMsge.Requerido)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string ?Profesion  { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre}, {Apellido}";
            }

        }

        //Propiedad Navegacional No obligatoria
        public Direccion ?Direccion { get; set; }


        //Propiedad Navegacional No obligatoria LIST
        public List<Telefono> ?Telefonos { get; set; }

    }
}

