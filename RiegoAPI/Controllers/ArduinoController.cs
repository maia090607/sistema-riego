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
            // ✅ CORRECCIÓN: Ya no usamos deconstrucción con paréntesis (var (a,b) = ...)
            // Ahora obtenemos el objeto completo.
            var estado = _servicioPuerto.ObtenerUltimoEstado();

            return Ok(new
            {
                success = true,
                data = new
                {
                    Humedad = estado.Humedad,
                    BombaEncendida = estado.BombaEncendida,
                    ModoManual = estado.ModoManual,
                    FechaLectura = estado.FechaHora
                }
            });
        }

        [HttpPost("manual-on")]
        public IActionResult IniciarManual()
        {
            bool ok = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_ON");
            return Ok(new { success = ok, message = ok ? "OK:MANUAL_ON" : "Error al enviar" });
        }

        [HttpPost("manual-off")]
        public IActionResult DetenerManual()
        {
            bool ok = _servicioPuerto.EnviarComandoConConfirmacion("MANUAL_OFF");
            return Ok(new { success = ok, message = ok ? "OK:MANUAL_OFF" : "Error al enviar" });
        }

        [HttpPost("auto")]
        public IActionResult ActivarAuto()
        {
            bool ok = _servicioPuerto.EnviarComandoConConfirmacion("AUTO");
            return Ok(new { success = ok, message = ok ? "OK:AUTO" : "Error al enviar" });
        }
    }
}