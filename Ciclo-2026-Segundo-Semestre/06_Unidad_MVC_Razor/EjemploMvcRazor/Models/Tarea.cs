namespace EjemploMvcRazor.Models
{
    // modelo: representa una tarea de la lista
    public class Tarea
    {
        // identificador unico de la tarea
        public int Id { get; set; }
        // el texto o descripcion de la tarea
        public string Texto { get; set; }
        // indica si la tarea ya esta hecha
        public bool Hecha { get; set; }
    }
}
