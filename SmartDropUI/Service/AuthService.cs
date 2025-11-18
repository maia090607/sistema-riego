using SmartDropUI.Models;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace SmartDropUI.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> LoginAsync(string nombreUsuario, string password)
        {
            try
            {
                var loginRequest = new { nombreUsuario, password };
                var response = await _httpClient.PostAsJsonAsync("/api/usuarios/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    // ✅ Cambiar UsuarioModel → Usuario
                    var usuario = await response.Content.ReadFromJsonAsync<Usuario>();

                    if (usuario != null)
                    {
                        await _localStorage.SetItemAsync("usuario", usuario);
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Usuario?> GetUsuarioActualAsync()
        {
            try
            {
                // ✅ Cambiar UsuarioModel → Usuario
                return await _localStorage.GetItemAsync<Usuario>("usuario");
            }
            catch
            {
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("usuario");
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var usuario = await GetUsuarioActualAsync();
            return usuario != null;
        }
    }
}