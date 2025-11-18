using SmartDropUI.Models;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly ILogger<AuthService> _logger;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, ILogger<AuthService> logger)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _logger = logger;
        }

        public async Task<(bool Success, string Message)> LoginAsync(string nombreUsuario, string password)
        {
            try
            {
                _logger.LogInformation($"🔐 Intentando login para: {nombreUsuario}");

                var loginRequest = new { nombreUsuario, password };
                var response = await _httpClient.PostAsJsonAsync("/api/usuarios/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<Usuario>>();

                    if (result?.success == true && result.data != null)
                    {
                        await _localStorage.SetItemAsync("usuario", result.data);
                        _logger.LogInformation($"✅ Login exitoso para: {nombreUsuario}");
                        return (true, "Login exitoso");
                    }
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"❌ Login fallido para {nombreUsuario}: {errorContent}");
                return (false, "Usuario o contraseña incorrectos");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error en login: {ex.Message}");
                return (false, "Error al conectar con el servidor");
            }
        }

        public async Task<(bool Success, string Message)> RegistrarAsync(Usuario usuario)
        {
            try
            {
                _logger.LogInformation($"📝 Registrando usuario: {usuario.NombreUsuario}");

                var response = await _httpClient.PostAsJsonAsync("/api/usuarios", usuario);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"✅ Usuario registrado: {usuario.NombreUsuario}");
                    return (true, "Usuario registrado exitosamente");
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"❌ Error al registrar: {errorContent}");
                return (false, "Error al registrar usuario");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error en registro: {ex.Message}");
                return (false, "Error al conectar con el servidor");
            }
        }

        public async Task<Usuario?> GetUsuarioActualAsync()
        {
            return await _localStorage.GetItemAsync<Usuario>("usuario");
        }

        public async Task LogoutAsync()
        {
            var usuario = await GetUsuarioActualAsync();
            if (usuario != null)
            {
                await _httpClient.PostAsync($"/api/usuarios/logout/{usuario.IdUsuario}", null);
            }
            await _localStorage.RemoveItemAsync("usuario");
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var usuario = await GetUsuarioActualAsync();
            return usuario != null;
        }
    }
}