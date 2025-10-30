using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVCSencilla.Models;

namespace WebMVCSencilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // La acci�n Index() manejar� la solicitud HTTP GET a la p�gina de inicio.
        public IActionResult Index()
        {
            // 1. Crear y poblar la colecci�n
            List<Estudiante> listaEstudiantes = new List<Estudiante>
            {
                new Estudiante { Id = 1, Nombre = "Ana Garc�a", Curso = "C# B�sico", Edad = 20 },
                new Estudiante { Id = 2, Nombre = "Luis P�rez", Curso = "ASP.NET Core", Edad = 22 },
                new Estudiante { Id = 3, Nombre = "Marta Ruiz", Curso = "MVC", Edad = 21 }
            };

            // 2. Pasar la colecci�n a la Vista (`Index.cshtml`)
            // En MVC, el objeto se pasa como argumento del m�todo View().
            return View(listaEstudiantes);
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
    }
}
