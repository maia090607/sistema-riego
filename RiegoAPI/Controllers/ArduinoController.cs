using BLL;
using Microsoft.AspNetCore.Mvc;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArduinoController : ControllerBase
    {
        private readonly ServicioPuerto _servicioPuerto;

        public ArduinoController(ServicioPuerto servicioPuerto)
        {
            _servicioPuerto = servicioPuerto;
        }

        [HttpGet("estado")]
        public IActionResult ObtenerEstado()
        {
            // Obtenemos los 3 datos clave desde el ServicioPuerto
            var (humedad, bomba, manual, fecha) = _servicioPuerto.ObtenerUltimoEstado();

            return Ok(new
            {
                success = true,
                data = new
                {
                    Humedad = humedad,
                    BombaEncendida = bomba,
                    ModoManual = manual, // ✅ Enviamos esto al Frontend
                    FechaLectura = fecha
                }
            });
        }

        [HttpPost("manual-on")]
        public IActionResult IniciarManual()
        {
            if (!_servicioPuerto.PuertoAbierto)
                return BadRequest(new { success = false, message = "Puerto cerrado" });

            bool ok = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_ON");
            return ok ? Ok(new { success = true, message = "OK:MANUAL_ON" })
                      : StatusCode(500, new { success = false, message = "Sin respuesta del Arduino" });
        }

        [HttpPost("manual-off")]
        public IActionResult DetenerManual()
        {
            if (!_servicioPuerto.PuertoAbierto)
                return BadRequest(new { success = false, message = "Puerto cerrado" });

            bool ok = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_OFF");
            return ok ? Ok(new { success = true, message = "OK:MANUAL_OFF" })
                      : StatusCode(500, new { success = false, message = "Sin respuesta del Arduino" });
        }
    }
}