using Microsoft.EntityFrameworkCore;
using _2024_2C_EstacionamientoORT.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace _2024_2C_EstacionamientoORT.Data
{
    public class EstacionamientoContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>//el Tkey es el ultimo parametro, o pongo como parametro como entero para facilitar la materia. si no lo pone como String 
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
        //Pongo este nombre por que Roles es como una palbra reservada
        public DbSet<Rol> rRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // lo agrego para la precicion en la BD con Fuelt Api.-
            modelBuilder.Entity<Estancia>().Property(est => est.Monto).HasPrecision(38, 18);
            modelBuilder.Entity<Pago>().Property(pag => pag.Monto).HasPrecision(38, 18);
            #region Establecer Nombres para los Identity Stores
            ////Modifico la Entidad Identity User para que guarde en Las tablas que yo quiero
            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            ////Relacion Muchos a Muchos
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");

            #endregion

            #region Unique
            modelBuilder.Entity<Vehiculo>().HasIndex(v => v.Patente).IsUnique();

            #endregion
        }
    }
}
