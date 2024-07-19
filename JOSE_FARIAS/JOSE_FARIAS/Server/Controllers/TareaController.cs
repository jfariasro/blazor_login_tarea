using JOSE_FARIAS.Server.Models;
using JOSE_FARIAS.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JOSE_FARIAS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly JoseFariasContext _context;

        public TareaController(JoseFariasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListarIncompleta")]
        public async Task<IActionResult> ListarIncompletas()
        {
            var lista = new List<TareaDTO>();

            foreach (var item in await _context.Tareas.Where(t => t.Completada == false).ToListAsync())
            {
                lista.Add(new TareaDTO
                {
                    Idtarea = item.Idtarea,
                    Titulo = item.Titulo,
                    Descripcion = item.Descripcion
                });
            }

            return Ok(lista);
        }

        [HttpGet]
        [Route("ListarCompletada")]
        public async Task<IActionResult> ListarCompletada()
        {
            var lista = new List<TareaDTO>();

            foreach (var item in await _context.Tareas.Where(t => t.Completada == true).ToListAsync())
            {
                lista.Add(new TareaDTO
                {
                    Idtarea = item.Idtarea,
                    Titulo = item.Titulo,
                    Descripcion = item.Descripcion
                });
            }

            return Ok(lista);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] TareaDTO tareaDTO)
        {
            try
            {
                var tarea = new Tarea()
                {
                    Idtarea = tareaDTO.Idtarea,
                    Titulo = tareaDTO.Titulo,
                    Descripcion = tareaDTO.Descripcion
                };
                await _context.Tareas.AddAsync(tarea);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] TareaDTO tareaDTO)
        {
            try
            {
                if (id != tareaDTO.Idtarea)
                    return NotFound("No coincide");

                var tarea = await _context.Tareas.FindAsync(id);

                if (tarea == null)
                    return NotFound("No encontrado");

                var model = new Tarea()
                {
                    Idtarea = tareaDTO.Idtarea,
                    Titulo = tareaDTO.Titulo,
                    Descripcion = tareaDTO.Descripcion,
                    FechaCreacion = tarea.FechaCreacion,
                    Completada = tarea.Completada
                };

                _context.Entry(tarea).CurrentValues.SetValues(model);

                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);

                if (tarea == null)
                    return NotFound("No encontrado");

                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("Completar/{id:int}")]
        public async Task<IActionResult> Completar([FromRoute] int id, [FromBody] TareaDTO tareaDTO)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);

                if (tarea == null)
                    return NotFound("No encontrado");

                var model = new Tarea()
                {
                    Idtarea = tareaDTO.Idtarea,
                    Titulo = tareaDTO.Titulo,
                    Descripcion = tareaDTO.Descripcion,
                    FechaCreacion = tarea.FechaCreacion,
                    Completada = true
                };

                _context.Entry(tarea).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

    }
}
