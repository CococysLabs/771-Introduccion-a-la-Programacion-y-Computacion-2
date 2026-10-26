using System.Collections.Generic;
using System.Linq;
using EjemploMvcRazor.Models;

namespace EjemploMvcRazor.Data
{
    // repositorio: guarda las tareas en memoria y ofrece las operaciones.
    // es parte del modelo; se registra como singleton para que los datos duren.
    public class RepositorioTareas
    {
        // lista con dos tareas de ejemplo al iniciar
        private readonly List<Tarea> _tareas = new List<Tarea>
        {
            // primera tarea, sin hacer
            new Tarea { Id = 1, Texto = "Estudiar Razor", Hecha = false },
            // segunda tarea, ya hecha
            new Tarea { Id = 2, Texto = "Repasar C#", Hecha = true }
        };
        // guarda el siguiente id disponible
        private int _siguienteId = 3;

        // devuelve todas las tareas
        public List<Tarea> ObtenerTodas()
        {
            // entrega la lista completa
            return _tareas;
        }

        // agrega una tarea nueva con el texto recibido
        public void Agregar(string texto)
        {
            // crea la tarea con el id actual y la agrega a la lista
            _tareas.Add(new Tarea { Id = _siguienteId, Texto = texto, Hecha = false });
            // aumenta el id para la proxima tarea
            _siguienteId++;
        }

        // cambia una tarea de hecha a no hecha
        public void Alternar(int id)
        {
            // busca la tarea por su id
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            // si existe, invierte su estado
            if (tarea != null) tarea.Hecha = !tarea.Hecha;
        }

        // elimina la tarea con el id indicado
        public void Eliminar(int id)
        {
            // quita de la lista las tareas con ese id
            _tareas.RemoveAll(t => t.Id == id);
        }
    }
}
