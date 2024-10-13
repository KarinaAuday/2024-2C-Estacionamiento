using _2024_2C_EstacionamientoORT.Data;
using _2024_2C_EstacionamientoORT.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2024_2C_EstacionamientoORT.Controllers
{
    public class PruebaPersonas : Controller
    {
        //Creo un DB context. Fuerzo a recibir un contexto de base de datos
        private readonly EstacionamientoContext _contexto;

        public PruebaPersonas(EstacionamientoContext contexto)
        {
            this._contexto = contexto;
        }
        public IActionResult Index()
        {

            return View();
        }
        //Creo Persona con Get
        public ActionResult CreateGet()   //Ejemplo Con Get
        {

            return View();

        }
        //Creo Persona con Post
        public ActionResult CreatePost() //Ejemplo con Post
        {

            return View();

        }
        //Creo persona con query string
        public IActionResult CrearPersona(string nombre, string apellido, string dni, string email)
        {

            Persona persona = new Persona()

            {
                Apellido = apellido,
                Dni = dni,
                Nombre = nombre,
                Email = email
            };

            return View(persona);

        }

        public IActionResult RepoPersonas()
        {
            //  creo las Personas que traigo de la DB y la hago tolist

            //List<Persona> Personas = _contexto.Personas.ToList();

            var personas = new RepoPersonas();
            //lista de personas

            //////Lo guardo uno a uno en la base de datos , pero no va a funcionar por que no tiene todas las propiedades
            foreach (Persona persona in personas.Personas)
            {
                _contexto.Add(persona);
                _contexto.SaveChanges();
            }



            // return View(personas.Personas);



            return View(_contexto.Personas);
        }
    }
}
