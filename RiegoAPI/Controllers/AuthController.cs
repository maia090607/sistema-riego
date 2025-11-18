using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTOs.Request;
using RiegoAPI.DTOs.Response;
using static System.Net.WebRequestMethods;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            // Aquí irá tu lógica de autenticación
            if (request.NombreUsuario == "admin" && request.Password == "admin123")
            {
                return Ok(new { token = "token_simulado_123" });
            }
            return Unauthorized();
        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] UsuarioRequestDTO request)
        {
            // Aquí irá tu lógica de registro
            return Ok(new { message = "Usuario creado exitosamente" });
        }
    }
}
