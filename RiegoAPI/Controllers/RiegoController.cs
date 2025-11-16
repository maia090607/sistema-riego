using Microsoft.AspNetCore.Mvc;
using BLL;
using RiegoAPI.DTO.Request;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiegoController : ControllerBase
    {
        private readonly ServicioPuerto _servicioPuerto;
        private static DateTime? _ultimoRiego;
        private static readonly TimeSpan TIEMPO_ESPERA = TimeSpan.FromMinutes(5);

        public RiegoController(ServicioPuerto servicioPuerto)
        {
            _servicioPuerto = servicioPuerto;
        }

        // GET: api/riego/estado-puerto
        [HttpGet("estado-puerto")]
        public ActionResult<object> ObtenerEstadoPuerto()
        {
            return Ok(new
            {
                puertoAbierto = _servicioPuerto.PuertoAbierto,
                mensaje = _servicioPuerto.PuertoAbierto ? "Puerto conectado" : "Puerto desconectado"
            });
        }

        // POST: api/riego/activar-bomba
        [HttpPost("activar-bomba")]
        public async Task<ActionResult<object>> ActivarBomba([FromQuery] int segundos = 3)
        {
            if (!_servicioPuerto.PuertoAbierto)
                return BadRequest("El puerto serial no está disponible");

            if (_ultimoRiego.HasValue)
            {
                var tiempoTranscurrido = DateTime.Now - _ultimoRiego.Value;

                if (tiempoTranscurrido < TIEMPO_ESPERA)
                {
                    var tiempoRestante = TIEMPO_ESPERA - tiempoTranscurrido;

                    return BadRequest(new
                    {
                        mensaje = "Debes esperar antes de volver a regar",
                        tiempoRestante = $"{tiempoRestante.Minutes}m {tiempoRestante.Seconds}s"
                    });
                }
            }

            try
            {
                _servicioPuerto.EnviarComando("BOMBA_ON");
                await Task.Delay(TimeSpan.FromSeconds(segundos));

                _servicioPuerto.EnviarComando("BOMBA_OFF");
                _servicioPuerto.EnviarComando("AUTO");

                _ultimoRiego = DateTime.Now;

                return Ok(new
                {
                    mensaje = "Riego ejecutado correctamente",
                    duracion = segundos,
                    proximoRiegoEn = TIEMPO_ESPERA.TotalMinutes
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al activar bomba: {ex.Message}");
            }
        }

        // POST: api/riego/comando
        [HttpPost("comando")]
        public ActionResult<object> EnviarComando([FromBody] ComandoDTO request)
        {
            if (!_servicioPuerto.PuertoAbierto)
                return BadRequest("El puerto serial no está disponible");

            if (string.IsNullOrWhiteSpace(request.Comando))
                return BadRequest("El comando no puede estar vacío");

            try
            {
                _servicioPuerto.EnviarComando(request.Comando);

                return Ok(new
                {
                    mensaje = $"Comando '{request.Comando}' enviado correctamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al enviar comando: {ex.Message}");
            }
        }

        // GET: api/riego/puede-regar
        [HttpGet("puede-regar")]
        public ActionResult<object> PuedeRegar()
        {
            if (!_ultimoRiego.HasValue)
            {
                return Ok(new
                {
                    puedeRegar = true,
                    mensaje = "Puede regar ahora"
                });
            }

            var tiempoTranscurrido = DateTime.Now - _ultimoRiego.Value;
            var puedeRegar = tiempoTranscurrido >= TIEMPO_ESPERA;

            if (puedeRegar)
            {
                return Ok(new
                {
                    puedeRegar = true,
                    mensaje = "Puede regar ahora"
                });
            }
            else
            {
                var tiempoRestante = TIEMPO_ESPERA - tiempoTranscurrido;
                return Ok(new
                {
                    puedeRegar = false,
                    mensaje = "Debe esperar antes de regar nuevamente",
                    tiempoRestante = $"{tiempoRestante.Minutes}m {tiempoRestante.Seconds}s"
                });
            }
        }

        // GET: api/riego/ultimo-riego
        [HttpGet("ultimo-riego")]
        public ActionResult<object> ObtenerUltimoRiego()
        {
            if (!_ultimoRiego.HasValue)
            {
                return Ok(new
                {
                    mensaje = "No hay registros de riego",
                    ultimoRiego = (DateTime?)null
                });
            }

            return Ok(new
            {
                ultimoRiego = _ultimoRiego.Value,
                hace = $"{(DateTime.Now - _ultimoRiego.Value).TotalMinutes:F0} minutos"
            });
        }

        // GET: api/riego/lectura-actual
        [HttpGet("lectura-actual")]
        public ActionResult<object> ObtenerLecturaActual()
        {
            return Ok(new
            {
                timestamp = DateTime.Now,
                mensaje = "Para datos en tiempo real, implementar SignalR o WebSockets"
            });
        }
    }


    // DTO para comandos
    // ESTE DTO DEBERIA IR EN LA CARPETA DTO/REQUEST O DTO/CREATE Y ADEMAS DE TENER EL SUFIJO DTO, REQUEST ES MUY AMBIGUO Y NO SIGUE
    // EL CAMINO DE LOS DEMAS DTO
    public class ComandoRequest
    {
        public string Comando { get; set; }
    }
}
