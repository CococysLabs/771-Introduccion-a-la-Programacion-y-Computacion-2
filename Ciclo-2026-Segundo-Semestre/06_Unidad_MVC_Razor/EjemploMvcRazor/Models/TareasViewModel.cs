using System.Collections.Generic;

namespace EjemploMvcRazor.Models
{
    // viewmodel: agrupa justo lo que la vista necesita mostrar
    public class TareasViewModel
    {
        // la lista de tareas que se va a dibujar
        public List<Tarea> Tareas { get; set; }
        // cuantas tareas estan pendientes (sin hacer)
        public int Pendientes { get; set; }
    }
}
