using BLL;
using ENTITY;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTO.Mappers;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiegoAPI.Controllers
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
        public IActionResult ObtenerTodos()
        {
            var entidades = _servicioHistorial.MostrarTodos();
            var dto = HistorialRiegoMapper.ToResponseDTOList(entidades.ToList());

            return Ok(ApiResponseDTO<List<HistorialRiegoResponseDTO>>.Success(
                dto, $"Se encontraron {dto.Count} registros"));
        }

        // GET: api/historial/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponseDTO<object>.Error("El ID debe ser mayor a cero"));

            var entidad = _servicioHistorial.ObtenerPorId(id);

            if (entidad == null)
                return NotFound(ApiResponseDTO<object>.Error($"No se encontró historial con ID {id}"));

            var dto = HistorialRiegoMapper.ToResponseDTO(entidad);

            return Ok(ApiResponseDTO<HistorialRiegoResponseDTO>.Success(dto, "Historial encontrado"));
        }

        // GET: api/historial/por-fecha
        [HttpGet("por-fecha")]
        public IActionResult ObtenerPorFecha([FromQuery] DateTime fecha)
        {
            var entidades = _servicioHistorial.MostrarTodos();
            var filtrados = entidades.Where(h => h.Fecha.Date == fecha.Date).ToList();

            var dto = HistorialRiegoMapper.ToResponseDTOList(filtrados);

            return Ok(ApiResponseDTO<List<HistorialRiegoResponseDTO>>.Success(
                dto, $"Se encontraron {dto.Count} registros para la fecha {fecha:dd/MM/yyyy}"));
        }

        // POST: api/historial
        [HttpPost]
        public IActionResult Guardar([FromBody] HistorialRiegoRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponseDTO<object>.Error("Datos inválidos"));

            try
            {
                var entidad = HistorialRiegoMapper.ToEntity(dto);

                // ✅ Llamada corregida: 'resultado' es de tipo Response<Historial_Riego>
                var resultado = _servicioHistorial.Guardar(entidad);

                if (resultado.Estado)
                {
                    var respuesta = HistorialRiegoMapper.ToResponseDTO(entidad);

                    return CreatedAtAction(nameof(ObtenerPorId),
                        new { id = respuesta.Id },
                        ApiResponseDTO<HistorialRiegoResponseDTO>.Success(
                            respuesta, resultado.Mensaje));
                }
                else
                {
                    return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<object>.Error($"Error interno: {ex.Message}"));
            }
        }

        // GET: api/historial/ultimo
        [HttpGet("ultimo")]
        public IActionResult ObtenerUltimo()
        {
            var entidades = _servicioHistorial.MostrarTodos();
            var ultimo = entidades.OrderByDescending(h => h.Fecha).FirstOrDefault();

            if (ultimo == null)
                return NotFound(ApiResponseDTO<object>.Error("No hay registros de historial"));

            var dto = HistorialRiegoMapper.ToResponseDTO(ultimo);

            return Ok(ApiResponseDTO<HistorialRiegoResponseDTO>.Success(
                dto, "Último registro de riego"));
        }

        // GET: api/historial/estadisticas
        [HttpGet("estadisticas")]
        public IActionResult ObtenerEstadisticas([FromQuery] int dias = 7)
        {
            var fechaLimite = DateTime.Now.AddDays(-dias);
            var entidades = _servicioHistorial.MostrarTodos();
            var recientes = entidades.Where(h => h.Fecha >= fechaLimite).ToList();

            if (!recientes.Any())
                return Ok(ApiResponseDTO<object>.Success(
                    new { }, "No hay datos para el período"));

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

            return Ok(ApiResponseDTO<EstadisticasHistorialResponseDTO>.Success(
                dto, $"Estadísticas de los últimos {dias} días"));
        }
    }
}