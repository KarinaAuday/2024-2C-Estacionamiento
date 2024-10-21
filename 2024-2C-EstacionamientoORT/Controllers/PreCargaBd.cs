using _2024_2C_EstacionamientoORT.Data;
using _2024_2C_EstacionamientoORT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using _2024_2C_EstacionamientoORT.Helpers;

namespace _2024_2C_EstacionamientoORT.Controllers
{
    public class PreCargaBd : Controller
    {
        private readonly EstacionamientoContext _context;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly List<string> roles = new List<string>() { Configs.EmpleadoRolName, Configs.ClienteRolName, Configs.AdminRolName };
        public PreCargaBd(UserManager<Persona> userManager, RoleManager<Rol> roleManager, EstacionamientoContext context)
        { //Agrego usario y roles
            this._userManager = userManager;
            this._roleManager = roleManager;
            _context = context;

        }




        private List<Persona> personas = new List<Persona>()
        {
             new Persona() { Nombre = "Luis", Apellido = "Spinetta", Dni = "22334455", Email = "LSpinetta@gmail.com" },
             new Persona() { Nombre = "Chaly", Apellido = "Garcia", Dni = "22374455", Email = "Cgarcia@gmail.com" },
             new Persona() { Nombre = "Gustavo", Apellido = "Cerati", Dni = "12374455", Email = "Cerati@gmail.com" },
             new Persona() { Nombre = "Astor", Apellido = "Piazolla", Dni = "22884455", Email = "¨Piazolla@gmail.com" },
             new Persona() { Nombre = "Miguel", Apellido = "Mateos", Dni = "26374455", Email = "¨Mateos@gmail.com" }
         };

        //Creo listas con Datos
        private List<Empleado> empleados = new List<Empleado>()
        {
            new Empleado
            {
                Dni = "22334455",
                Nombre = "Juan",
                Apellido = "Perez",
                Email = "Juan@gmail.com",
                CodigoEmpleado = "1234"
            },
           new Empleado
            {
                Dni = "33445566",
                Nombre = "Maria",
                Apellido = "Gomez",
                Email = "Maria@gmail.com",
                CodigoEmpleado = "2345"
            },
            new Empleado
            {
                Dni = "44444444",
                Nombre = "ALberto",
                Apellido = "Fernandez",
                Email = "Albert@gmail.com",
                CodigoEmpleado = "3456"
            },
             new Empleado
            {
                Dni = "23456789",
                Nombre = "Karina",
                Apellido = "Auday",
                Email = "kariauday@gmail.com",
                CodigoEmpleado = "3459"
            },
        };
        #region Lista de Vehiculos
        private List<Vehiculo> vehiculos = new List<Vehiculo>()
        {
            new Vehiculo(2034444,"Ford taunus" , "Verde"),
            new Vehiculo(8484848, "Renault Clio" , "Azul") ,
            new Vehiculo(5647866, "Mercedes benz" , "amarillo"),
        };
        #endregion

        #region InicializarClientes OLD
        //private void IncializarClientes()
        //{
        //    if (!_context.Clientes.Any())
        //    {

        //        Cliente cliente = new Cliente()
        //        {
        //            Nombre = "Charly",
        //            Apellido = "Garcia",
        //            Dni = "22334455",
        //            Email = "charly@ort.edu.ar",
        //            Cuil = 55997788

        //        };
        //        _context.Clientes.Add(cliente);
        //        _context.SaveChanges();


        //        Direccion direccion = new Direccion()

        //        {
        //            Calle = "Mansilla 345",
        //            CodPostal = 1425,
        //            //Le asigno el Id del Cliente para que sea su direccion asociada 
        //            PersonaId = cliente.Id
        //        };
        //        _context.Direccion.Add(direccion);
        //        _context.SaveChanges();


        //        Cliente cliente2 = new Cliente()
        //        {

        //            Nombre = "Luis",
        //            Apellido = "Alberto Spinetta",
        //            Dni = "55228788",
        //            Email = "LASy@ort.edu.ar",
        //            Cuil = 55667788
        //        };

        //        _context.Clientes.Add(cliente2);
        //        _context.SaveChanges();

        //        Direccion direccion2 = new Direccion()

        //        {
        //            Calle = "Charcas",
        //            CodPostal = 1425,
        //            PersonaId = cliente2.Id
        //        };

        //        _context.Direccion.Add(direccion2);
        //        _context.SaveChanges();

        //        Cliente cliente3 = new Cliente()
        //        { Nombre = "Gustavo", Apellido = "Cerati", Dni = "66228788", Email = "Cerati@gmail.com", Cuil = 55667777 };

        //        _context.Clientes.Add(cliente3);
        //        _context.SaveChanges();

        //        Direccion direccion3 = new Direccion()

        //        {
        //            Calle = "Callao",
        //            CodPostal = 1425,
        //            PersonaId = cliente3.Id
        //        };

        //        _context.Direccion.Add(direccion3);
        //        _context.SaveChanges();


