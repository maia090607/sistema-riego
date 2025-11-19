using BLL;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTO.Mappers;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumedadController : ControllerBase
    {
        private readonly ServiciosHumedad _serviciosHumedad;
        private readonly ILogger<HumedadController> _logger;

        public HumedadController(ServiciosHumedad serviciosHumedad, ILogger<HumedadController> logger)
        {
            _serviciosHumedad = serviciosHumedad;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los registros de humedad
        /// GET: api/humedad
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var resultado = _serviciosHumedad.MostrarTodos();

                if (resultado.Estado && resultado.Lista != null)
                {
                    var humedadesDto = HumedadMapper.ToResponseDTOList(resultado.Lista);

                    return Ok(ApiResponseDTO<List<HumedadResponseDTO>>.Success(
                        humedadesDto,
                        $"Se encontraron {humedadesDto.Count} registros de humedad"
                    ));
                }

                return Ok(ApiResponseDTO<List<HumedadResponseDTO>>.Success(
                    new List<HumedadResponseDTO>(),
                    "No hay registros de humedad"
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al obtener humedad: {ex.Message}");
                return BadRequest(ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        /// <summary>
        /// Guarda un nuevo registro de humedad
        /// POST: api/humedad
        /// </summary>
        [HttpPost]
        public IActionResult Insertar([FromBody] HumedadRequestDTO humedadDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseDTO<object>.Error("Datos inválidos"));

                var humedad = HumedadMapper.ToEntity(humedadDto);
                var resultado = _serviciosHumedad.insertar(humedad);

                if (resultado.Estado)
                {
                    var humedadResponse = HumedadMapper.ToResponseDTO(resultado.Entidad);
                    return Ok(ApiResponseDTO<HumedadResponseDTO>.Success(
                        humedadResponse,
                        "Registro de humedad guardado correctamente"
                    ));
                }

                return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al guardar humedad: {ex.Message}");
                return BadRequest(ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        /// <summary>
        /// Obtiene el último registro de humedad (valor actual del sensor)
        /// GET: api/humedad/ultimo
        /// </summary>
        [HttpGet("ultimo")]
        public IActionResult ObtenerUltimo()
        {
            try
            {
                var resultado = _serviciosHumedad.MostrarTodos();

                if (resultado.Estado && resultado.Lista != null && resultado.Lista.Any())
                {
                    var ultimo = resultado.Lista.OrderByDescending(h => h.FechaRegistro).FirstOrDefault();

                    if (ultimo != null)
                    {
                        var humedadDto = HumedadMapper.ToResponseDTO(ultimo);
                        return Ok(ApiResponseDTO<HumedadResponseDTO>.Success(
                            humedadDto,
                            "Último registro de humedad obtenido"
                        ));
                    }
                }

                return NotFound(ApiResponseDTO<object>.Error("No hay registros de humedad"));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return BadRequest(ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        /// <summary>
        /// Obtiene los últimos N registros de humedad
        /// GET: api/humedad/ultimos/10
        /// </summary>
        [HttpGet("ultimos/{cantidad}")]
        public IActionResult ObtenerUltimos(int cantidad = 10)
        {
            try
            {
                var resultado = _serviciosHumedad.MostrarTodos();

                if (resultado.Estado && resultado.Lista != null && resultado.Lista.Any())
                {
                    var ultimos = resultado.Lista
                        .OrderByDescending(h => h.FechaRegistro)
                        .Take(cantidad)
                        .OrderBy(h => h.FechaRegistro)
                        .ToList();

                    var ultimosDto = HumedadMapper.ToResponseDTOList(ultimos);

                    return Ok(ApiResponseDTO<List<HumedadResponseDTO>>.Success(
                        ultimosDto,
                        $"Últimos {cantidad} registros obtenidos"
                    ));
                }

                return Ok(ApiResponseDTO<List<HumedadResponseDTO>>.Success(
                    new List<HumedadResponseDTO>(),
                    "No hay registros"
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return BadRequest(ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }
    }
}