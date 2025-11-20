using BLL;
using ENTITY;
using Microsoft.AspNetCore.Mvc;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArduinoController : ControllerBase
    {

        private readonly ServicioPuerto _servicioPuerto;
        private readonly ILogger<ArduinoController> _logger;
        private readonly IHttpClientFactory _httpClientFactory; // ✅ AÑADIR

        public ArduinoController(
            ServicioPuerto servicioPuerto,
            ILogger<ArduinoController> logger,
            IHttpClientFactory httpClientFactory) // ✅ AÑADIR
        {
            _servicioPuerto = servicioPuerto;
            _logger = logger;
            _httpClientFactory = httpClientFactory; // ✅ AÑADIR
        }
        [HttpPost("manual-on")]
        public async Task<IActionResult> IniciarRiegoManual()
        {
            try
            {
                _logger.LogInformation("🚀 [API] MANUAL_ON recibido");

                if (!_servicioPuerto.PuertoAbierto)
                {
                    _logger.LogError("❌ Puerto no disponible");
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                bool confirmado = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_ON", 3000);

                if (!confirmado)
                {
                    _logger.LogError("❌ Arduino no confirmó MANUAL_ON");
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Arduino no respondió al comando"
                    });
                }

                _logger.LogInformation("✅ MANUAL_ON confirmado");

                // ✅ REGISTRAR RIEGO MANUAL EN HISTORIAL
                await RegistrarRiegoManualAsync();

                return Ok(new
                {
                    success = true,
                    message = "OK:MANUAL_ON",
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error MANUAL_ON: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        // ✅ NUEVO MÉTODO: Registrar riego manual
        private async Task RegistrarRiegoManualAsync()
        {
            try
            {
                var (humedad, bombaActiva, modoManual, fechaLectura) = _servicioPuerto.ObtenerUltimoEstado();

                // Obtener temperatura del clima
                float temperatura = await ObtenerTemperaturaActualAsync();

                var historial = new Historial_Riego
                {
                    Fecha = DateTime.Now,
                    Humedad = humedad,
                    Temperatura = temperatura
                };

                var servicioHistorial = new ServicioHistorial();
                servicioHistorial.Guardar(historial);

                _logger.LogInformation($"💾 [API] Riego manual registrado - H:{humedad}% T:{temperatura}°C");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error al registrar riego manual: {ex.Message}");
            }
        }

        // ✅ NUEVO MÉTODO: Obtener temperatura del clima
        private async Task<float> ObtenerTemperaturaActualAsync()
        {
            try
            {
                using var client = new HttpClient();
                string apiKey = "91c59362a4519b067f3be52b6fe361f3";
                string url = $"https://api.openweathermap.org/data/2.5/weather?q=Valledupar&appid={apiKey}&units=metric";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherInfo = System.Text.Json.JsonSerializer.Deserialize<ENTITY.WeatherInfo>(content);
                    return (float)weatherInfo.main.temp;
                }

                return 25.0f; // Valor por defecto
            }
            catch
            {
                return 25.0f; // Valor por defecto en caso de error
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
                    _logger.LogError("❌ Puerto no disponible");
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                bool confirmado = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_OFF", 3000);

                if (!confirmado)
                {
                    _logger.LogError("❌ Arduino no confirmó MANUAL_OFF");
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Arduino no respondió al comando"
                    });
                }

                _logger.LogInformation("✅ MANUAL_OFF confirmado");

                return Ok(new
                {
                    success = true,
                    message = "OK:MANUAL_OFF",  // ✅ Formato esperado
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error MANUAL_OFF: {ex.Message}");
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
                    _logger.LogError("❌ Puerto no disponible");
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                _servicioPuerto.EnviarComando("AUTO");
                _logger.LogInformation("📤 Comando AUTO enviado");

                await Task.Delay(300);

                return Ok(new
                {
                    success = true,
                    message = "OK:AUTO",  // ✅ Formato esperado
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error AUTO: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("estado")]
        public IActionResult ObtenerEstado()
        {
            try
            {
                if (!_servicioPuerto.PuertoAbierto)
                {
                    return BadRequest(new { success = false, message = "Puerto no disponible" });
                }

                // ✅ AHORA INCLUYE MODO MANUAL
                var (humedad, bombaActiva, modoManual, fechaLectura) = _servicioPuerto.ObtenerUltimoEstado();

                var estado = new
                {
                    Humedad = humedad,
                    BombaEncendida = bombaActiva,
                    ModoManual = modoManual,  // ✅ AÑADIDO
                    FechaLectura = fechaLectura
                };

                return Ok(new { success = true, data = estado });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error ESTADO: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("conexion")]
        public IActionResult VerificarConexion()
        {
            try
            {
                bool conectado = _servicioPuerto.PuertoAbierto;

                return Ok(new
                {
                    success = true,
                    conectado,
                    mensaje = conectado ? "Arduino conectado" : "Arduino desconectado",
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error CONEXIÓN: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}