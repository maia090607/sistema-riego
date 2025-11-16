using Microsoft.AspNetCore.Mvc;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Aquí irá tu lógica de autenticación
            if (request.Usuario == "admin" && request.Password == "admin")
            {
                return Ok(new { token = "token_simulado_123" });
            }
            return Unauthorized();
        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] UsuarioRequest request)
        {
            // Aquí irá tu lógica de registro
            return Ok(new { message = "Usuario creado exitosamente" });
        }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UsuarioRequest
    {
        public string Identificacion { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}
