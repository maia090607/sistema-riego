using SmartDropUI.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace SmartDropUI.Services
{
    /// Servicio para gestión de riego y sensores
    public class RiegoService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _weatherClient;
        private const bool MODO_PRUEBA = false; // Cambiar a false cuando conectes Arduino

        public RiegoService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _weatherClient = httpClientFactory.CreateClient("WeatherAPI");
        }

        /// Obtener datos actuales de todos los sensores y clima
        public async Task<DatosSensorModel> ObtenerDatosActualesAsync()
        {
            if (MODO_PRUEBA)
            {
                // Obtener datos reales del clima de Valledupar
                var datosClima = await ObtenerClimaValleduparAsync();

                // Combinar con datos simulados de sensores locales
                return await Task.FromResult(new DatosSensorModel
                {
                    // Datos reales del clima
                    Temperatura = datosClima.Temperatura,
                    HumedadAire = datosClima.HumedadAire,
                    Pronostico = datosClima.Pronostico,
                    DireccionViento = datosClima.DireccionViento,
                    VelocidadViento = datosClima.VelocidadViento,

                    // Datos simulados del sistema local
                    HumedadSuelo = Random.Shared.Next(20, 100),
                    BombaActiva = Random.Shared.Next(0, 2) == 1,
                    ProgramaOnline = true,
                    UltimoRiego = DateTime.Now.AddHours(-Random.Shared.Next(1, 12))
                });
            }
            else
            {
                try
                {
                    var response = await _httpClient.GetFromJsonAsync<DatosSensorModel>("api/sensores/actuales");
                    return response ?? new DatosSensorModel();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener datos: {ex.Message}");
                    return new DatosSensorModel();
                }
            }
        }

        /// Obtener datos del clima real de Valledupar usando Open-Meteo API
        private async Task<ClimaValleduparModel> ObtenerClimaValleduparAsync()
        {
            try
            {
                Console.WriteLine("🌦️ Obteniendo clima de Valledupar...");

                // Coordenadas de Valledupar: 10.4631°N, -73.2532°W
                var url = "https://api.open-meteo.com/v1/forecast?latitude=10.4631&longitude=-73.2532&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m,wind_direction_10m&timezone=America/Bogota";

                var response = await _weatherClient.GetFromJsonAsync<OpenMeteoResponse>(url);

                if (response?.Current != null)
                {
                    Console.WriteLine($"✅ Clima obtenido: {response.Current.Temperature2m}°C, {response.Current.RelativeHumidity2m}%");

                    return new ClimaValleduparModel
                    {
                        Temperatura = (int)Math.Round(response.Current.Temperature2m),
                        HumedadAire = response.Current.RelativeHumidity2m,
                        Pronostico = ObtenerPronosticoDesdeCode(response.Current.WeatherCode),
                        DireccionViento = ObtenerDireccionViento(response.Current.WindDirection10m),
                        VelocidadViento = (int)Math.Round(response.Current.WindSpeed10m)
                    };
                }

                Console.WriteLine("⚠️ Response.Current es null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener clima: {ex.Message}");
            }

            // Valores por defecto si falla la API
            Console.WriteLine("📊 Usando valores por defecto del clima");
            return new ClimaValleduparModel
            {
                Temperatura = 32,
                HumedadAire = 60,
                Pronostico = "Despejado",
                DireccionViento = "Norte",
                VelocidadViento = 10
            };
        }

        /// Convertir código de clima de Open-Meteo a descripción en español
        private string ObtenerPronosticoDesdeCode(int code)
        {
            return code switch
            {
                0 => "Despejado",
                1 => "Mayormente Despejado",
                2 => "Parcialmente Nublado",
                3 => "Nublado",
                45 or 48 => "Neblina",
                51 or 53 or 55 => "Llovizna",
                61 or 63 or 65 => "Lluvioso",
                80 or 81 or 82 => "Chubascos",
                95 or 96 or 99 => "Tormentoso",
                _ => "Parcialmente Nublado"
            };
        }

        /// Convertir dirección del viento en grados a punto cardinal
        private string ObtenerDireccionViento(double grados)
        {
            var direcciones = new[] { "Norte", "Noreste", "Este", "Sureste", "Sur", "Suroeste", "Oeste", "Noroeste" };
            var index = (int)Math.Round(grados / 45.0) % 8;
            return direcciones[index];
        }

        /// Obtener historial de riegos realizados
        public async Task<List<DatosRiegoModel>> ObtenerHistorialAsync()
        {
            if (MODO_PRUEBA)
            {
                var historial = new List<DatosRiegoModel>();
                for (int i = 1; i <= 10; i++)
                {
                    historial.Add(new DatosRiegoModel
                    {
                        Id = i,
                        Fecha = DateTime.Now.AddDays(-i),
                        Humedad = Random.Shared.Next(20, 90),
                        Temperatura = Random.Shared.Next(18, 35),
                        Estado = Random.Shared.Next(0, 2) == 1 ? "Regado" : "Sin riego"
                    });
                }
                return await Task.FromResult(historial);
            }
            else
            {
                try
                {
                    var response = await _httpClient.GetFromJsonAsync<List<DatosRiegoModel>>("api/riego/historial");
                    return response ?? new List<DatosRiegoModel>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener historial: {ex.Message}");
                    return new List<DatosRiegoModel>();
                }
            }
        }

        /// Activar riego manual del sistema
        public async Task<bool> ActivarRiegoManualAsync()
        {
            if (MODO_PRUEBA)
            {
                Console.WriteLine("💧 Activando riego manual...");
                await Task.Delay(1000);
                Console.WriteLine("✅ Riego activado");
                return true;
            }
            else
            {
                try
                {
                    var response = await _httpClient.PostAsync("api/riego/manual", null);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al activar riego: {ex.Message}");
                    return false;
                }
            }
        }
    }

    /// Modelo de respuesta de la API de Open-Meteo
    public class OpenMeteoResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set; }
    }

    /// Datos actuales del clima
    public class CurrentWeather
    {
        [JsonPropertyName("temperature_2m")]
        public double Temperature2m { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public int RelativeHumidity2m { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed10m { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public double WindDirection10m { get; set; }
    }
}