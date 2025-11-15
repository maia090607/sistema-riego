using Microsoft.AspNetCore.Mvc;
using BLL;
using Entity;
using DAL;
using System.Text.Json;
using ENTITY;

namespace API.Controllers
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
        public ActionResult<Response<RegistroClimatico>> ObtenerTodos()
        {
            var resultado = _servicioClima.MostrarTodos();
            return Ok(resultado);
        }

        // GET: api/clima/actual/{ciudad}
        [HttpGet("actual/{ciudad}")]
        public async Task<ActionResult<WeatherInfo>> ObtenerClimaActual(string ciudad = "Valledupar")
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={API_KEY}&units=metric&lang=es";

            var client = _httpClientFactory.CreateClient();

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var weatherInfo = JsonSerializer.Deserialize<WeatherInfo>(content);

                return Ok(weatherInfo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener datos del clima: {ex.Message}");
            }
        }

        // POST: api/clima
        [HttpPost]
        public ActionResult<Response<RegistroClimatico>> Guardar([FromBody] RegistroClimatico registro)
        {
            if (registro == null)
                return BadRequest("El registro no puede ser nulo");

            var resultado = _servicioClima.Guardar(registro);

            if (resultado.Estado)
                return Ok(resultado);

            return BadRequest(resultado.Mensaje);
        }

        // POST: api/clima/capturar-y-guardar/{ciudad}
        [HttpPost("capturar-y-guardar/{ciudad}")]
        public async Task<ActionResult<Response<RegistroClimatico>>> CapturarYGuardar(
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
                var weatherInfo = JsonSerializer.Deserialize<WeatherInfo>(content);

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
                    return Ok(new Response<RegistroClimatico>(false, "Ya existe un registro reciente con estos valores", null, null));

                var registro = new RegistroClimatico
                {
                    Humedad_Ambiente = humAmbienteActual,
                    Humedad_Suelo = humSueloActual,
                    Temperatura_Ambiente = tempActual,
                    Viento = vientoActual,
                    Fecha = DateTime.Now
                };

                var resultado = _servicioClima.Guardar(registro);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // GET: api/clima/por-fecha
        [HttpGet("por-fecha")]
        public ActionResult<List<RegistroClimatico>> ObtenerPorFecha([FromQuery] DateTime fecha)
        {
            var todos = _servicioClima.MostrarTodos().Lista;
            var filtrados = todos.Where(r => r.Fecha.Date == fecha.Date).ToList();

            return Ok(filtrados);
        }

        // GET: api/clima/estadisticas
        [HttpGet("estadisticas")]
        public ActionResult<EstadisticasClima> ObtenerEstadisticas([FromQuery] int dias = 7)
        {
            var fechaLimite = DateTime.Now.AddDays(-dias);
            var todos = _servicioClima.MostrarTodos().Lista;
            var recientes = todos.Where(r => r.Fecha >= fechaLimite).ToList();

            if (!recientes.Any())
                return Ok(new EstadisticasClima());

            var estadisticas = new EstadisticasClima
            {
                TotalRegistros = recientes.Count,
                TemperaturaPromedio = recientes.Average(r => r.Temperatura_Ambiente),
                TemperaturaMinima = recientes.Min(r => r.Temperatura_Ambiente),
                TemperaturaMaxima = recientes.Max(r => r.Temperatura_Ambiente),
                HumedadAmbientePromedio = recientes.Average(r => r.Humedad_Ambiente),
                HumedadSueloPromedio = recientes.Average(r => r.Humedad_Suelo),
                VientoPromedio = recientes.Average(r => r.Viento),
                PeriodoAnalizado = dias
            };

            return Ok(estadisticas);
        }
    }

    public class EstadisticasClima
    {
        public int TotalRegistros { get; set; }
        public float TemperaturaPromedio { get; set; }
        public float TemperaturaMinima { get; set; }
        public float TemperaturaMaxima { get; set; }
        public float HumedadAmbientePromedio { get; set; }
        public float HumedadSueloPromedio { get; set; }
        public float VientoPromedio { get; set; }
        public int PeriodoAnalizado { get; set; }
    }
}