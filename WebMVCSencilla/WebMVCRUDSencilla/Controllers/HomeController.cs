using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCRUDSencilla.Models;

namespace WebMVCRUDSencilla.Controllers
{
    public class HomeController : Controller
    {
        // **Nueva Colecci�n Est�tica:** Simula la Base de Datos.
        // Se inicializa una sola vez cuando la clase se carga.
        private static List<Estudiante> _listaEstudiantes = new List<Estudiante>
        {
            new Estudiante { Id = 1, Nombre = "Ana Garc�a", Curso = "C# B�sico", Edad = 20 },
            new Estudiante { Id = 2, Nombre = "Luis P�rez", Curso = "ASP.NET Core", Edad = 22 },
            new Estudiante { Id = 3, Nombre = "Marta Ruiz", Curso = "MVC", Edad = 21 }
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Ahora devolvemos la lista est�tica
            return View(_listaEstudiantes);
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
        public IActionResult Crear()
        {
            // Simplemente devuelve una vista vac�a para el formulario
            return View();
        }
        // C: Create (Procesar Formulario - POST)
        [HttpPost] // Indica que solo maneja solicitudes POST
        [ValidateAntiForgeryToken] // Buena pr�ctica de seguridad
        public IActionResult Crear(Estudiante nuevoEstudiante)
        {
            if (ModelState.IsValid) // Verifica si el modelo cumple las reglas
            {
                // 1. Asignar un nuevo ID
                int nextId = _listaEstudiantes.Any() ? _listaEstudiantes.Max(e => e.Id) + 1 : 1;
                nuevoEstudiante.Id = nextId;

                // 2. A�adir a la "base de datos" (la lista est�tica)
                _listaEstudiantes.Add(nuevoEstudiante);

                // 3. Redirigir al listado (patr�n PRG - Post/Redirect/Get)
                return RedirectToAction(nameof(Index));
            }
            // Si el modelo no es v�lido, vuelve a mostrar el formulario con los datos ingresados
            return View(nuevoEstudiante);
        }

        // U: Update (Mostrar Formulario de Edici�n - GET)
        // URL: /Home/Editar/5
        public IActionResult Editar(int id)
        {
            // 1. Buscar el estudiante por ID en la lista est�tica
            var estudianteAEditar = _listaEstudiantes.FirstOrDefault(e => e.Id == id);

            if (estudianteAEditar == null)
            {
                // Si no se encuentra, podr�as redirigir a un error o al Index
                return NotFound(); // Retorna un c�digo de estado 404
            }

            // 2. Devolver la vista, pasando el objeto encontrado
            return View(estudianteAEditar);
        }

        // U: Update (Procesar Formulario de Edici�n - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Estudiante estudianteConCambios)
        {
            // El 'estudianteConCambios' llega con el Id y los nuevos datos del formulario.
            if (ModelState.IsValid)
            {
                // 1. Buscar el �ndice del estudiante original en la lista est�tica
                var index = _listaEstudiantes.FindIndex(e => e.Id == estudianteConCambios.Id);

                if (index != -1)
                {
                    // 2. Reemplazar el objeto existente con el objeto actualizado del formulario
                    _listaEstudiantes[index] = estudianteConCambios;

                    // 3. Redirigir al listado
                    return RedirectToAction(nameof(Index));
                }
                // Si no se encuentra, a�n as� devolvemos la vista con un mensaje de error o 404
                return NotFound();
            }

            // Si el modelo no es v�lido, vuelve a mostrar el formulario de edici�n
            return View(estudianteConCambios);
        }
        // D: Delete (Eliminar por ID - POST)
        // Usamos [HttpPost] y el par�metro 'id' para evitar que se elimine con una simple URL GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            // 1. Buscar el estudiante en la lista est�tica
            var estudianteAEliminar = _listaEstudiantes.FirstOrDefault(e => e.Id == id);

            if (estudianteAEliminar != null)
            {
                // 2. Eliminar el estudiante
                _listaEstudiantes.Remove(estudianteAEliminar);
            }

            // 3. Redirigir al listado actualizado
            return RedirectToAction(nameof(Index));
        }


    }
}
