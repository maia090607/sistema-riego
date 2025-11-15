using System.ComponentModel.DataAnnotations;

namespace RiegoAPI.DTOs.Request
{
    public class UsuarioRequestDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string RutaImagen { get; set; }
        public bool Accedio { get; set; }
    }
}
