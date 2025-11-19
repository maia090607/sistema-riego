using Microsoft.AspNetCore.Mvc;
using BLL;
using RiegoAPI.DTOs.Response;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArduinoController : ControllerBase
    {
        private readonly ServicioPuerto _servicioPuerto;
        private readonly ILogger<ArduinoController> _logger;

        public ArduinoController(ServicioPuerto servicioPuerto, ILogger<ArduinoController> logger)
        {
            _servicioPuerto = servicioPuerto;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el estado actual del Arduino (humedad, bomba, modo)
        /// </summary>
        [HttpGet("estado")]
        public IActionResult ObtenerEstado()
        {
            try
            {
                if (!_servicioPuerto.PuertoAbierto)
                {
                    return BadRequest(ApiResponseDTO<object>.Error("Puerto Arduino no disponible"));
                }

                // Aquí deberías tener lógica para obtener el estado real
                // Por ahora retorno un estado simulado
                var estado = new
                {
                    Humedad = 0,
                    BombaEncendida = false,
                    ModoManual = false
                };

                return Ok(ApiResponseDTO<object>.Success(estado, "Estado obtenido"));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al obtener estado: {ex.Message}");
                return StatusCode(500, ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        /// <summary>
        /// Inicia riego manual enviando MANUAL_ON al Arduino
        /// </summary>
        [HttpPost("manual-on")]
        public async Task<IActionResult> IniciarRiegoManual()
        {
            try
            {
                _logger.LogInformation("🚀 [API] Recibiendo solicitud MANUAL_ON");

                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogError("❌ [API] Puerto Arduino no disponible");
                    return BadRequest(ApiResponseDTO<object>.Error("Puerto Arduino no disponible"));
                }

                // Enviar comando al Arduino
                _servicioPuerto.EnviarComando("MANUAL_ON");
                _logger.LogInformation("✅ [API] Comando MANUAL_ON enviado al Arduino");

                // Esperar respuesta del Arduino
                await Task.Delay(500);

                return Ok(ApiResponseDTO<object>.Success(
                    new { comando = "MANUAL_ON" },
                    "Riego manual iniciado"
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error al iniciar riego manual: {ex.Message}");
                return StatusCode(500, ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        /// <summary>
        /// Detiene riego manual enviando MANUAL_OFF al Arduino
        /// </summary>
        [HttpPost("manual-off")]
        public async Task<IActionResult> DetenerRiegoManual()
        {
            try
            {
                _logger.LogInformation("🛑 [API] Recibiendo solicitud MANUAL_OFF");

                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogError("❌ [API] Puerto Arduino no disponible");
                    return BadRequest(ApiResponseDTO<object>.Error("Puerto Arduino no disponible"));
                }

                // Enviar comando al Arduino
                _servicioPuerto.EnviarComando("MANUAL_OFF");
                _logger.LogInformation("✅ [API] Comando MANUAL_OFF enviado al Arduino");

                await Task.Delay(500);

                return Ok(ApiResponseDTO<object>.Success(
                    new { comando = "MANUAL_OFF" },
                    "Riego manual detenido"
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error al detener riego manual: {ex.Message}");
                return StatusCode(500, ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        /// <summary>
        /// Activa modo automático enviando AUTO al Arduino
        /// </summary>
        [HttpPost("auto")]
        public async Task<IActionResult> ActivarModoAutomatico()
        {
            try
            {
                _logger.LogInformation("🔄 [API] Recibiendo solicitud AUTO");

                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogError("❌ [API] Puerto Arduino no disponible");
                    return BadRequest(ApiResponseDTO<object>.Error("Puerto Arduino no disponible"));
                }

                _servicioPuerto.EnviarComando("AUTO");
                _logger.LogInformation("✅ [API] Comando AUTO enviado al Arduino");

                await Task.Delay(500);

                return Ok(ApiResponseDTO<object>.Success(
                    new { comando = "AUTO" },
                    "Modo automático activado"
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error al activar modo automático: {ex.Message}");
                return StatusCode(500, ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        /// <summary>
        /// Verifica conexión con Arduino
        /// </summary>
        [HttpGet("conexion")]
        public IActionResult VerificarConexion()
        {
            try
            {
                var conectado = _servicioPuerto.PuertoAbierto;

                return Ok(ApiResponseDTO<object>.Success(
                    new { conectado },
                    conectado ? "Arduino conectado" : "Arduino desconectado"
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al verificar conexión: {ex.Message}");
                return StatusCode(500, ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }
    }
}