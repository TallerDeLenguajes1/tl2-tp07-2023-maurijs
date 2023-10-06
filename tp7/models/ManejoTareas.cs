using tp7.AccesoDeDatos;
using tp7.Controllers;

namespace tp7.Models
{
    public class ManejoTareas
    {
        private AccesoTareas accesoTareas;

        public ManejoTareas(AccesoTareas accesoTareas)
        {
            this.accesoTareas = accesoTareas;
            //accesoTareas = new AccesoTareas(); No se recomienda de esta forma por buenas practicas
        }
        public Tarea AddTarea(Tarea tarea)
        {
            var tareas = accesoTareas.Obtener();
            tareas.Add(tarea);
            tarea.Id = tareas.Count;
            accesoTareas.Guardar(tareas);
            return tarea;
        }   

        public bool DeleteTarea(int idTarea)
        {
            var tareas = accesoTareas.Obtener();
            var tarea = tareas.FirstOrDefault(tarea => tarea.Id == idTarea); // Simliar al find().  FindAll() devuelve una lista 
            bool result = false;
            if (tarea != null) // control necesario
            {
                result = tareas.Remove(tarea);
                if (result) 
                {
                    accesoTareas.Guardar(tareas);
                }
            }
            return result;
        }

        public Tarea GetTarea(int id)
        {
            var tareas = accesoTareas.Obtener();
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            return tarea; 
        }

        public Tarea ActualizarTarea(Tarea actual)
        {
            var tareas = accesoTareas.Obtener();
            var tarea = tareas.FirstOrDefault(t => t.Id == actual.Id);
            if (tarea != null)
            {
                tarea.Descripcion = actual.Descripcion;
                tarea.Estado = actual.Estado;
                tarea.Titulo = actual.Titulo;
            }
            accesoTareas.Guardar(tareas);
            return tarea;
        }

        public List<Tarea> GetListaTareas()
        {
            var tareas = accesoTareas.Obtener();
            return tareas;
        }

        public List<Tarea> GetTareasCompletas()
        {
            var TareasCompletas = new List<Tarea>();
            var tareas = accesoTareas.Obtener();
            foreach (var t in tareas)
            {
                if (t.Estado == Estado.Completada)
                {
                    TareasCompletas.Add(t);
                }
            }
            return TareasCompletas;
        }
    }
}