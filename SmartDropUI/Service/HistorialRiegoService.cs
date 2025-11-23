using SmartDropUI.Models;
using System.Net.Http.Json;
using Microsoft.JSInterop; // Necesario para logs en consola

namespace SmartDropUI.Services
{
    public class HistorialRiegoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HistorialRiegoService> _logger;
        private readonly IJSRuntime _js; // Para logs en el navegador

        public HistorialRiegoService(HttpClient httpClient, ILogger<HistorialRiegoService> logger, IJSRuntime js)
        {
            _httpClient = httpClient;
            _logger = logger;
            _js = js;
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
                else
                {
                    // Si falla, mostramos el error en la consola del navegador
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    await _js.InvokeVoidAsync("console.error", $"❌ Error obteniendo historial: {response.StatusCode} - {errorMsg}");
                }

                return new List<HistorialRiegoModel>();
            }
            catch (Exception ex)
            {
                await _js.InvokeVoidAsync("console.error", $"❌ Excepción historial: {ex.Message}");
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
                    idPlanta = historial.IdPlanta,
                    tipoRiego = historial.TipoRiego // ✅ Campo crítico
                };

                var response = await _httpClient.PostAsJsonAsync("/api/historial", requestData);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    await _js.InvokeVoidAsync("console.error", $"❌ Error guardando: {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await _js.InvokeVoidAsync("console.error", $"❌ Excepción guardando: {ex.Message}");
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