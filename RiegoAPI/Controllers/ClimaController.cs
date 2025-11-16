using BLL;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTO.Mappers;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;
using RiegoAPI.DTO.Response;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClimaController : ControllerBase
    {
        private readonly ServicioClima _servicioClima;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string API_KEY = "91c59362a4519b067f3be52b6fe361f3";

        public ClimaController(ServicioClima servicioClima, IHttpClientFactory httpClientFactory)
        {
            _servicioClima = servicioClima;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/clima
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var resultado = _servicioClima.MostrarTodos();
            var climasDto = ClimaMapper.ToResponseDTOList(resultado.Lista);

            return Ok(ApiResponseDTO<System.Collections.Generic.List<RegistroClimaticoResponseDTO>>.Success(
                climasDto,
                $"Se encontraron {climasDto.Count} registros climáticos"
            ));
        }

        // GET: api/clima/actual/{ciudad}
        [HttpGet("actual/{ciudad}")]
        public async Task<IActionResult> ObtenerClimaActual(string ciudad = "Valledupar")
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={API_KEY}&units=metric&lang=es";

            var client = _httpClientFactory.CreateClient();

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var weatherInfo = System.Text.Json.JsonSerializer.Deserialize<ENTITY.WeatherInfo>(content);

                var climaDto = new ClimaExternoResponseDTO
                {
                    Temperatura = (float)weatherInfo.main.temp,
                    Humedad = (float)weatherInfo.main.humidity,
                    Viento = (float)weatherInfo.wind.speed,
                    Descripcion = weatherInfo.weather[0].description
                };

                return Ok(ApiResponseDTO<ClimaExternoResponseDTO>.Success(
                    climaDto,
                    "Datos climáticos obtenidos correctamente"
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseDTO<object>.Error($"Error al obtener datos del clima: {ex.Message}"));
            }
        }

        // POST: api/clima
        [HttpPost]
        public IActionResult Guardar([FromBody] RegistroClimaticoRequestDTO climaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponseDTO<object>.Error("Datos inválidos"));

            var clima = ClimaMapper.ToEntity(climaDto);
            var resultado = _servicioClima.Guardar(clima);

            if (resultado.Estado)
            {
                var climaResponse = ClimaMapper.ToResponseDTO(resultado.Entidad);
                return Ok(ApiResponseDTO<RegistroClimaticoResponseDTO>.Success(
                    climaResponse,
                    resultado.Mensaje
                ));
            }

            return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        // POST: api/clima/capturar-y-guardar/{ciudad}
        [HttpPost("capturar-y-guardar/{ciudad}")]
        public async Task<IActionResult> CapturarYGuardar(
            string ciudad = "Valledupar",
            [FromQuery] float humedadSuelo = 0)
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={API_KEY}&units=metric&lang=es";
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var weatherInfo = System.Text.Json.JsonSerializer.Deserialize<ENTITY.WeatherInfo>(content);

                // Validar duplicados recientes
                var registrosExistentes = _servicioClima.MostrarTodos().Lista;
                var haceCincoMin = DateTime.Now.AddMinutes(-5);
                var registrosRecientes = registrosExistentes
                    .Where(r => r.Fecha >= haceCincoMin)
                    .OrderByDescending(r => r.Fecha)
                    .ToList();

                float tempActual = (float)Math.Round(weatherInfo.main.temp, 2);
                float humSueloActual = (float)Math.Round(humedadSuelo, 2);
                float humAmbienteActual = (float)Math.Round(weatherInfo.main.humidity, 2);
                float vientoActual = (float)Math.Round(weatherInfo.wind.speed, 2);

                bool existeIgual = registrosRecientes.Any(r =>
                    Math.Round(r.Temperatura_Ambiente, 2) == tempActual &&
                    Math.Round(r.Humedad_Suelo, 2) == humSueloActual &&
                    Math.Round(r.Humedad_Ambiente, 2) == humAmbienteActual &&
                    Math.Round(r.Viento, 2) == vientoActual
                );

                if (existeIgual)
                    return Ok(ApiResponseDTO<object>.Error("Ya existe un registro reciente con estos valores"));

                var climaDto = new RegistroClimaticoRequestDTO
                {
                    HumedadAmbiente = humAmbienteActual,
                    HumedadSuelo = humSueloActual,
                    TemperaturaAmbiente = tempActual,
                    Viento = vientoActual
                };

                var clima = ClimaMapper.ToEntity(climaDto);
                var resultado = _servicioClima.Guardar(clima);

                if (resultado.Estado)
                {
                    var climaResponse = ClimaMapper.ToResponseDTO(resultado.Entidad);
                    return Ok(ApiResponseDTO<RegistroClimaticoResponseDTO>.Success(
                        climaResponse,
                        "Datos climáticos capturados y guardados correctamente"
                    ));
                }

                return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseDTO<object>.Error($"Error: {ex.Message}"));
            }
        }

        // GET: api/clima/por-fecha
        [HttpGet("por-fecha")]
        public IActionResult ObtenerPorFecha([FromQuery] DateTime fecha)
        {
            var todos = _servicioClima.MostrarTodos().Lista;
            var filtrados = todos.Where(r => r.Fecha.Date == fecha.Date).ToList();
            var filtradosDto = ClimaMapper.ToResponseDTOList(filtrados);

            return Ok(ApiResponseDTO<System.Collections.Generic.List<RegistroClimaticoResponseDTO>>.Success(
                filtradosDto,
                $"Se encontraron {filtradosDto.Count} registros para la fecha {fecha:dd/MM/yyyy}"
            ));
        }

        // GET: api/clima/ultimos/{cantidad}
        [HttpGet("ultimos/{cantidad}")]
        public IActionResult ObtenerUltimos(int cantidad = 10)
        {
            var respuesta = _servicioClima.MostrarTodos();
            var ultimosRegistros = respuesta.Lista
                .OrderByDescending(c => c.Fecha)
                .Take(cantidad)
                .ToList();

            var climasDto = ClimaMapper.ToResponseDTOList(ultimosRegistros);

            return Ok(ApiResponseDTO<System.Collections.Generic.List<RegistroClimaticoResponseDTO>>.Success(
                climasDto,
                $"Últimos {climasDto.Count} registros climáticos"
            ));
        }

        // GET: api/clima/estadisticas
        [HttpGet("estadisticas")]
        public IActionResult ObtenerEstadisticas([FromQuery] int dias = 7)
        {
            var fechaLimite = DateTime.Now.AddDays(-dias);
            var todos = _servicioClima.MostrarTodos().Lista;
            var recientes = todos.Where(r => r.Fecha >= fechaLimite).ToList();

            if (!recientes.Any())
                return Ok(ApiResponseDTO<object>.Success(new { }, "No hay datos para el período"));

            var estadisticas = new EstadisticasResponseDTO
            {
                TotalRiegos = recientes.Count,
                HumedadPromedio = recientes.Average(r => r.Humedad_Suelo),
                TemperaturaPromedio = recientes.Average(r => r.Temperatura_Ambiente),
                PeriodoInicio = recientes.Min(r => r.Fecha),
                PeriodoFin = recientes.Max(r => r.Fecha)
            };

            return Ok(ApiResponseDTO<EstadisticasResponseDTO>.Success(
                estadisticas,
                $"Estadísticas de los últimos {dias} días"
            ));
        }
    }
}

