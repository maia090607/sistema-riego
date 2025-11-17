using Blazored.LocalStorage;
using SmartDropUI.Models;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    /// <summary>
    /// Servicio de autenticación y gestión de usuarios
    /// </summary>
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        // 👉 Dejar true mientras pruebas sin API
        private const bool MODO_PRUEBA = true;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // LOGIN
        // --------------------------------------------------------------------------------------------------------------------
        public async Task<bool> LoginAsync(LoginModel login)
        {
            if (MODO_PRUEBA)
            {
                var usuariosValidos = new Dictionary<string, (string password, string rol)>
                {
                    { "admin", ("admin123", "admin") },
                    { "operario", ("operario123", "operario") },
                    { "usuario", ("usuario123", "usuario") }
                };

                if (usuariosValidos.ContainsKey(login.Usuario) &&
                    usuariosValidos[login.Usuario].password == login.Password)
                {
                    await _localStorage.SetItemAsync("userName", login.Usuario);
                    await _localStorage.SetItemAsync("userRole", usuariosValidos[login.Usuario].rol);
                    return true;
                }
                return false;
            }
            else
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync("api/auth/login", login);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                        if (result != null && result.Success)
                        {
                            await _localStorage.SetItemAsync("userName", result.Usuario);
                            await _localStorage.SetItemAsync("userRole", result.Rol);
                            return true;
                        }
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en login: {ex.Message}");
                    return false;
                }
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // REGISTRO
        // --------------------------------------------------------------------------------------------------------------------
        public async Task<bool> RegistrarAsync(UsuarioModel usuario)
        {
            if (MODO_PRUEBA)
            {
                await Task.Delay(500);
                return true;
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/registro", usuario);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en registro: {ex.Message}");
                return false;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // LOGOUT
        // --------------------------------------------------------------------------------------------------------------------
        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("userName");
            await _localStorage.RemoveItemAsync("userRole");
        }

        // --------------------------------------------------------------------------------------------------------------------
        // VALIDACIONES
        // --------------------------------------------------------------------------------------------------------------------
        public async Task<bool> IsAuthenticatedAsync()
        {
            var userName = await _localStorage.GetItemAsync<string>("userName");
            return !string.IsNullOrEmpty(userName);
        }

        public async Task<string?> GetUserNameAsync()
        {
            return await _localStorage.GetItemAsync<string>("userName");
        }

        public async Task<string?> GetUserRoleAsync()
        {
            return await _localStorage.GetItemAsync<string>("userRole");
        }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}

