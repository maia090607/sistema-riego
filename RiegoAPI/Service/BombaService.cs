using Microsoft.Extensions.Logging;
using RiegoAPI.DTO.Response;
using RiegoAPI.DTO.Response.SmartDropUI.DTO.Response;
using RiegoAPI.DTOs.Response;
using RiegoAPI.Models;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    public class BombaService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BombaService>? _logger;

        public BombaService(HttpClient httpClient, ILogger<BombaService>? logger = null)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ResultadoOperacion> EncenderBombaAsync()
        {
            try
            {
                _logger?.LogInformation("Intentando encender bomba...");

                var response = await _httpClient.PostAsync("api/bomba/encender", null);

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadFromJsonAsync<ApiResponse>();

                    return new ResultadoOperacion
                    {
                        Exitoso = true,
                        Mensaje = resultado?.message ?? "Bomba encendida",
                        FechaHora = resultado?.timestamp ?? DateTime.Now
                    };
                }

                return new ResultadoOperacion
                {
                    Exitoso = false,
                    Mensaje = "No se pudo encender la bomba"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exitoso = false,
                    Mensaje = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<ResultadoOperacion> ApagarBombaAsync()
        {
            try
            {
                _logger?.LogInformation("Intentando apagar bomba...");

                var response = await _httpClient.PostAsync("api/bomba/apagar", null);

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadFromJsonAsync<ApiResponse>();

                    return new ResultadoOperacion
                    {
                        Exitoso = true,
                        Mensaje = resultado?.message ?? "Bomba apagada",
                        FechaHora = resultado?.timestamp ?? DateTime.Now
                    };
                }

                return new ResultadoOperacion
                {
                    Exitoso = false,
                    Mensaje = "No se pudo apagar la bomba"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exitoso = false,
                    Mensaje = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<EstadoBomba> ObtenerEstadoAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<EstadoBombaResponse>("api/bomba/estado");

                return new EstadoBomba
                {
                    Encendida = response?.encendida ?? false,
                    FechaActualizacion = response?.timestamp ?? DateTime.Now
                };
            }
            catch
            {
                return new EstadoBomba
                {
                    Encendida = false,
                    FechaActualizacion = DateTime.Now
                };
            }
        }

        public async Task<DatosSensoresModel?> ObtenerDatosSensoresAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<SensoresResponse>("api/bomba/sensores");

                if (response?.success == true && response.datos != null)
                {
                    return new DatosSensoresModel
                    {
                        Temperatura = response.datos.Temperatura,
                        Humedad = response.datos.Humedad,
                        HumedadSuelo = response.datos.HumedadSuelo,
                        FechaLectura = response.datos.FechaLectura
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ConexionArduino> VerificarConexionAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ConexionResponseDTO>("api/bomba/conexion");

                return new ConexionArduino
                {
                    Conectado = response?.conectado ?? false,
                    Puerto = response?.puerto ?? "Desconocido",
                    FechaVerificacion = response?.timestamp ?? DateTime.Now
                };
            }
            catch
            {
                return new ConexionArduino
                {
                    Conectado = false,
                    Puerto = "Error",
                    FechaVerificacion = DateTime.Now
                };
            }
        }
    }
}
