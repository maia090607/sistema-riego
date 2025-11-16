using DAL;
using RiegoAPI.DTOs.Response;

namespace RiegoAPI.DTO.Mappers
{
    public class ResponseMapper
    {
        /// Convierte un Response de DAL a ApiResponseDTO
        public static ApiResponseDTO<T> ToApiResponse<T>(Response<T>? dalResponse, T data = default!)
        {
            if (dalResponse == null)
            {
                return new ApiResponseDTO<T>
                {
                    Estado = false,
                    Mensaje = "Error: la respuesta del servidor es nula.",
                    Datos = data
                };
            }

            return new ApiResponseDTO<T>
            {
                Estado = dalResponse.Estado,
                Mensaje = dalResponse.Mensaje ?? "Sin mensaje",
                Datos = data
            };
        }

        /// Convierte un Response de DAL con lista a ApiResponseDTO con lista de DTOs
        public static ApiResponseDTO<List<TDto>> ToApiResponseList<TEntity, TDto>(
            Response<TEntity>? dalResponse,
            List<TDto> dtoList)
        {
            if (dalResponse == null)
            {
                return new ApiResponseDTO<List<TDto>>
                {
                    Estado = false,
                    Mensaje = "Error: la respuesta del servidor es nula.",
                    Datos = dtoList
                };
            }

            return new ApiResponseDTO<List<TDto>>
            {
                Estado = dalResponse.Estado,
                Mensaje = dalResponse.Mensaje ?? "Sin mensaje",
                Datos = dtoList
            };
        }
    }
}
