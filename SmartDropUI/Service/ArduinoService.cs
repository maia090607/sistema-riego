using SmartDropUI.Models;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    public class ArduinoService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ArduinoService> _logger;

        public event Action<DatosArduinoModel>? DatosRecibidos;

        public ArduinoService(HttpClient httpClient, ILogger<ArduinoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> IniciarRiegoManualAsync()
        {
            _logger.LogInformation("📤 [ARDUINO] Enviando MANUAL_ON...");

            try
            {
                var response = await _httpClient.PostAsync("/api/arduino/manual-on", null);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"❌ [ARDUINO] Error HTTP: {response.StatusCode}");
                    return false;
                }

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

                if (result == null)
                {
                    _logger.LogError("❌ [ARDUINO] Respuesta nula");
                    return false;
                }

                _logger.LogInformation($"🔍 Respuesta API: {result.message}");

                // 🔥 ACEPTAR VARIACIONES DE SALIDA DEL ARDUINO
                if (!result.success)
                    return false;

                // 🔥 Permitir múltiples formatos válidos
                string msg = result.message.ToUpper().Replace(" ", "");

                return msg.Contains("OK") &&
                       (msg.Contains("MANUAL_ON") || msg.Contains("MANUALON"));
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [ARDUINO] Excepción: {ex.Message}");
                return false;
            }
        }



        public async Task<bool> DetenerRiegoManualAsync()
        {
            _logger.LogInformation("📤 [ARDUINO] Enviando MANUAL_OFF...");

            try
            {
                var response = await _httpClient.PostAsync("/api/arduino/manual-off", null);

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

                return result != null && result.success && result.message.Contains("OK:MANUAL_OFF");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [ARDUINO] Excepción: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> ActivarModoAutomaticoAsync()
        {
            _logger.LogInformation("📤 [ARDUINO] Enviando AUTO...");

            try
            {
                var response = await _httpClient.PostAsync("/api/arduino/auto", null);

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

                return result != null && result.success && result.message.Contains("OK:AUTO");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [ARDUINO] Excepción: {ex.Message}");
                return false;
            }
        }


        public async Task<DatosArduinoModel?> ObtenerEstadoAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/arduino/estado");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<DatosArduinoModel>>();
                    return result?.data;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [ARDUINO] Error al obtener estado: {ex.Message}");
                return null;
            }
        }

        public bool EstaConectado => true; // Siempre true porque usa HTTP

        public void Dispose()
        {
            // No hay recursos que liberar
        }

        // Clase auxiliar para deserializar respuestas
        private class ApiResponse<T>
        {
            public bool success { get; set; }
            public string message { get; set; } = "";
            public T? data { get; set; }
        }
    }
}