using SmartDropUI.Components.Pages;
using SmartDropUI.Models;
using System;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<bool> GuardarRiegoAsync(HistorialRiegoModel historial)
        {
            try
            {
                _logger.LogInformation("═══════════════════════════════════════");
                _logger.LogInformation($"💾 [SERVICE] INICIANDO GUARDADO");
                _logger.LogInformation($"📅 Fecha: {historial.Fecha}");
                _logger.LogInformation($"💧 Humedad: {historial.Humedad}%");
                _logger.LogInformation($"🌡️ Temperatura: {historial.Temperatura}°C");
                _logger.LogInformation("═══════════════════════════════════════");

                var requestData = new
                {
                    fecha = historial.Fecha,
                    humedad = historial.Humedad,
                    temperatura = historial.Temperatura
                };

                _logger.LogInformation($"📦 Request Data: {System.Text.Json.JsonSerializer.Serialize(requestData)}");

                var response = await _httpClient.PostAsJsonAsync("/api/historial", requestData);

                _logger.LogInformation($"📡 Status Code: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _logger.LogInformation($"✅ Respuesta: {content}");
                    return true;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"⚠️ Error: {errorContent}");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Excepción: {ex.Message}");
                _logger.LogError($"❌ Stack: {ex.StackTrace}");
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