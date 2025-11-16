using Microsoft.AspNetCore.Mvc;

namespace RiegoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Lista simple de usuarios válidos (en memoria)
        private static readonly List<Usuario> UsuariosValidos = new()
        {
            new Usuario { NombreUsuario = "admin", Contrasena = "admin123", Rol = "Administrador" },
            new Usuario { NombreUsuario = "operario", Contrasena = "operario123", Rol = "Operario" },
            new Usuario { NombreUsuario = "usuario", Contrasena = "usuario123", Rol = "Usuario" }
        };

        // Lista para almacenar usuarios registrados
        private static readonly List<UsuarioRegistrado> UsuariosRegistrados = new();

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Usuario) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Usuario y contraseña son requeridos" });
            }

            // Buscar usuario válido
            var usuario = UsuariosValidos.FirstOrDefault(u =>
                u.NombreUsuario.Equals(request.Usuario, StringComparison.OrdinalIgnoreCase) &&
                u.Contrasena == request.Password);

            if (usuario != null)
            {
                return Ok(new
                {
                    success = true,
                    message = "Login exitoso",
                    usuario = usuario.NombreUsuario,
                    rol = usuario.Rol
                });
            }

            // Buscar en usuarios registrados
            var usuarioRegistrado = UsuariosRegistrados.FirstOrDefault(u =>
                u.NombreUsuario.Equals(request.Usuario, StringComparison.OrdinalIgnoreCase) &&
                u.Contrasena == request.Password);

            if (usuarioRegistrado != null)
            {
                return Ok(new
                {
                    success = true,
                    message = "Login exitoso",
                    usuario = usuarioRegistrado.NombreUsuario,
                    rol = usuarioRegistrado.Rol
                });
            }

            return Unauthorized(new { success = false, message = "Usuario o contraseña incorrectos" });
        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] RegistroRequest request)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(request.NombreUsuario))
            {
                return BadRequest(new { message = "El nombre de usuario es requerido" });
            }

            if (string.IsNullOrWhiteSpace(request.Contrasena))
            {
                return BadRequest(new { message = "La contraseña es requerida" });
            }

            // Verificar si el usuario ya existe
            bool usuarioExiste = UsuariosValidos.Any(u =>
                u.NombreUsuario.Equals(request.NombreUsuario, StringComparison.OrdinalIgnoreCase)) ||
                UsuariosRegistrados.Any(u =>
                u.NombreUsuario.Equals(request.NombreUsuario, StringComparison.OrdinalIgnoreCase));

            if (usuarioExiste)
            {
                return BadRequest(new { message = "El nombre de usuario ya está en uso" });
            }

            // Registrar nuevo usuario
            var nuevoUsuario = new UsuarioRegistrado
            {
                Id = UsuariosRegistrados.Count + 1,
                Identificacion = request.Identificacion ?? "",
                NombreCompleto = request.NombreCompleto ?? "",
                Correo = request.Correo ?? "",
                NombreUsuario = request.NombreUsuario,
                Rol = string.IsNullOrWhiteSpace(request.Rol) ? "Usuario" : request.Rol,
                Contrasena = request.Contrasena,
                FechaRegistro = DateTime.Now
            };

            UsuariosRegistrados.Add(nuevoUsuario);

            return Ok(new
            {
                success = true,
                message = "Usuario registrado exitosamente",
                usuario = nuevoUsuario.NombreUsuario
            });
        }

        [HttpGet("usuarios")]
        public IActionResult ObtenerUsuarios()
        {
            var todosLosUsuarios = UsuariosValidos
                .Select(u => new { u.NombreUsuario, u.Rol })
                .Concat(UsuariosRegistrados.Select(u => new { u.NombreUsuario, u.Rol }))
                .ToList();

            return Ok(todosLosUsuarios);
        }
    }

    // Modelos
    public class Usuario
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }

    public class UsuarioRegistrado
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegistroRequest
    {
        public string Identificacion { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}