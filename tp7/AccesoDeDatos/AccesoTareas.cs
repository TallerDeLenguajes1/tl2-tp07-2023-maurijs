using System.Text.Json;
using tp7.Models;
namespace tp7.AccesoDeDatos 
{
    public class AccesoTareas 
    {
        private string dataPath = "AccesoDeDatos/tareas.json";
        public  List<Tarea> Obtener()
        {
            if (File.Exists(dataPath))
            {
                try
                {
                    // Lee el contenido del archivo JSON
                    string jsonText = File.ReadAllText(dataPath);

                    // Deserializa el JSON en una lista de objetos Cadete
                    var tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonText);
                    return tareas;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar las tareas desde el archivo JSON: {ex.Message}");
                }
            } 
            
            return null;
        }
        public void Guardar(List<Tarea> tareas)
        {  
            string jsonText = JsonSerializer.Serialize(tareas);
            using (var archivo = new FileStream(dataPath, FileMode.OpenOrCreate))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", jsonText);
                    strWriter.Close();
                }
            }
        }
    }
}