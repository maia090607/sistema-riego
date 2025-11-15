using System.ComponentModel.DataAnnotations;


namespace RiegoAPI.DTOs.Request
{

    public class LoginRequestDTO
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}