using _2024_2C_EstacionamientoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Empleado : Persona
    {
        [Required(ErrorMessage = ErrorMsge.Requerido)]
        public string CodigoEmpleado { get; set; }

    }
}