        //        Cliente cliente4 = new Cliente() { Nombre = "Astor", Apellido = "Piazolla", Dni = "57728788", Email = "Piazolla@gmail.com", Cuil = 55007777 };


        //        _context.Clientes.Add(cliente4);
        //        _context.SaveChanges();

        //        Direccion direccion4 = new Direccion()

        //        {
        //            Calle = "Corrientes",
        //            CodPostal = 1425,
        //            PersonaId = cliente4.Id
        //        };

        //        _context.Direccion.Add(direccion4);
        //        _context.SaveChanges();

        //        Cliente cliente5 = new Cliente() { Nombre = "Miguel", Apellido = "Mateos", Dni = "87728788", Email = "Mateos@gmail.com", Cuil = 66007777 };

        //        _context.Clientes.Add(cliente5);
        //        _context.SaveChanges();

        //        Direccion direccion5 = new Direccion()

        //        {
        //            Calle = "San Juan",
        //            CodPostal = 1425,
        //            PersonaId = cliente5.Id
        //        };

        //        _context.Direccion.Add(direccion5);
        //        _context.SaveChanges();

        //        Cliente cliente6 = new Cliente() { Nombre = "Juan Carlos", Apellido = "Baglietto", Dni = "97528788", Email = "Baglieto@gmail.com", Cuil = 55009999 };
        //        _context.Clientes.Add(cliente6);
        //        _context.SaveChanges();


        //        Direccion direccion6 = new Direccion()

        //        {
        //            Calle = "San Juan",
        //            CodPostal = 1425,
        //            PersonaId = cliente6.Id
        //        };

        //        _context.Direccion.Add(direccion6);
        //        _context.SaveChanges();

        //    }
        //}
        #endregion InicializarClientes OLD

        #region InicializarClientes
        private async Task IncializarClientes()
        {
            //if (!_context.Clientes.Any())
            //{

                Cliente cliente = new Cliente()
                {
                    Nombre = "Charly",
                    Apellido = "Garcia",
                    Dni = "55997788",
                    Email = "charly@ort.edu.ar",
                    Cuil = 55997788

                };
                cliente.UserName = cliente.Email;
                await _userManager.CreateAsync(cliente, Configs.PasswordGenerica);
                

            Direccion direccion = new Direccion()

                {
                    Calle = "Mansilla",
                    CodPostal = 1425,
                    PersonaId = cliente.Id
                };

                _context.Direccion.Add(direccion);
                _context.SaveChanges();

                Cliente cliente2 = new Cliente()
                {

                    Nombre = "Luis",
                    Apellido = "Alberto Spinetta",
                    Dni = "55228788",
                    Email = "LASy@ort.edu.ar",
                    Cuil = 55667788
                };
                cliente2.UserName = cliente2.Email;
                await _userManager.CreateAsync(cliente2, Configs.PasswordGenerica);
                await _userManager.AddToRoleAsync(cliente2, "Cliente");

                Direccion direccion2 = new Direccion()

                {
                    Calle = "Charcas",
                    CodPostal = 1425,
                    PersonaId = cliente2.Id
                };

                _context.Direccion.Add(direccion2);
                _context.SaveChanges();

                Cliente cliente3 = new Cliente()
                { Nombre = "Gustavo", Apellido = "Cerati", Dni = "66228788", Email = "Cerati@gmail.com", Cuil = 55667777 };
                cliente3.UserName = cliente3.Email;
                await _userManager.CreateAsync(cliente3, Configs.PasswordGenerica);
                await _userManager.AddToRoleAsync(cliente3, "Cliente");

                Direccion direccion3 = new Direccion()

                {
                    Calle = "Callao",
                    CodPostal = 1425,
                    PersonaId = cliente3.Id
                };

                _context.Direccion.Add(direccion3);
                _context.SaveChanges();




                Cliente cliente4 = new Cliente() { Nombre = "Astor", Apellido = "Piazolla", Dni = "57728788", Email = "Piazolla@gmail.com", Cuil = 55007777 };
                cliente4.UserName = cliente4.Email;
                await _userManager.CreateAsync(cliente4, Configs.PasswordGenerica);
                await _userManager.AddToRoleAsync(cliente4, "Cliente");

                Direccion direccion4 = new Direccion()

                {
                    Calle = "Corrientes",
                    CodPostal = 1425,
                    PersonaId = cliente4.Id
                };

                _context.Direccion.Add(direccion4);
                _context.SaveChanges();

                Cliente cliente5 = new Cliente() { Nombre = "Miguel", Apellido = "Mateos", Dni = "87728788", Email = "Mateos@gmail.com", Cuil = 66007777 };
                cliente5.UserName = cliente5.Email;
                await _userManager.CreateAsync(cliente5, Configs.PasswordGenerica);
                await _userManager.AddToRoleAsync(cliente5, "Cliente");
                Direccion direccion5 = new Direccion()

                {
                    Calle = "San Juan",
                    CodPostal = 1425,
                    PersonaId = cliente5.Id
                };

                _context.Direccion.Add(direccion5);
                _context.SaveChanges();

                Cliente cliente6 = new Cliente() { Nombre = "Juan Carlos", Apellido = "Baglietto", Dni = "97528788", Email = "Baglieto@gmail.com", Cuil = 55009999 };
                cliente6.UserName = cliente6.Email;
                await _userManager.CreateAsync(cliente6, Configs.PasswordGenerica);
                await _userManager.AddToRoleAsync(cliente6, "Cliente");

                Direccion direccion6 = new Direccion()

                {
                    Calle = "San Juan",
                    CodPostal = 1425,
                    PersonaId = cliente6.Id
                };

                _context.Direccion.Add(direccion6);
                _context.SaveChanges();
                //_context.Cliente.Add(cliente6);
                //_context.SaveChanges();
            //}
        }

