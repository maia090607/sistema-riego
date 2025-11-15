using ENTITY;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Request;
using RiegoAPI.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RiegoAPI.DTO.Mappers
{
    public class HumedadMapper
    {
        /// Convierte de HumedadRequestDTO a humedad (Entity)
        public static humedad ToEntity(HumedadRequestDTO dto)
        {
            if (dto == null) return null;

            return new humedad
            {
                ValorHumedad = dto.ValorHumedad,
                FechaRegistro = DateTime.Now
            };
        }

        /// Convierte de humedad (Entity) a HumedadResponseDTO
        public static HumedadResponseDTO ToResponseDTO(humedad entity)
        {
            if (entity == null) return null;

            return new HumedadResponseDTO
            {
                IdHumedad = entity.IdHumedad,
                ValorHumedad = entity.ValorHumedad,
                FechaRegistro = entity.FechaRegistro
            };
        }

        /// Convierte lista de humedades a lista de DTOs
        public static List<HumedadResponseDTO> ToResponseDTOList(IList<humedad> entities)
        {
            if (entities == null) return new List<HumedadResponseDTO>();
            return entities.Select(h => ToResponseDTO(h)).ToList();
        }

    }
}
