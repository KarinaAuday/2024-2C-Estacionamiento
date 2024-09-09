using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Pago
    {
        public int Id { get; set; }

        public int EstanciaId { get; set; }
        public decimal Monto { get; set; }

        public Estancia Estancia { get; set; }
    }
}