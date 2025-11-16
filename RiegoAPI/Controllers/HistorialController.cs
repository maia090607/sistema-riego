using Microsoft.AspNetCore.Mvc;
using BLL;
using ENTITY;
using RiegoAPI.DTO.Mappers;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;
using System.Collections.Generic;
using System.Linq;

// CUANDO EJECUTABA SWAGGER NO ME ABRIA POR EL HECHO DE TENER ESTE CONTRLADOR COPIADO TAMBIEN EN 
// CLIMA CONTROLLER, SOLO LO COMENTE, SI AQUELLA VERSION ES MAS RECIENT O MEJOR, PEGAR AQUELLA ACA
// SI NO DARA ERROES DE RUTAS DUPLICADAS
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
        public ActionResult<List<HistorialRiegoResponseDTO>> ObtenerTodos()
        {
            var entidades = _servicioHistorial.MostrarTodos();
            var dto = HistorialRiegoMapper.ToResponseDTOList(entidades);
            return Ok(dto);
        }


        // GET: api/historial/{id}
        [HttpGet("{id}")]
        public ActionResult<HistorialRiegoResponseDTO> ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var entidad = _servicioHistorial.ObtenerPorId(id);

            if (entidad == null)
                return NotFound($"No se encontró historial con ID {id}");

            return Ok(HistorialRiegoMapper.ToResponseDTO(entidad));
        }


        // GET: api/historial/por-fecha
        [HttpGet("por-fecha")]
        public ActionResult<List<HistorialRiegoResponseDTO>> ObtenerPorFecha([FromQuery] DateTime fecha)
        {
            var entidades = _servicioHistorial.MostrarTodos();
            var filtrados = entidades
                .Where(h => h.Fecha.Date == fecha.Date)
                .ToList();

            return Ok(HistorialRiegoMapper.ToResponseDTOList(filtrados));
        }

        // GET: api/historial/rango-fechas
        [HttpGet("rango-fechas")]
        public ActionResult<List<HistorialRiegoResponseDTO>> ObtenerPorRangoFechas(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            var entidades = _servicioHistorial.MostrarTodos();
            var filtrados = entidades
                .Where(h => h.Fecha.Date >= fechaInicio.Date &&
                            h.Fecha.Date <= fechaFin.Date)
                .ToList();

            return Ok(HistorialRiegoMapper.ToResponseDTOList(filtrados));
        }

        // POST: api/historial
        [HttpPost]
        public ActionResult<HistorialRiegoResponseDTO> Guardar([FromBody] HistorialRiegoRequestDTO dto)
        {
            if (dto == null)
                return BadRequest("El historial no puede ser nulo");

            try
            {
                var entidad = HistorialRiegoMapper.ToEntity(dto);
                var mensaje = _servicioHistorial.Guardar(entidad);

                // entidad.Id debe ya estar asignado después de guardar
                var respuesta = HistorialRiegoMapper.ToResponseDTO(entidad);

                return CreatedAtAction(nameof(ObtenerPorId), new { id = respuesta.Id }, respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al guardar: {ex.Message}");
            }
        }

        // GET: api/historial/ultimo
        [HttpGet("ultimo")]
        public ActionResult<HistorialRiegoResponseDTO> ObtenerUltimo()
        {
            var entidades = _servicioHistorial.MostrarTodos();
            var ultimo = entidades.OrderByDescending(h => h.Fecha).FirstOrDefault();

            if (ultimo == null)
                return NotFound("No hay registros de historial");

            return Ok(HistorialRiegoMapper.ToResponseDTO(ultimo));
        }

        // GET: api/historial/estadisticas
        [HttpGet("estadisticas")]
        public ActionResult<EstadisticasHistorialResponseDTO> ObtenerEstadisticas([FromQuery] int dias = 7)
        {
            var fechaLimite = DateTime.Now.AddDays(-dias);
            var entidades = _servicioHistorial.MostrarTodos();
            var recientes = entidades.Where(h => h.Fecha >= fechaLimite).ToList();

            if (!recientes.Any())
                return Ok(new EstadisticasHistorialResponseDTO());

            var dto = new EstadisticasHistorialResponseDTO
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

            return Ok(dto);
        }
    }

    // DTO de Estadísticas como Response
    //ESTE DTO DEBERIA IR EN LA CARPETA DTO/RESPONSE
    public class EstadisticasHistorialResponseDTO
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
