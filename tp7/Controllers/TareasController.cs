using Microsoft.AspNetCore.Mvc;
using tp7.AccesoDeDatos;
using tp7.Models;
namespace tp7.Controllers;
//El controlador no debe poseer mucha logica, debe relegar a los metodos de las clases invocadas
[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private readonly ManejoTareas instance;

    private readonly ILogger<TareasController> _logger; //readonly significa q solo se puede modificar en el constructor, despues solo leer

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        var accesoTareas = new AccesoTareas();
        instance = new ManejoTareas(accesoTareas);
    }

    [HttpPost("AddTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        var nuevaTarea = instance.AddTarea(tarea);
        if (nuevaTarea != null) {
            return Ok(tarea);
        }
        else return BadRequest();
    }

    [HttpGet("GetTarea")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        var Tarea = instance.GetTarea(id);
        if (Tarea != null) return Ok(Tarea);
        return BadRequest();
    }

    [HttpPut("UpdateTarea")]
    public ActionResult<Tarea> UpdateTarea(Tarea TareaModificada)
    {
        var Tarea = instance.ActualizarTarea(TareaModificada);
        if (Tarea != null) return Ok(Tarea);
        return BadRequest();
    }

    [HttpDelete("DeleteTarea")]
    public ActionResult BorrarTarea(int idTarea)
    {
        var exito = instance.DeleteTarea(idTarea);
        if (exito) return Ok();
        return BadRequest();
    }

    [HttpGet("ListaTareas")]
    public ActionResult<List<Tarea>> GetListaTareas()
    {
        var tareas = instance.GetListaTareas();
        if (tareas.Count > 0) return Ok(tareas);
        return NoContent();
    } 

    [HttpGet("TareasCompletas")]
    public ActionResult<List<Tarea>> GetTareasCompletas()
    {
        var tareasCompletas = instance.GetTareasCompletas();
        if (tareasCompletas.Count > 0) return Ok(tareasCompletas);
        return NoContent();
    }
}
