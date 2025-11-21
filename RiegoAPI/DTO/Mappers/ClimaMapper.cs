using Entity;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RiegoAPI.DTO.Mappers
{
    public class ClimaMapper
    {
        public static RegistroClimatico ToEntity(RegistroClimaticoRequestDTO dto)
        {
            if (dto == null) return null;
            return new RegistroClimatico
            {
                Humedad_Suelo = dto.HumedadSuelo,
                Humedad_Ambiente = dto.HumedadAmbiente,
                Temperatura_Ambiente = dto.TemperaturaAmbiente,
                Viento = dto.Viento,
                IdPlanta = dto.IdPlanta, // ✅ Mapear ID
                Fecha = DateTime.Now
            };
        }

        /// Convierte de RegistroClimatico (Entity) a RegistroClimaticoResponseDTO
        public static RegistroClimaticoResponseDTO ToResponseDTO(RegistroClimatico entity)
        {
            if (entity == null) return null;

            return new RegistroClimaticoResponseDTO
            {
                IdRegistro = entity.IdRegistro,
                Fecha = entity.Fecha,
                HumedadSuelo = entity.Humedad_Suelo,
                HumedadAmbiente = entity.Humedad_Ambiente,
                TemperaturaAmbiente = entity.Temperatura_Ambiente,
                Viento = entity.Viento
            };
        }

        /// Convierte lista de RegistrosClimaticos a lista de DTOs
        public static List<RegistroClimaticoResponseDTO> ToResponseDTOList(IList<RegistroClimatico> entities)
        {
            if (entities == null) return new List<RegistroClimaticoResponseDTO>();
            return entities.Select(c => ToResponseDTO(c)).ToList();
        }

    }
}
