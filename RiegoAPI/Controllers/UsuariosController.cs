using Microsoft.AspNetCore.Mvc;
using BLL;
using ENTITY;
using RiegoAPI.DTOs.Request;
using RiegoAPI.DTOs.Response;
using RiegoAPI.DTOs.Mappers;

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
        public ActionResult<IEnumerable<UsuarioResponseDTO>> ObtenerTodos()
        {
            var resultado = _serviciosUsuario.ObtenerTodos();

            if (!resultado.Estado)
                return BadRequest(resultado.Mensaje);

            // La propiedad correcta debe ser resultado.Entidades
            var listaDTO = UsuarioMapper.ToResponseDTOList(resultado.Lista);

            return Ok(listaDTO);
        }


        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public ActionResult<UsuarioResponseDTO> ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosUsuario.BuscarPorId(id);

            // ✅ resultado.Entidad contiene el usuario
            if (resultado.Entidad == null)
                return NotFound($"No se encontró usuario con ID {id}");

            return Ok(UsuarioMapper.ToResponseDTO(resultado.Entidad));
        }

        // POST: api/usuarios
        [HttpPost]
        public ActionResult<UsuarioResponseDTO> Insertar([FromBody] UsuarioRequestDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("El usuario no puede ser nulo");

            // Validación de nombre de usuario único
            var existente = _serviciosUsuario.ValidarNombreUsuario(usuarioDTO.NombreUsuario);
            if (existente.Estado)
                return Conflict("El nombre de usuario ya está en uso");

            var entidad = UsuarioMapper.ToEntity(usuarioDTO);

            var resultado = _serviciosUsuario.Insertar(entidad);

            if (!resultado.Estado)
                return BadRequest(resultado.Mensaje);

            var responseDTO = UsuarioMapper.ToResponseDTO(entidad);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.IdUsuario }, responseDTO);
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public ActionResult<UsuarioResponseDTO> Actualizar(int id, [FromBody] UsuarioRequestDTO usuarioDTO)
        {
            if (id != usuarioDTO.IdUsuario)
                return BadRequest("El ID no coincide");

            var entidad = UsuarioMapper.ToEntity(usuarioDTO);

            var resultado = _serviciosUsuario.Actualizar(entidad);

            if (!resultado.Estado)
                return NotFound(resultado.Mensaje);

            return Ok(UsuarioMapper.ToResponseDTO(entidad));
        }

        // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosUsuario.Eliminar(id);

            if (!resultado.Estado)
                return NotFound(resultado.Mensaje);

            return Ok(new { mensaje = "Usuario eliminado correctamente" });
        }

        // POST: api/usuarios/login
        [HttpPost("login")]
        public ActionResult<UsuarioResponseDTO> Login([FromBody] LoginRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.NombreUsuario) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Usuario y contraseña son requeridos");
            }

            var resultado = _serviciosUsuario.ValidarCredenciales(request.NombreUsuario, request.Password);

            if (resultado.Entidad == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            resultado.Entidad.Accedio = true;
            _serviciosUsuario.Actualizar(resultado.Entidad);

            var responseDTO = UsuarioMapper.ToResponseDTO(resultado.Entidad);

            return Ok(responseDTO);
        }

        // POST: api/usuarios/logout/{id}
        [HttpPost("logout/{id}")]
        public ActionResult Logout(int id)
        {
            var resultado = _serviciosUsuario.BuscarPorId(id);

            if (resultado.Entidad == null)
                return NotFound("Usuario no encontrado");

            resultado.Entidad.Accedio = false;
            _serviciosUsuario.Actualizar(resultado.Entidad);

            return Ok(new { mensaje = "Sesión cerrada correctamente" });
        }
    }

    public class LoginRequestDTO
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}
