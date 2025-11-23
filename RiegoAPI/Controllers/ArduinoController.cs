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

        // RiegoAPI/Controllers/ArduinoController.cs

        [HttpPost("manual-on")]
        public IActionResult IniciarManual()
        {
            // Usamos EnviarComando (sin confirmación) para evitar el choque de hilos
            _servicioPuerto.EnviarComando("MANUAL_ON");

            // Retornamos éxito inmediato. El estado real se actualizará en el Dashboard 
            // cuando el hilo de lectura reciba el dato del Arduino.
            return Ok(new { success = true, message = "OK:MANUAL_ON" });
        }

        [HttpPost("manual-off")]
        public IActionResult DetenerManual()
        {
            _servicioPuerto.EnviarComando("MANUAL_OFF");
            return Ok(new { success = true, message = "OK:MANUAL_OFF" });
        }

        [HttpPost("auto")]
        public IActionResult ActivarAuto()
        {
            _servicioPuerto.EnviarComando("AUTO");
            return Ok(new { success = true, message = "OK:AUTO" });
        }
    }
}