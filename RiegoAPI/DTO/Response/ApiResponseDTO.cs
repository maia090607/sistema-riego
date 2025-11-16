using System;
using System.Collections.Generic;

//namespace RiegoAPI.DTOs.Response
//{
//    public class ApiResponseDTO<T>
//    {
//        public bool Estado { get; set; }
//        public string Mensaje { get; set; }
//        public T Datos { get; set; }

//        internal static object? Success(UsuarioResponseDTO usuarioDto, string v)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}


using System;

namespace RiegoAPI.DTOs.Response
{
    public class ApiResponseDTO<T>
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;

        // Constructor vacío
        public ApiResponseDTO() { }

        // Constructor con parámetros
        public ApiResponseDTO(bool estado, string mensaje, T datos)
        {
            Estado = estado;
            Mensaje = mensaje;
            Datos = datos;
            FechaHora = DateTime.Now;
        }

        // ⭐ Método para éxito
        public static ApiResponseDTO<T> Success(T datos, string mensaje = "Operación exitosa")
        {
            return new ApiResponseDTO<T>
            {
                Estado = true,
                Mensaje = mensaje,
                Datos = datos,
                FechaHora = DateTime.Now
            };
        }

        // ⭐ Método para error
        public static ApiResponseDTO<T> Error(string mensaje, T datos = default)
        {
            return new ApiResponseDTO<T>
            {
                Estado = false,
                Mensaje = mensaje,
                Datos = datos,
                FechaHora = DateTime.Now
            };
        }
    }
}