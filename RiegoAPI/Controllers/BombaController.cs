using Microsoft.AspNetCore.Mvc;
using RiegoAPI.Models;
using System.IO.Ports;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BombaController : ControllerBase
    {
        private readonly IArduinoService _arduinoService;
        private readonly ILogger<BombaController> _logger;

        public BombaController(IArduinoService arduinoService, ILogger<BombaController> logger)
        {
            _arduinoService = arduinoService;
            _logger = logger;
        }

        /// <summary>
        /// Enciende la bomba de agua
        /// </summary>
        [HttpPost("encender")]
        public async Task<IActionResult> EncenderBomba()
        {
            try
            {
                var resultado = await _arduinoService.EncenderBombaAsync();

                if (resultado)
                {
                    _logger.LogInformation("Bomba encendida exitosamente");
                    return Ok(new
                    {
                        success = true,
                        message = "Bomba encendida exitosamente",
                        timestamp = DateTime.Now
                    });
                }

                return BadRequest(new
                {
                    success = false,
                    message = "No se pudo encender la bomba"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al encender la bomba");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al encender la bomba",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Apaga la bomba de agua
        /// </summary>
        [HttpPost("apagar")]
        public async Task<IActionResult> ApagarBomba()
        {
            try
            {
                var resultado = await _arduinoService.ApagarBombaAsync();

                if (resultado)
                {
                    _logger.LogInformation("Bomba apagada exitosamente");
                    return Ok(new
                    {
                        success = true,
                        message = "Bomba apagada exitosamente",
                        timestamp = DateTime.Now
                    });
                }

                return BadRequest(new
                {
                    success = false,
                    message = "No se pudo apagar la bomba"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al apagar la bomba");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al apagar la bomba",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Obtiene el estado actual de la bomba
        /// </summary>
        [HttpGet("estado")]
        public async Task<IActionResult> ObtenerEstado()
        {
            try
            {
                var estado = await _arduinoService.ObtenerEstadoBombaAsync();

                return Ok(new
                {
                    success = true,
                    encendida = estado,
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estado de la bomba");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al obtener estado",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Obtiene los datos de los sensores del Arduino
        /// </summary>
        [HttpGet("sensores")]
        public async Task<IActionResult> ObtenerDatosSensores()
        {
            try
            {
                var datos = await _arduinoService.ObtenerDatosSensoresAsync();

                return Ok(new
                {
                    success = true,
                    datos = datos,
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener datos de sensores");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al obtener datos",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Verifica la conexión con el Arduino
        /// </summary>
        [HttpGet("conexion")]
        public IActionResult VerificarConexion()
        {
            try
            {
                var conectado = _arduinoService.EstaConectado();

                return Ok(new
                {
                    success = true,
                    conectado = conectado,
                    puerto = _arduinoService.ObtenerPuerto(),
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al verificar conexión");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al verificar conexión",
                    error = ex.Message
                });
            }
        }
    }

    // Interfaz del servicio Arduino
    public interface IArduinoService
    {
        Task<bool> EncenderBombaAsync();
        Task<bool> ApagarBombaAsync();
        Task<bool> ObtenerEstadoBombaAsync();
        Task<DatosSensoresModel> ObtenerDatosSensoresAsync();
        bool EstaConectado();
        string ObtenerPuerto();
    }

 
}