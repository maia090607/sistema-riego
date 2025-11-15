using Microsoft.AspNetCore.Mvc;
using BLL;
using ENTITY;
using System.Collections.ObjectModel;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialController : ControllerBase
    {
        private readonly ServicioHistorial _servicioHistorial;

        public HistorialController(ServicioHistorial servicioHistorial)
        {
            _servicioHistorial = servicioHistorial;
        }

        // GET: api/historial
        [HttpGet]
        public ActionResult<ReadOnlyCollection<Historial_Riego>> ObtenerTodos()
        {
            var resultado = _servicioHistorial.MostrarTodos();
            return Ok(resultado);
        }

        // GET: api/historial/{id}
        [HttpGet("{id}")]
        public ActionResult<Historial_Riego> ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _servicioHistorial.ObtenerPorId(id);

            if (resultado == null)
                return NotFound($"No se encontró historial con ID {id}");

            return Ok(resultado);
        }

        // GET: api/historial/por-fecha
        [HttpGet("por-fecha")]
        public ActionResult<List<Historial_Riego>> ObtenerPorFecha([FromQuery] DateTime fecha)
        {
            var todos = _servicioHistorial.MostrarTodos();
            var filtrados = todos.Where(h => h.Fecha.Date == fecha.Date).ToList();

            return Ok(filtrados);
        }

        // GET: api/historial/rango-fechas
        [HttpGet("rango-fechas")]
        public ActionResult<List<Historial_Riego>> ObtenerPorRangoFechas(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            var todos = _servicioHistorial.MostrarTodos();
            var filtrados = todos.Where(h =>
                h.Fecha.Date >= fechaInicio.Date &&
                h.Fecha.Date <= fechaFin.Date
            ).ToList();

            return Ok(filtrados);
        }

        // POST: api/historial
        [HttpPost]
        public ActionResult<string> Guardar([FromBody] Historial_Riego historial)
        {
            if (historial == null)
                return BadRequest("El historial no puede ser nulo");

            try
            {
                var resultado = _servicioHistorial.Guardar(historial);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = historial.Id }, resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al guardar: {ex.Message}");
            }
        }

        // GET: api/historial/ultimo
        [HttpGet("ultimo")]
        public ActionResult<Historial_Riego> ObtenerUltimo()
        {
            var todos = _servicioHistorial.MostrarTodos();
            var ultimo = todos.OrderByDescending(h => h.Fecha).FirstOrDefault();

            if (ultimo == null)
                return NotFound("No hay registros de historial");

            return Ok(ultimo);
        }

        // GET: api/historial/estadisticas
        [HttpGet("estadisticas")]
        public ActionResult<EstadisticasHistorial> ObtenerEstadisticas([FromQuery] int dias = 7)
        {
            var fechaLimite = DateTime.Now.AddDays(-dias);
            var todos = _servicioHistorial.MostrarTodos();
            var recientes = todos.Where(h => h.Fecha >= fechaLimite).ToList();

            if (!recientes.Any())
                return Ok(new EstadisticasHistorial());

            var estadisticas = new EstadisticasHistorial
            {
                TotalRegistros = recientes.Count,
                HumedadPromedio = recientes.Average(h => h.Humedad),
                HumedadMinima = recientes.Min(h => h.Humedad),
                HumedadMaxima = recientes.Max(h => h.Humedad),
                TemperaturaPromedio = recientes.Average(h => h.Temperatura),
                TemperaturaMinima = recientes.Min(h => h.Temperatura),
                TemperaturaMaxima = recientes.Max(h => h.Temperatura),
                PeriodoAnalizado = dias
            };

            return Ok(estadisticas);
        }
    }

    public class EstadisticasHistorial
    {
        public int TotalRegistros { get; set; }
        public float HumedadPromedio { get; set; }
        public float HumedadMinima { get; set; }
        public float HumedadMaxima { get; set; }
        public float TemperaturaPromedio { get; set; }
        public float TemperaturaMinima { get; set; }
        public float TemperaturaMaxima { get; set; }
        public int PeriodoAnalizado { get; set; }
    }
}