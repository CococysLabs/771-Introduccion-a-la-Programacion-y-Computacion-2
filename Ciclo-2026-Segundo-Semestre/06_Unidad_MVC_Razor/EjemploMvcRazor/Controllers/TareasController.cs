using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EjemploMvcRazor.Data;
using EjemploMvcRazor.Models;

namespace EjemploMvcRazor.Controllers
{
    // controlador de mvc: devuelve vistas razor (no json).
    // por eso hereda de la clase base de controladores con vistas.
    public class TareasController : Controller
    {
        // referencia al repositorio (los datos del modelo)
        private readonly RepositorioTareas _repo;

        // el repositorio llega por inyeccion de dependencias
        public TareasController(RepositorioTareas repo)
        {
            // guarda el repositorio recibido
            _repo = repo;
        }

        // get /tareas o / : muestra la lista de tareas
        public IActionResult Index()
        {
            // pide todas las tareas al repositorio
            var tareas = _repo.ObtenerTodas();
            // arma el viewmodel con la lista y el conteo de pendientes
            var modelo = new TareasViewModel
            {
                Tareas = tareas,
                // cuenta cuantas no estan hechas
                Pendientes = tareas.Count(t => !t.Hecha)
            };
            // entrega el viewmodel a la vista de inicio
            return View(modelo);
        }

        // post: agrega una tarea enviada desde el formulario
        [HttpPost]
        public IActionResult Agregar(string texto)
        {
            // si llego texto valido, lo agrega
            if (!string.IsNullOrWhiteSpace(texto)) _repo.Agregar(texto);
            // vuelve a la lista (patron post-redirect-get)
            return RedirectToAction("Index");
        }

        // post: marca o desmarca la tarea con ese id
        [HttpPost]
        public IActionResult Alternar(int id)
        {
            // pide al repositorio alternar la tarea
            _repo.Alternar(id);
            // vuelve a la lista
            return RedirectToAction("Index");
        }

        // post: elimina la tarea con ese id
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            // pide al repositorio eliminar la tarea
            _repo.Eliminar(id);
            // vuelve a la lista
            return RedirectToAction("Index");
        }
    }
}
