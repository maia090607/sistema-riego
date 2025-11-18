namespace SmartDropUI.Models
{
    /// <summary>
    /// Clase Usuario para operaciones de autenticación y API
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; } = "";
        public string NombreCompleto { get; set; } = "";
        public string Email { get; set; } = "";
        public string Correo { get; set; } = "";
        public string NombreUsuario { get; set; } = "";
        public string clave { get; set; } = "";
        public string Contrasena { get; set; } = "";
        public string Password { get; set; } = "";  // ✅ Alias para la API
        public string Rol { get; set; } = "";
        public string RutaImagen { get; set; } = "";
        public bool Accedio { get; set; }
    }
}