using _2024_2C_EstacionamientoORT.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2024_2C_EstacionamientoORT.Controllers
{
    public class PruebaPersonas : Controller
    {
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
    }
}
