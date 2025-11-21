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
                var requestData = new
                {
                    fecha = historial.Fecha,
                    humedad = historial.Humedad,
                    temperatura = historial.Temperatura,
                    idPlanta = historial.IdPlanta // ✅ Enviamos el ID a la API
                };

                var response = await _httpClient.PostAsJsonAsync("/api/historial", requestData);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error guardando historial: {ex.Message}");
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