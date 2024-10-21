using _2024_2C_EstacionamientoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = ErrorMsge.Requerido)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = ErrorMsge.NoValido)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMsge.Requerido)]
        [DataType(DataType.Password)]
        [Display(Name = Alias.Password)]
        public string Password { get; set; }


        public bool Recordarme { get; set; } = false;
    }
}
