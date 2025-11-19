using System.Net.Http.Json;
using SmartDropUI.Models;

namespace RiegoAPI.Service
{
    /// <summary>
    /// Servicio para obtener datos del sensor de humedad del suelo en tiempo real
    /// </summary>
    public class HumedadService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HumedadService> _logger;

        public HumedadService(HttpClient httpClient, ILogger<HumedadService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los registros de humedad de la base de datos
        /// </summary>
        public async Task<List<HumedadModel>> ObtenerTodosAsync()
        {
            try
            {
                _logger.LogInformation("📊 [HUMEDAD] Obteniendo registros de humedad...");

                var response = await _httpClient.GetAsync("/api/humedad");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<HumedadModel>>>();

                    if (result?.success == true && result.data != null)
                    {
                        _logger.LogInformation($"✅ [HUMEDAD] {result.data.Count} registros obtenidos");
                        return result.data;
                    }
                }

                _logger.LogWarning("⚠️ [HUMEDAD] No se pudo obtener datos");
                return new List<HumedadModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [HUMEDAD] Error: {ex.Message}");
                return new List<HumedadModel>();
            }
        }

        /// <summary>
        /// Obtiene el último registro de humedad (valor actual del sensor)
        /// </summary>
        public async Task<HumedadModel?> ObtenerUltimoAsync()
        {
            try
            {
                var todos = await ObtenerTodosAsync();

                if (todos.Any())
                {
                    var ultimo = todos.OrderByDescending(h => h.FechaRegistro).FirstOrDefault();
                    _logger.LogInformation($"💧 [HUMEDAD] Último valor: {ultimo?.ValorHumedad}%");
                    return ultimo;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [HUMEDAD] Error al obtener último: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Obtiene los últimos N registros de humedad para gráficas
        /// </summary>
        public async Task<List<HumedadModel>> ObtenerUltimosAsync(int cantidad = 10)
        {
            try
            {
                var todos = await ObtenerTodosAsync();

                return todos
                    .OrderByDescending(h => h.FechaRegistro)
                    .Take(cantidad)
                    .OrderBy(h => h.FechaRegistro) // Ordenar cronológicamente para la gráfica
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [HUMEDAD] Error: {ex.Message}");
                return new List<HumedadModel>();
            }
        }
    }
}