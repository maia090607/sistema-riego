using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using SmartDropUI.Models;

namespace SmartDropUI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        // Método existente de Usuarios...
        public async Task<List<Usuario>?> ObtenerUsuariosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/usuarios");
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadFromJsonAsync<List<Usuario>>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error: {ex.Message}");
                return null;
            }
        }

        // ✅ NUEVO MÉTODO: Obtener Plantas
        public async Task<List<PlantaModel>?> ObtenerPlantasAsync()
        {
            try
            {
                _logger.LogInformation("🌱 [API] Obteniendo plantas...");
                // Usamos la ruta relativa, el BaseAddress ya está configurado en Program.cs (puerto 5001)
                var response = await _httpClient.GetAsync("/api/plantas");

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<PlantaModel>>>();
                    if (apiResponse != null && apiResponse.success)
                    {
                        return apiResponse.data;
                    }
                }

                _logger.LogError($"❌ [API] Error al obtener plantas: {response.StatusCode}");
                return new List<PlantaModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error conexión plantas: {ex.Message}");
                return new List<PlantaModel>();
            }
        }

        // Cambia este método para aceptar el ID
        public async Task<List<PlantaModel>?> ObtenerPlantasPorUsuarioAsync(int idUsuario)
        {
            try
            {
                // ✅ Llamamos al nuevo endpoint filtrado
                var response = await _httpClient.GetAsync($"/api/plantas/usuario/{idUsuario}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<PlantaModel>>>();
                    return result?.data ?? new List<PlantaModel>();
                }
                return new List<PlantaModel>();
            }
            catch { return new List<PlantaModel>(); }
        }

        // ✅ NUEVO MÉTODO: Registrar Planta
        public async Task<bool> RegistrarPlantaAsync(PlantaModel planta)
        {
            try
            {
                _logger.LogInformation($"🌱 [API] Registrando planta: {planta.NombrePlanta}");

                // La URL es relativa, el HttpClient ya sabe que va a localhost:5001
                var response = await _httpClient.PostAsJsonAsync("/api/plantas", planta);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError($"❌ [API] Error al guardar planta: {response.StatusCode} - {error}");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error de conexión: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> GuardarTemperaturaAsync(float tempAmbiente, float tempSuelo, string observacion, int idPlanta)
        {
            try
            {
                var datos = new
                {
                    TempAmbiente = tempAmbiente,
                    TempSuelo = tempSuelo,
                    Observacion = observacion,
                    IdPlanta = idPlanta // ✅ Enviamos el ID de la planta
                };

                var response = await _httpClient.PostAsJsonAsync("/api/temperatura", datos);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"❌ Error API Temperatura: {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Excepción guardando temperatura: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> GuardarRegistroClimaticoAsync(float humSuelo, float humAmbiente, float tempAmbiente, float viento, int idPlanta)
        {
            try
            {
                var datos = new
                {
                    HumedadSuelo = humSuelo,
                    HumedadAmbiente = humAmbiente,
                    TemperaturaAmbiente = tempAmbiente,
                    Viento = viento,
                    IdPlanta = idPlanta // ✅ Enviamos la planta
                };

                var response = await _httpClient.PostAsJsonAsync("/api/clima", datos);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error guardando registro climático: {ex.Message}");
                return false;
            }
        }

    }

    // Clase auxiliar para mapear la respuesta de la API
    public class ApiResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; } = "";
        public T? data { get; set; }
    }
}