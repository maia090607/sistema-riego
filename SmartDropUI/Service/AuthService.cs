namespace SmartDropUI.Service
{
    public class AuthService
    {
        public bool IsAuthenticated { get; private set; } = false;
        public string? CurrentUser { get; private set; }

        public event Action? OnAuthStateChanged;

        // Método síncrono original
        public Task<bool> Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                IsAuthenticated = true;
                CurrentUser = username;
                NotifyAuthStateChanged();
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        // Método asíncrono para verificar autenticación
        public Task<bool> IsAuthenticatedAsync()
        {
            return Task.FromResult(IsAuthenticated);
        }

        // Método de logout original
        public void Logout()
        {
            IsAuthenticated = false;
            CurrentUser = null;
            NotifyAuthStateChanged();
        }

        // Método asíncrono de logout
        public Task LogoutAsync()
        {
            IsAuthenticated = false;
            CurrentUser = null;
            NotifyAuthStateChanged();
            return Task.CompletedTask;
        }

        // Método para registrar usuarios
        public Task<(bool success, string message)> RegistrarAsync(string username, string password, string email)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(username))
            {
                return Task.FromResult((false, "El nombre de usuario es requerido"));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult((false, "La contraseña es requerida"));
            }

            if (password.Length < 6)
            {
                return Task.FromResult((false, "La contraseña debe tener al menos 6 caracteres"));
            }

            // Aquí iría la lógica para guardar en base de datos
            // Por ahora solo simulamos éxito
            return Task.FromResult((true, "Usuario registrado exitosamente"));
        }

        private void NotifyAuthStateChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}