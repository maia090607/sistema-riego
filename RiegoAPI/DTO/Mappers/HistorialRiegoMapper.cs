using ENTITY;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Request;
using RiegoAPI.DTOs.Response;
using System.Collections.Generic;
using System.Linq;


namespace RiegoAPI.DTO.Mappers
{
    public class HistorialRiegoMapper
    {
        /// Convierte de HistorialRiegoRequestDTO a Historial_Riego (Entity)
        public static Historial_Riego ToEntity(HistorialRiegoRequestDTO dto)
        {
            if (dto == null) return null;
            return new Historial_Riego
            {
                Fecha = dto.Fecha,
                Humedad = dto.Humedad,
                Temperatura = dto.Temperatura,
                IdPlanta = dto.IdPlanta // ✅ Mapeamos el ID
            };
        }
        public static HistorialRiegoResponseDTO ToResponseDTO(Historial_Riego entity)
        {
            if (entity == null) return null;
            return new HistorialRiegoResponseDTO
            {
                Id = entity.Id,
                Fecha = entity.Fecha,
                Humedad = entity.Humedad,
                Temperatura = entity.Temperatura,

                // ✅ MAPEO DE NUEVOS CAMPOS
                IdPlanta = entity.IdPlanta,
                NombrePlanta = entity.NombrePlanta,
                NombrePropietario = entity.NombrePropietario
            };
        }
        /// Convierte lista de Historiales a lista de DTOs
        public static List<HistorialRiegoResponseDTO> ToResponseDTOList(IList<Historial_Riego> entities)
        {
            if (entities == null) return new List<HistorialRiegoResponseDTO>();
            return entities.Select(h => ToResponseDTO(h)).ToList();
        }
    }
}
