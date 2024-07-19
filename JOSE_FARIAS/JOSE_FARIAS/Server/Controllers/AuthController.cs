using JOSE_FARIAS.Server.Models;
using JOSE_FARIAS.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JOSE_FARIAS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JoseFariasContext _context;

        public AuthController(JoseFariasContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] UsuarioDTO usuarioDTO)
        {

            Usuario usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Correo == usuarioDTO.Correo && u.Clave == usuarioDTO.Clave);

            if(usuario == null)
                return BadRequest("Error");

            var sesion = new SesionDTO
            {
                Nombre = usuario.Nombre!,
                Correo = usuarioDTO.Correo
            };

            return StatusCode(StatusCodes.Status200OK, sesion);
        }
    }
}
