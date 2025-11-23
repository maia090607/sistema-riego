using SmartDropUI.Models;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    public class HistorialRiegoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HistorialRiegoService> _logger;

        public HistorialRiegoService(HttpClient httpClient, ILogger<HistorialRiegoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<HistorialRiegoModel>> ObtenerHistorialAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/historial");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<HistorialRiegoModel>>>();
                    if (result?.success == true && result.data != null)
                    {
                        return result.data;
                    }
                }
                return new List<HistorialRiegoModel>();
            }
            catch
            {
                return new List<HistorialRiegoModel>();
            }
        }

        public async Task<bool> GuardarRiegoAsync(HistorialRiegoModel historial)
        {
            try
            {
                // ✅ CORRECCIÓN: Ahora enviamos todos los datos, incluido TipoRiego
                var requestData = new
                {
                    fecha = historial.Fecha,
                    humedad = historial.Humedad,
                    temperatura = historial.Temperatura,
                    idPlanta = historial.IdPlanta,
                    tipoRiego = historial.TipoRiego // <--- ESTO FALTABA
                };

                var response = await _httpClient.PostAsJsonAsync("/api/historial", requestData);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"❌ Error API: {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Excepción enviando historial: {ex.Message}");
                return false;
            }
        }

        public async Task<HistorialRiegoModel?> ObtenerUltimoRiegoAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/historial/ultimo");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<HistorialRiegoModel>>();
                    return result?.data;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}