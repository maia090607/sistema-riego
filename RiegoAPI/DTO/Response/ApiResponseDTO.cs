using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class ApiResponseDTO<T>
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
    }
}
