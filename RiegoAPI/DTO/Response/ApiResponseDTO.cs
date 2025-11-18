using System;

namespace RiegoAPI.DTOs.Response
{
    // Non-generic version for responses without data
    public class ApiResponseDTO
    {
        public bool success { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }

        public ApiResponseDTO()
        {
            timestamp = DateTime.Now;
            message = string.Empty;
        }

        public static ApiResponseDTO Success(string? message = null)
        {
            return new ApiResponseDTO
            {
                success = true,
                message = message ?? "Operación exitosa",
                timestamp = DateTime.Now
            };
        }

        public static ApiResponseDTO Error(string message)
        {
            return new ApiResponseDTO
            {
                success = false,
                message = message ?? "Error desconocido",
                timestamp = DateTime.Now
            };
        }
    }

    // Generic version for responses with data
    public class ApiResponseDTO<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T? data { get; set; }
        public DateTime timestamp { get; set; }

        public ApiResponseDTO()
        {
            timestamp = DateTime.Now;
            message = string.Empty;
            data = default;
        }

        public static ApiResponseDTO<T> Success(T data, string? message = null)
        {
            return new ApiResponseDTO<T>
            {
                success = true,
                message = message ?? "Operación exitosa",
                data = data,
                timestamp = DateTime.Now
            };
        }

        public static ApiResponseDTO<T> Error(string message, T? data = default)
        {
            return new ApiResponseDTO<T>
            {
                success = false,
                message = message ?? "Error desconocido",
                data = data,
                timestamp = DateTime.Now
            };
        }
    }
}