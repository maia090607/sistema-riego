using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class LoginResponseDTO
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public UsuarioResponseDTO Usuario { get; set; }
        public string Token { get; set; } 
    }
}