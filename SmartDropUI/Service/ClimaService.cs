using SmartDropUI.Models;
using SmartDropUI.Models.Clima;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    public class ClimaService
    {
        private readonly HttpClient _httpClient;

        // ⚠️ OBTÉN TU API KEY EN: https://openweathermap.org/api
        // 🔴 CAMBIA "TU_API_KEY_AQUI" POR TU API KEY REAL
        private const string ApiKey = "f72b8e28c9cf89b0274f75e745a42e30\r\n";

        // Coordenadas de Valledupar, Cesar, Colombia
        private const double Latitud = 10.4631;
        private const double Longitud = -73.2532;

        public ClimaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DatosClimaModel?> ObtenerClimaActualAsync()
        {
            // Validar que la API Key esté configurada
            if (string.IsNullOrEmpty(ApiKey) || ApiKey == "f72b8e28c9cf89b0274f75e745a42e30\r\n")
            {
                Console.WriteLine("❌ ERROR: API Key no configurada. Ve a ClimaService.cs y reemplaza 'TU_API_KEY_AQUI' con tu API Key de OpenWeatherMap");
                throw new InvalidOperationException("API Key no configurada. Obtén una en https://openweathermap.org/api");
            }

            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?" +
                            $"lat={Latitud}&lon={Longitud}" +
                            $"&appid={ApiKey}" +
                            $"&units=metric" +
                            $"&lang=es";

                Console.WriteLine($"🌐 Consultando API del clima...");
                var response = await _httpClient.GetFromJsonAsync<OpenWeatherResponse>(url);

                if (response == null)
                {
                    Console.WriteLine("⚠️ La respuesta de la API es nula");
                    return null;
                }

                var datosClima = new DatosClimaModel
                {
                    Temperatura = response.main.temp,
                    Humedad = response.main.humidity,
                    Descripcion = response.weather.FirstOrDefault()?.description ?? "No disponible",
                    VelocidadViento = response.wind.speed,
                    ProbabilidadLluvia = 0.0,
                    FechaHoraActualizacion = DateTimeOffset.FromUnixTimeSeconds(response.dt).DateTime
                };

                Console.WriteLine($"✅ Datos climáticos obtenidos: {datosClima.Temperatura}°C, {datosClima.Descripcion}");
                return datosClima;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"❌ Error de red al consultar la API: {ex.Message}");
                throw new Exception("No se pudo conectar con el servicio meteorológico", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inesperado: {ex.Message}");
                throw;
            }
        }
    }
}