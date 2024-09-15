using _2024_2C_EstacionamientoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Pago
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsge.Requerido)]
        public int EstanciaId { get; set; }

        [Required(ErrorMessage = ErrorMsge.Requerido)]
        public decimal Monto { get; set; }

        public Estancia Estancia { get; set; }
    }
}