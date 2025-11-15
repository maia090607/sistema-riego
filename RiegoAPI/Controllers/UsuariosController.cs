using Microsoft.AspNetCore.Mvc;
using BLL;
using ENTITY;
using DAL;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ServiciosUsuario _serviciosUsuario;

        public UsuariosController(ServiciosUsuario serviciosUsuario)
        {
            _serviciosUsuario = serviciosUsuario;
        }

        // GET: api/usuarios
        [HttpGet]
        public ActionResult<Response<Usuario>> ObtenerTodos()
        {
            var resultado = _serviciosUsuario.ObtenerTodos();
            return Ok(resultado);
        }

        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public ActionResult<Response<Usuario>> ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosUsuario.BuscarPorId(id);

            if (resultado.Entidad == null)
                return NotFound($"No se encontró usuario con ID {id}");

            return Ok(resultado);
        }

        // POST: api/usuarios
        [HttpPost]
        public ActionResult<Response<Usuario>> Insertar([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("El usuario no puede ser nulo");

            var existente = _serviciosUsuario.ValidarNombreUsuario(usuario.NombreUsuario);
            if (existente.Estado)
                return Conflict("El nombre de usuario ya existe");

            var resultado = _serviciosUsuario.Insertar(usuario);

            if (resultado.Estado)
                return CreatedAtAction(nameof(ObtenerPorId), new { id = usuario.IdUsuario }, resultado);

            return BadRequest(resultado.Mensaje);
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public ActionResult<Response<Usuario>> Actualizar(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
                return BadRequest("El ID no coincide");

            var resultado = _serviciosUsuario.Actualizar(usuario);

            if (resultado.Estado)
                return Ok(resultado);

            return NotFound(resultado.Mensaje);
        }

        // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public ActionResult<Response<Usuario>> Eliminar(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosUsuario.Eliminar(id);

            if (resultado.Estado)
                return Ok(resultado);

            return NotFound(resultado.Mensaje);
        }

        // POST: api/usuarios/login
        [HttpPost("login")]
        public ActionResult<Response<Usuario>> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NombreUsuario) ||
                string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Usuario y contraseña son requeridos");

            var resultado = _serviciosUsuario.ValidarCredenciales(request.NombreUsuario, request.Password);

            if (resultado.Entidad != null)
            {
                resultado.Entidad.Accedio = true;
                _serviciosUsuario.Actualizar(resultado.Entidad);
                return Ok(resultado);
            }

            return Unauthorized("Usuario o contraseña incorrectos");
        }

        // POST: api/usuarios/logout
        [HttpPost("logout/{id}")]
        public ActionResult<Response<Usuario>> Logout(int id)
        {
            var usuario = _serviciosUsuario.BuscarPorId(id);
            if (usuario.Entidad != null)
            {
                usuario.Entidad.Accedio = false;
                _serviciosUsuario.Actualizar(usuario.Entidad);
                return Ok(new { mensaje = "Sesión cerrada correctamente" });
            }
            return NotFound("Usuario no encontrado");
        }
    }

    public class LoginRequest
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}
