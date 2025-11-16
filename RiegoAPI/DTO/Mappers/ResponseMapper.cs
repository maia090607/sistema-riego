using DAL;
using RiegoAPI.DTOs.Response;

namespace RiegoAPI.DTO.Mappers
{
    public class ResponseMapper
    {
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

        public static ApiResponseDTO<List<TDto>> ToApiResponseList<TEntity, TDto>(
            Response<List<TEntity>>? dalResponse,
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
