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
                    IsSuccessful = false,
                    Message = "Error: la respuesta del servidor es nula.",
                    Data = data
                };
            }

            return new ApiResponseDTO<T>
            {
                IsSuccessful = dalResponse.Estado,
                Message = dalResponse.Mensaje ?? "Sin mensaje",
                Data = data
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
                    IsSuccessful = false,
                    Message = "Error: la respuesta del servidor es nula.",
                    Data = dtoList
                };
            }

            return new ApiResponseDTO<List<TDto>>
            {
                IsSuccessful = dalResponse.Estado,
                Message = dalResponse.Mensaje ?? "Sin mensaje",
                Data = dtoList
            };
        }
    }
}
