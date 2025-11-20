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

        [HttpPost("manual-on")]
        public async Task<IActionResult> IniciarRiegoManual()
        {
            try
            {
                _logger.LogInformation("🚀 [API] MANUAL_ON recibido");

                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogError("❌ [API] Puerto no disponible");
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                // ✅ ENVIAR COMANDO AL ARDUINO
                _servicioPuerto.EnviarComando("MANUAL_ON");
                _logger.LogInformation("📤 [API] Comando MANUAL_ON enviado");

                // Esperar respuesta del Arduino
                await Task.Delay(500);

                return Ok(new
                {
                    success = true,
                    message = "Riego manual iniciado",
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("manual-off")]
        public async Task<IActionResult> DetenerRiegoManual()
        {
            try
            {
                _logger.LogInformation("🛑 [API] MANUAL_OFF recibido");

                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogError("❌ [API] Puerto no disponible");
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                // ✅ ENVIAR COMANDO AL ARDUINO
                _servicioPuerto.EnviarComando("MANUAL_OFF");
                _logger.LogInformation("📤 [API] Comando MANUAL_OFF enviado");

                await Task.Delay(500);

                return Ok(new
                {
                    success = true,
                    message = "Riego manual detenido",
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("auto")]
        public async Task<IActionResult> ActivarModoAutomatico()
        {
            try
            {
                _logger.LogInformation("🔄 [API] AUTO recibido");

                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogError("❌ [API] Puerto no disponible");
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                // ✅ ENVIAR COMANDO AL ARDUINO
                _servicioPuerto.EnviarComando("AUTO");
                _logger.LogInformation("📤 [API] Comando AUTO enviado");

                await Task.Delay(500);

                return Ok(new
                {
                    success = true,
                    message = "Modo automático activado",
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("estado")]
        public async Task<IActionResult> ObtenerEstado()
        {
            try
            {
                if (!_servicioPuerto.PuertoAbierto)
                {
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                // Solicitar estado al Arduino
                _servicioPuerto.EnviarComando("GET_STATUS");
                await Task.Delay(300);

                // Por ahora retornamos estado simulado
                // En producción, deberías leer la respuesta del Arduino
                var estado = new
                {
                    Humedad = 0,
                    BombaEncendida = false,
                    ModoManual = false
                };

                return Ok(new { success = true, data = estado });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("conexion")]
        public IActionResult VerificarConexion()
        {
            try
            {
                var conectado = _servicioPuerto.PuertoAbierto;

                return Ok(new
                {
                    success = true,
                    conectado = conectado,
                    mensaje = conectado ? "Arduino conectado" : "Arduino desconectado",
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}