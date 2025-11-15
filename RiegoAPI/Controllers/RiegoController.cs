using Microsoft.AspNetCore.Mvc;
using BLL;

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
                        tiempoRestante = $"{tiempoRestante.