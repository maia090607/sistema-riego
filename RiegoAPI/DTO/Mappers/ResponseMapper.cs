using DAL;
using RiegoAPI.DTOs.Response;

namespace RiegoAPI.DTO.Mappers
{
    public class ResponseMapper
    {
        /// Convierte un Response de DAL a ApiResponseDTO
        public static ApiResponseDTO<T> ToApiResponse<T>(Response<T> dalResponse, T data = default)
        {
            return new ApiResponseDTO<T>
            {
                Estado = dalResponse.Estado,
                Mensaje = dalResponse.Mensaje,
                Datos = data
            };
        }

        /// Convierte un Response de DAL con lista a ApiResponseDTO con lista de DTOs
        public static ApiResponseDTO<System.Collections.Generic.List<TDto>> ToApiResponseList<TEntity, TDto>(
            Response<TEntity> dalResponse,
            System.Collections.Generic.List<TDto> dtoList)
        {
            return new ApiResponseDTO<System.Collections.Generic.List<TDto>>
            {
                Estado = dalResponse.Estado,
                Mensaje = dalResponse.Mensaje,
                Datos = dtoList
            };
        }
    }
}
