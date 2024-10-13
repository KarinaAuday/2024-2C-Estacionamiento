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
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<ClienteVehiculo> ClientesVehiculos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Estancia> Estancia { get; set; }
        public DbSet<Empleado> Empleado { get; set; }

    }
}
