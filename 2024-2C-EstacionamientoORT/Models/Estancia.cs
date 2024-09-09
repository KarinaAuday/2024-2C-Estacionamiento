using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Estancia
    {
        public int Id { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public Cliente Cliente { get; set; }

        public decimal Monto { get; private set; }

     
        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }

        public Pago pago { get; set; }
    }
}
