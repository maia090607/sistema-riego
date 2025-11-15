using Microsoft.AspNetCore.Mvc;
using BLL;
using ENTITY;
using DAL;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private readonly ServiciosAlertas _serviciosAlertas;

        public AlertasController(ServiciosAlertas serviciosAlertas)
        {
            _serviciosAlertas = serviciosAlertas;
        }

        // GET: api/alertas
        [HttpGet]
        public ActionResult<Response<Alertas>> ObtenerTodas()
        {
            var resultado = _serviciosAlertas.MostrarTodos();
            return Ok(resultado);
        }

        // GET: api/alertas/{id}
        [HttpGet("{id}")]
        public ActionResult<Response<Alertas>> ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosAlertas.ObtenerPorId(id);

            if (resultado.Entidad == null)
                return NotFound($"No se encontró alerta con ID {id}");

            return Ok(resultado);
        }

        // GET: api/alertas/activas
        [HttpGet("activas")]
        public ActionResult<List<Alertas>> ObtenerActivas()
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var activas = todas.Lista?.Where(a => !a.Estado).ToList() ?? new List<Alertas>();

            return Ok(new Response<Alertas>(true,
                $"Se encontraron {activas.Count} alertas activas",
                null,
                activas));
        }

        // GET: api/alertas/por-nivel/{nivel}
        [HttpGet("por-nivel/{nivel}")]
        public ActionResult<List<Alertas>> ObtenerPorNivel(string nivel)
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var filtradas = todas.Lista?
                .Where(a => a.NivelCritico.Equals(nivel, StringComparison.OrdinalIgnoreCase))
                .ToList() ?? new List<Alertas>();

            return Ok(new Response<Alertas>(true,
                $"Se encontraron {filtradas.Count} alertas de nivel {nivel}",
                null,
                filtradas));
        }

        // GET: api/alertas/por-tipo/{tipo}
        [HttpGet("por-tipo/{tipo}")]
        public ActionResult<List<Alertas>> ObtenerPorTipo(string tipo)
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var filtradas = todas.Lista?
                .Where(a => a.TipoAlerta.Contains(tipo, StringComparison.OrdinalIgnoreCase))
                .ToList() ?? new List<Alertas>();

            return Ok(new Response<Alertas>(true,
                $"Se encontraron {filtradas.Count} alertas del tipo {tipo}",
                null,
                filtradas));
        }

        // GET: api/alertas/por-fecha
        [HttpGet("por-fecha")]
        public ActionResult<List<Alertas>> ObtenerPorFecha([FromQuery] DateTime fecha)
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var filtradas = todas.Lista?
                .Where(a => a.FechaHora.Date == fecha.Date)
                .ToList() ?? new List<Alertas>();

            return Ok(new Response<Alertas>(true,
                $"Se encontraron {filtradas.Count} alertas para la fecha {fecha:dd/MM/yyyy}",
                null,
                filtradas));
        }

        // POST: api/alertas
        [HttpPost]
        public ActionResult<Response<Alertas>> Agregar([FromBody] Alertas alerta)
        {
            if (alerta == null)
                return BadRequest("La alerta no puede ser nula");

            var todas = _serviciosAlertas.MostrarTodos();
            int nuevoId = 1;
            if (todas.Lista != null && todas.Lista.Count > 0)
                nuevoId = todas.Lista.Max(a => a.IdAlerta) + 1;

            alerta.IdAlerta = nuevoId;
            alerta.FechaHora = DateTime.Now;

            var resultado = _serviciosAlertas.Agregar(alerta);

            if (resultado.Estado)
                return CreatedAtAction(nameof(ObtenerPorId), new { id = alerta.IdAlerta }, resultado);

            return BadRequest(resultado.Mensaje);
        }

        // PUT: api/alertas/{id}
        [HttpPut("{id}")]
        public ActionResult<Response<Alertas>> Actualizar(int id, [FromBody] Alertas alerta)
        {
            if (id != alerta.IdAlerta)
                return BadRequest("El ID no coincide");

            var resultado = _serviciosAlertas.Actualizar(alerta);

            if (resultado.Estado)
                return Ok(resultado);

            return NotFound(resultado.Mensaje);
        }

        // PATCH: api/alertas/{id}/marcar-leida
        [HttpPatch("{id}/marcar-leida")]
        public ActionResult<Response<Alertas>> MarcarComoLeida(int id)
        {
            var alerta = _serviciosAlertas.ObtenerPorId(id);
            if (alerta.Entidad == null)
                return NotFound($"No se encontró alerta con ID {id}");

            alerta.Entidad.Estado = true;
            var resultado = _serviciosAlertas.Actualizar(alerta.Entidad);

            return Ok(resultado);
        }

        // DELETE: api/alertas/{id}
        [HttpDelete("{id}")]
        public ActionResult<Response<Alertas>> Eliminar(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosAlertas.Eliminar(id);

            if (resultado.Estado)
                return Ok(resultado);

            return NotFound(resultado.Mensaje);
        }

        // GET: api/alertas/resumen
        [HttpGet("resumen")]
        public ActionResult<ResumenAlertas> ObtenerResumen()
        {
            var todas = _serviciosAlertas.MostrarTodos().Lista ?? new List<Alertas>();

            var resumen = new ResumenAlertas
            {
                TotalAlertas = todas.Count,
                AlertasActivas = todas.Count(a => !a.Estado),
                AlertasLeidas = todas.Count(a => a.Estado),
                AlertasCriticasActivas = todas.Count(a => !a.Estado && a.NivelCritico == "Alto"),
                AlertasPorNivel = todas.GroupBy(a => a.NivelCritico)
                    .ToDictionary(g => g.Key, g => g.Count()),
                UltimaAlerta = todas.OrderByDescending(a => a.FechaHora).FirstOrDefault()
            };

            return Ok(resumen);
        }
    }

    public class ResumenAlertas
    {
        public int TotalAlertas { get; set; }
        public int AlertasActivas { get; set; }
        public int AlertasLeidas { get; set; }
        public int AlertasCriticasActivas { get; set; }
        public Dictionary<string, int> AlertasPorNivel { get; set; }
        public Alertas UltimaAlerta { get; set; }
    }
}