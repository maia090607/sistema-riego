using Microsoft.AspNetCore.Mvc;
using BLL;

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

        // En ArduinoController.cs
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

                // ✅ Enviar comando y esperar confirmación
                bool confirmado = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_ON", 3000);

                if (!confirmado)
                {
                    _logger.LogError("❌ [API] Arduino no confirmó el comando");
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Arduino no respondió al comando"
                    });
                }

                _logger.LogInformation("✅ [API] Comando MANUAL_ON confirmado");

                return Ok(new
                {
                    success = true,
                    message = "Riego manual iniciado y confirmado",
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

                // ✅ Enviar comando y esperar confirmación
                bool confirmado = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_OFF", 3000);

                if (!confirmado)
                {
                    _logger.LogError("❌ [API] Arduino no confirmó el comando");
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Arduino no respondió al comando"
                    });
                }

                _logger.LogInformation("✅ [API] Comando MANUAL_OFF confirmado");

                return Ok(new
                {
                    success = true,
                    message = "Riego manual detenido y confirmado",
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

        // ✅ ENDPOINT ACTUALIZADO: Retorna datos reales del Arduino
        [HttpGet("estado")]
        public IActionResult ObtenerEstado()
        {
            try
            {
                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogWarning("⚠️ [API] Puerto no disponible");
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                // ✅ Obtener último estado capturado
                var (humedad, bombaActiva, fechaLectura) = _servicioPuerto.ObtenerUltimoEstado();

                _logger.LogInformation($"📊 [API] H:{humedad}% B:{bombaActiva} Fecha:{fechaLectura}");

                var estado = new
                {
                    Humedad = humedad,
                    BombaEncendida = bombaActiva,
                    ModoManual = false,
                    FechaLectura = fechaLectura
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