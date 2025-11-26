using System.Diagnostics;
using intercambiodedatosVistaControlador.Models;
using Microsoft.AspNetCore.Mvc;

namespace intercambiodedatosVistaControlador.Controllers
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
        public IActionResult Perfil()
        {
            PerfilViewModel pvm = new PerfilViewModel("Rafa", "Rafita@gmail", true);
            ViewBag.TituloPagina = "Mi perfil de usuario";
            ViewData["FechaActual"]= DateTime.Now.ToShortDateString();

            return View(pvm);
        }
    }

}
