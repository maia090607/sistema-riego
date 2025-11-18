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
                    success = false,  // ✅ Cambio: IsSuccessful → success
                    message = "Error: la respuesta del servidor es nula.",  // ✅ Cambio: Message → message
                    data = data  // ✅ Cambio: Data → data
                };
            }

            return new ApiResponseDTO<T>
            {
                success = dalResponse.Estado,  // ✅ Cambio
                message = dalResponse.Mensaje ?? "Sin mensaje",  // ✅ Cambio
                data = data  // ✅ Cambio
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
                    success = false,  // ✅ Cambio
                    message = "Error: la respuesta del servidor es nula.",  // ✅ Cambio
                    data = dtoList  // ✅ Cambio
                };
            }

            return new ApiResponseDTO<List<TDto>>
            {
                success = dalResponse.Estado,  // ✅ Cambio
                message = dalResponse.Mensaje ?? "Sin mensaje",  // ✅ Cambio
                data = dtoList  // ✅ Cambio
            };
        }
    }
}