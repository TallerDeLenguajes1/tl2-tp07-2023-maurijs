namespace tp7.Models
{
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
    public class Tarea
    {
        private int id;
        private string titulo = "titulo";
        private string descripcion;
        private Estado estado;
        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado Estado { get => estado; set => estado = value; }
    }
}