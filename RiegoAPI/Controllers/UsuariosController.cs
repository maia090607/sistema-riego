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
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(ServiciosUsuario serviciosUsuario, ILogger<UsuariosController> logger)
        {
            _serviciosUsuario = serviciosUsuario;
            _logger = logger;
        }

        // GET: api/usuarios
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioResponseDTO>> ObtenerTodos()
        {
            try
            {
                _logger.LogInformation("📋 Obteniendo todos los usuarios...");

                var resultado = _serviciosUsuario.ObtenerTodos();

                if (!resultado.Estado)
                    return BadRequest(resultado.Mensaje);

                var listaDTO = UsuarioMapper.ToResponseDTOList(resultado.Lista);

                _logger.LogInformation($"✅ {listaDTO.Count} usuarios encontrados");

                return Ok(listaDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public ActionResult<UsuarioResponseDTO> ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("El ID debe ser mayor a cero");

                var resultado = _serviciosUsuario.BuscarPorId(id);

                if (resultado.Entidad == null)
                    return NotFound($"No se encontró usuario con ID {id}");

                return Ok(UsuarioMapper.ToResponseDTO(resultado.Entidad));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // POST: api/usuarios
        [HttpPost]
        public ActionResult<UsuarioResponseDTO> Insertar([FromBody] UsuarioRequestDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return BadRequest("El usuario no puede ser nulo");

                _logger.LogInformation($"📝 Creando usuario: {usuarioDTO.NombreUsuario}");

                // ✅ Validar que el nombre de usuario no exista
                var existente = _serviciosUsuario.ValidarNombreUsuario(usuarioDTO.NombreUsuario);
                if (existente.Estado && existente.Entidad != null)
                {
                    _logger.LogWarning($"⚠️ Usuario {usuarioDTO.NombreUsuario} ya existe");
                    return Conflict("El nombre de usuario ya está en uso");
                }

                // ✅ Validar que el ID (cédula) no exista
                var existenteId = _serviciosUsuario.BuscarPorId(usuarioDTO.IdUsuario);
                if (existenteId.Estado && existenteId.Entidad != null)
                {
                    _logger.LogWarning($"⚠️ ID {usuarioDTO.IdUsuario} ya existe");
                    return Conflict("El ID de usuario ya está en uso");
                }

                var entidad = UsuarioMapper.ToEntity(usuarioDTO);
                var resultado = _serviciosUsuario.Insertar(entidad);

                if (!resultado.Estado)
                {
                    _logger.LogError($"❌ Error al insertar: {resultado.Mensaje}");
                    return BadRequest(resultado.Mensaje);
                }

                var responseDTO = UsuarioMapper.ToResponseDTO(entidad);

                _logger.LogInformation($"✅ Usuario {usuarioDTO.NombreUsuario} creado con ID {entidad.IdUsuario}");

                return CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.IdUsuario }, responseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Excepción: {ex.Message}");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public ActionResult<UsuarioResponseDTO> Actualizar(int id, [FromBody] UsuarioRequestDTO usuarioDTO)
        {
            try
            {
                if (id != usuarioDTO.IdUsuario)
                    return BadRequest("El ID no coincide");

                var entidad = UsuarioMapper.ToEntity(usuarioDTO);
                var resultado = _serviciosUsuario.Actualizar(entidad);

                if (!resultado.Estado)
                    return NotFound(resultado.Mensaje);

                return Ok(UsuarioMapper.ToResponseDTO(entidad));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("El ID debe ser mayor a cero");

                var resultado = _serviciosUsuario.Eliminar(id);

                if (!resultado.Estado)
                    return NotFound(resultado.Mensaje);

                return Ok(new { mensaje = "Usuario eliminado correctamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // POST: api/usuarios/login
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.NombreUsuario) ||
                    string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Usuario y contraseña son requeridos"
                    });
                }

                _logger.LogInformation($"🔐 Intento de login: {request.NombreUsuario}");

                var resultado = _serviciosUsuario.ValidarCredenciales(request.NombreUsuario, request.Password);

                if (resultado.Entidad == null)
                {
                    _logger.LogWarning($"❌ Login fallido para: {request.NombreUsuario}");
                    return Ok(new
                    {
                        success = false,
                        message = "Usuario o contraseña incorrectos"
                    });
                }

                // ✅ Marcar como conectado
                resultado.Entidad.Accedio = true;
                _serviciosUsuario.Actualizar(resultado.Entidad);

                var responseDTO = UsuarioMapper.ToResponseDTO(resultado.Entidad);

                _logger.LogInformation($"✅ Login exitoso: {request.NombreUsuario}");

                return Ok(new
                {
                    success = true,
                    message = "Login exitoso",
                    data = responseDTO
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error en login: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno del servidor"
                });
            }
        }

        // POST: api/usuarios/logout/{id}
        [HttpPost("logout/{id}")]
        public ActionResult Logout(int id)
        {
            try
            {
                var resultado = _serviciosUsuario.BuscarPorId(id);

                if (resultado.Entidad == null)
                    return NotFound("Usuario no encontrado");

                resultado.Entidad.Accedio = false;
                _serviciosUsuario.Actualizar(resultado.Entidad);

                _logger.LogInformation($"🚪 Logout: {resultado.Entidad.NombreUsuario}");

                return Ok(new { mensaje = "Sesión cerrada correctamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error en logout: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}