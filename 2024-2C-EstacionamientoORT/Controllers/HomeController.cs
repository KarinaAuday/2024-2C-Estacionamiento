using _2024_2C_EstacionamientoORT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2024_2C_EstacionamientoORT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1(int? num)
        {
            return View(num);
        }


        public IActionResult Index2()
        {
            List<string> ciudades = new List<string> { "Buenos Aires", "Rosario", "Cordoba", "Mendoza" };
            return View(ciudades);
        }


        public IActionResult ListaNumeros()
        {
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            return View(numeros);
        }
        public IActionResult PasoParametros(int id, string nombreProducto, string descripcion, double precio)
        {
            //Chekeo que recibi los parametros
            if (id > 0 && !String.IsNullOrEmpty(nombreProducto) && !String.IsNullOrEmpty(descripcion))
            {
                //Uso ViewBag
               
                ViewBag.Id = id;
                ViewBag.nombreProducto = nombreProducto;
                //Uso ViewData
                ViewData["descripcion"] = descripcion;
                //Uso TempData
                TempData["Precio"] = precio;
                return View();
            }
            else
            {
                //Paso parametros con El New

                return RedirectToAction("Index", "Home", new { mensajeError = "Faltan datos del Producto" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
