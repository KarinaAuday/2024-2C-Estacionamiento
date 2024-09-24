using Microsoft.EntityFrameworkCore;
using _2024_2C_EstacionamientoORT.Models;

namespace _2024_2C_EstacionamientoORT.Data
{
    public class EstacionamientoContext : DbContext
    {
        public EstacionamientoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
    }
}
