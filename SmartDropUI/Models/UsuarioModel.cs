namespace SmartDropUI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int Identificacion { get; set; }  // ✅ AGREGADO
        public string Nombre { get; set; } = "";
        public string NombreCompleto { get; set; } = "";  // ✅ AGREGADO
        public string Email { get; set; } = "";
        public string Correo { get; set; } = "";  // ✅ AGREGADO (alias de Email)
        public string NombreUsuario { get; set; } = "";
        public string Password { get; set; } = "";
        public string Contrasena { get; set; } = "";  // ✅ AGREGADO (alias de Password)
        public string Rol { get; set; } = "";
        public string RutaImagen { get; set; } = "";
        public bool Accedio { get; set; }
    }
}