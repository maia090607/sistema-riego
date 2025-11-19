using Blazored.LocalStorage;
using SmartDropUI.Components;
using SmartDropUI.Models;
using SmartDropUI.Services;
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

                // ✅ Crear objeto con los campos exactos que espera la API
                var usuarioAPI = new
                {
                    idUsuario = usuario.IdUsuario,
                    nombre = usuario.Nombre,
                    email = usuario.Email,
                    nombreUsuario = usuario.NombreUsuario,
                    password = usuario.Password,
                    rol = usuario.Rol,
                    rutaImagen = ""
                };

                var response = await _httpClient.PostAsJsonAsync("/api/usuarios", usuarioAPI);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"✅ Usuario registrado: {usuario.NombreUsuario}");
                    return (true, "Usuario registrado exitosamente");
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"❌ Error al registrar: {errorContent}");

                if (errorContent.Contains("ya existe") || errorContent.Contains("Conflict"))
                {
                    return (false, "El usuario o identificación ya existe");
                }

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
            try
            {
                return await _localStorage.GetItemAsync<Usuario>("usuario");
            }
            catch
            {
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            try
            {
                var usuario = await GetUsuarioActualAsync();
                if (usuario != null)
                {
                    await _httpClient.PostAsync($"/api/usuarios/logout/{usuario.IdUsuario}", null);
                }
                await _localStorage.RemoveItemAsync("usuario");
                _logger.LogInformation("🚪 Sesión cerrada");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error en logout: {ex.Message}");
            }
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var usuario = await GetUsuarioActualAsync();
            return usuario != null;
        }
    }
}
