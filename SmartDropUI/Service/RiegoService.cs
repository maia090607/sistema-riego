using SmartDropUI.Models;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    public class RiegoService
    {
        private readonly HttpClient _httpClient;

        public RiegoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DatosRiegoModel>> ObtenerHistorialAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<DatosRiegoModel>>("api/riego/historial")
                       ?? new List<DatosRiegoModel>();
            }
            catch
            {
                return new List<DatosRiegoModel>();
            }
        }

        public async Task<bool> IniciarRiegoManualAsync()
        {
            try
            {
                var response = await _httpClient.PostAsync("api/riego/iniciar", null);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<DatosRiegoModel?> ObtenerDatosActualesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<DatosRiegoModel>("api/riego/actual");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {   
            try
            {
                var response = await _httpClient.GetAsync("api/usuarios");

                if (!response.IsSuccessStatusCode)
                    return new List<Usuario>();

                var data = await response.Content.ReadFromJsonAsync<List<Usuario>>();
                return data ?? new List<Usuario>();
            }
            catch
            {
                return new List<Usuario>();
            }
        }


    }
}