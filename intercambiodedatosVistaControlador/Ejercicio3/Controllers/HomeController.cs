using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio3.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // POST: Simula la creación del usuario
        [HttpPost]
        public IActionResult CrearUsuario(Models.UsuarioModel model)
        {

            // 1. Guardamos el mensaje en TempData
            TempData["MensajeExito"] = $"¡Usuario {model.Nombre} creado correctamente!";

            // 2. Redirigimos al listado (Patrón Post-Redirect-Get)
            return RedirectToAction("ListadoUsuarios");
        }

        // GET: La página donde aterrizamos después de crear
        public IActionResult ListadoUsuarios()
        {
            return View();
        }
    }
}
