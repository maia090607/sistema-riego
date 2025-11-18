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

        // ✅ Obtener usuarios (usando UsuarioModel que es el mismo que Usuario)
        public async Task<List<Usuario>?> ObtenerUsuariosAsync()
        {
            try
            {
                _logger.LogInformation("🌐 [API] Obteniendo usuarios...");

                var response = await _httpClient.GetAsync("/api/usuarios");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"❌ [API] Error HTTP {response.StatusCode}");
                    return null;
                }

                // ✅ La API devuelve directamente la lista
                var usuarios = await response.Content.ReadFromJsonAsync<List<Usuario>>();

                _logger.LogInformation($"✅ [API] {usuarios?.Count ?? 0} usuarios obtenidos");
                return usuarios;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error: {ex.Message}");
                return null;
            }
        }
    }
}