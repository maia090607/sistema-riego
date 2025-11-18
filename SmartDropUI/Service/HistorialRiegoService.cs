using System.Net.Http.Json;
using SmartDropUI.Models;

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

        // ✅ Obtener todo el historial
        public async Task<List<HistorialRiegoModel>> ObtenerHistorialAsync()
        {
            try
            {
                _logger.LogInformation("📋 Obteniendo historial de riego...");

                var response = await _httpClient.GetAsync("/api/historial");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<HistorialRiegoModel>>>();

                    if (result?.success == true && result.data != null)
                    {
                        _logger.LogInformation($"✅ {result.data.Count} registros obtenidos");
                        return result.data;
                    }
                }

                _logger.LogWarning("⚠️ No se pudo obtener el historial");
                return new List<HistorialRiegoModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al obtener historial: {ex.Message}");
                return new List<HistorialRiegoModel>();
            }
        }

        // ✅ Guardar nuevo registro de riego
        public async Task<bool> GuardarRiegoAsync(HistorialRiegoModel historial)
        {
            try
            {
                _logger.LogInformation("💾 Guardando registro de riego...");

                var requestData = new
                {
                    fecha = historial.Fecha,
                    humedad = historial.Humedad,
                    temperatura = historial.Temperatura
                };

                var response = await _httpClient.PostAsJsonAsync("/api/historial", requestData);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("✅ Registro guardado correctamente");
                    return true;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"⚠️ No se pudo guardar el registro: {errorContent}");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al guardar: {ex.Message}");
                return false;
            }
        }

        // ✅ Obtener historial por fecha
        public async Task<List<HistorialRiegoModel>> ObtenerPorFechaAsync(DateTime fecha)
        {
            try
            {
                var fechaStr = fecha.ToString("yyyy-MM-dd");
                var response = await _httpClient.GetAsync($"/api/historial/por-fecha?fecha={fechaStr}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<HistorialRiegoModel>>>();
                    return result?.data ?? new List<HistorialRiegoModel>();
                }

                return new List<HistorialRiegoModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error: {ex.Message}");
                return new List<HistorialRiegoModel>();
            }
        }

        // ✅ Obtener último riego
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
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al obtener último riego: {ex.Message}");
                return null;
            }
        }
    }
}