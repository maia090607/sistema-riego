using Blazored.LocalStorage;
using SmartDropUI.Models;
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

        public async Task<bool> LoginAsync(LoginModel login)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", login);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    await _localStorage.SetItemAsync("authToken", token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RegistrarAsync(UsuarioModel usuario)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/registro", usuario);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return !string.IsNullOrEmpty(token);
        }
    }
}