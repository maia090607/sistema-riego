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

        // ... [Otros métodos sin cambios] ...
        // ✅ Obtener Usuarios
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

        // ✅ Obtener Plantas
        public async Task<List<PlantaModel>?> ObtenerPlantasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/plantas");
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<PlantaModel>>>();
                    return apiResponse?.data ?? new List<PlantaModel>();
                }
                return new List<PlantaModel>();
            }
            catch
            {
                return new List<PlantaModel>();
            }
        }

        // ✅ Obtener Plantas por Usuario
        public async Task<List<PlantaModel>?> ObtenerPlantasPorUsuarioAsync(int idUsuario)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/plantas/usuario/{idUsuario}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<PlantaModel>>>();
                    return result?.data ?? new List<PlantaModel>();
                }
                return new List<PlantaModel>();
            }
            catch
            {
                return new List<PlantaModel>();
            }
        }

        // ✅ Registrar Planta
        public async Task<bool> RegistrarPlantaAsync(PlantaModel planta)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/plantas", planta);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [API] Error: {ex.Message}");
                return false;
            }
        }

        // ✅ Guardar Temperatura
        public async Task<bool> GuardarTemperaturaAsync(float tempAmbiente, float tempSuelo, string observacion, int idPlanta)
        {
            try
            {
                var datos = new
                {
                    TempAmbiente = tempAmbiente,
                    TempSuelo = tempSuelo,
                    Observacion = observacion,
                    IdPlanta = idPlanta
                };
                var response = await _httpClient.PostAsJsonAsync("/api/temperatura", datos);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error guardando temperatura: {ex.Message}");
                return false;
            }
        }

        // ✅ Guardar Registro Climático
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
                    IdPlanta = idPlanta
                };
                var response = await _httpClient.PostAsJsonAsync("/api/clima", datos);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error guardando clima: {ex.Message}");
                return false;
            }
        }

        // ✅ ACTUALIZAR CON MENSAJE DE ERROR
        public async Task<(bool Success, string Message)> ActualizarUsuarioAsync(Usuario usuario)
        {
            try
            {
                var usuarioDto = new
                {
                    IdUsuario = usuario.IdUsuario,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    NombreUsuario = usuario.NombreUsuario,
                    Password = usuario.Password,
                    Rol = usuario.Rol,
                    RutaImagen = usuario.RutaImagen,
                    Accedio = usuario.Accedio
                };

                var response = await _httpClient.PutAsJsonAsync($"/api/usuarios/{usuario.IdUsuario}", usuarioDto);

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Actualizado correctamente");
                }

                // Leer el error que manda el servidor
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, errorContent);
            }
            catch (Exception ex)
            {
                return (false, $"Error de conexión: {ex.Message}");
            }
        }
    }

    public class ApiResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; } = "";
        public T? data { get; set; }
    }
}