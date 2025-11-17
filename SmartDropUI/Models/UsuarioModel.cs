namespace SmartDropUI.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}