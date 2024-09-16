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


        //Parametro mesnaje de Error
        public IActionResult Index(string  ? mensajeError)
        {
            //Chekeo si recibi un mensaje de error
            if (!String.IsNullOrEmpty(mensajeError))
            {
                ViewBag.MensajeError = mensajeError;
            }
            return View();
        }

        public IActionResult Index1(int? num)
        {

            return View(num);
        }

        public IActionResult Index2()
        {
            List<String> ciudades = new List<String> { "Buenos Aires", "Roma", "Madrid" };
            return View(ciudades);
        }

        public IActionResult ListaNumeros()
        {
            List<int> numerosPares = new List<int> { 2, 4, 6, 8, 10 };
            return View(numerosPares);
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

        //public IActionResult Privacy()
        //{
        //    return View();
        //}public ActionResult UsingTempData()  


        //Paso parametros con TempData de controlador a controlador y luego a la vista
        public ActionResult UsingTempData()

        {
            TempData["Message"] = "Mensaje pasado por TempData ";
            TempData["Nombre"] = "Smartphone";
            TempData["Precio"] = 10000;
            TempData["Id"] = 2;

            //Muestra de Action Result a Action Result
            return RedirectToAction("ShowTempData");
        }

        public ActionResult ShowTempData()
        {
            //Sigue el temp Data de la accion anterior
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