        #endregion InicializarClientes

        public IActionResult InicializarBD()
        {
            CrearRoles().Wait();
            //IncializarClientes().Wait();
            //IncializarPersonas().Wait();
            CrearPersonas().Wait();
            CrearEmpleados().Wait();
            CrearVehiculos();
            //Mando como parametro un mensage para mostrar en la vista con ViewBag
            TempData["PrecargaOK"] = "PreCarga de Base de Datos finalizada";
            return RedirectToAction("Index", "Home");
        }

        private async Task IncializarPersonas()
        {

            Persona persona1 = new Persona() { Nombre = "Luis", Apellido = "Spinetta", Dni = "22334455", Email = "LSpinetta@gmail.com" };
            persona1.UserName = persona1.Email;
            await _userManager.CreateAsync(persona1, Configs.PasswordGenerica);
            await _userManager.AddToRoleAsync(persona1, "Cliente");

            Direccion direccion1 = new Direccion()

            {
                Calle = "Corrientes",
                CodPostal = 1425,
                PersonaId = persona1.Id
            };

            _context.Direccion.Add(direccion1);
            _context.SaveChanges();

            Persona persona2 = new Persona() { Nombre = "Chaly", Apellido = "Garcia", Dni = "22374455", Email = "Cgarcia@gmail.com" };
            persona2.UserName = persona2.Email;
            await _userManager.CreateAsync(persona2, Configs.PasswordGenerica);
            await _userManager.AddToRoleAsync(persona2, "Cliente");

            Direccion direccion2 = new Direccion()

            {
                Calle = "Mansilla",
                CodPostal = 1475,
                PersonaId = persona2.Id
            };

            _context.Direccion.Add(direccion2);
            _context.SaveChanges();
            //new Persona() { Nombre = "Chaly", Apellido = "Garcia", Dni = "22374455", Email = "Cgarcia@gmail.com" },
            //new Persona() { Nombre = "Gustavo", Apellido = "Cerati", Dni = "12374455", Email = "Cerati@gmail.com" },
            //new Persona() { Nombre = "Astor", Apellido = "Piazolla", Dni = "22884455", Email = "¨Piazolla@gmail.com" },
            //new Persona() { Nombre = "Miguel", Apellido = "Mateos", Dni = "26374455", Email = "¨Mateos@gmail.com" }


        }

        private void CrearVehiculos()
        {
            foreach (var vehiculo in vehiculos)
            {
                if (!_context.Vehiculos.Any(e => e.Patente == vehiculo.Patente))
                {
                    _context.Vehiculos.Add(vehiculo);
                    _context.SaveChanges();
                }

            }
        }

        private async Task CrearRoles()
        {
            foreach (var rolName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(rolName))
                {
                    await _roleManager.CreateAsync(new Rol(rolName));
                }
            }
        }
        private async Task CrearPersonas()
        {
            foreach (var persona in personas)
            {
                //Valido que no tenga el DNI cargado
                //if (!_context.Personas.Any(e => e.Dni == persona.Dni))
                //{
                    persona.UserName = persona.Email;
                    await _userManager.CreateAsync(persona, Configs.PasswordGenerica);
                    await _userManager.AddToRoleAsync(persona, "Cliente");
                //}

            }
        }

        private async Task CrearEmpleados()
        {
            foreach (var empleado in empleados)
            {
                if (!_context.Empleado.Any(e => e.Email == empleado.Email))
                {
                    empleado.UserName = empleado.Email;
                    if (empleado.Apellido.Equals("Auday"))
                    {

                        await _userManager.CreateAsync(empleado, Configs.PasswordGenerica);
                        await _userManager.AddToRoleAsync(empleado, "Admin");
                    }
                    else
                    {
                        await _userManager.CreateAsync(empleado, Configs.PasswordGenerica);
                        await _userManager.AddToRoleAsync(empleado, "Empleado");
                    }
                }

            }
            //private void CrearEmpleados()
            //{
            //    foreach (var empleado in empleados)
            //    {
            //        if (!_context.Empleado.Any(e => e.Dni == empleado.Dni))
            //        {
            //            _context.Empleado.Add(empleado);
            //            _context.SaveChanges();
            //        }

            //    }
            //}
        }
    }
}
