using ENTITY;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;
using System.Collections.Generic;
using System.Linq;

namespace RiegoAPI.DTO.Mappers
{
    public class HistorialRiegoMapper
    {
        public static Historial_Riego ToEntity(HistorialRiegoRequestDTO dto)
        {
            if (dto == null) return null;
            return new Historial_Riego
            {
                Fecha = dto.Fecha,
                Humedad = dto.Humedad,
                Temperatura = dto.Temperatura,
                IdPlanta = dto.IdPlanta,

                // ✅ AQUÍ SE PASA EL DATO A LA ENTIDAD
                TipoRiego = dto.TipoRiego
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
                IdPlanta = entity.IdPlanta,
                NombrePlanta = entity.NombrePlanta,
                NombrePropietario = entity.NombrePropietario,
                TipoRiego = entity.TipoRiego
            };
        }

        public static List<HistorialRiegoResponseDTO> ToResponseDTOList(IList<Historial_Riego> entities)
        {
            if (entities == null) return new List<HistorialRiegoResponseDTO>();
            return entities.Select(h => ToResponseDTO(h)).ToList();
        }
    }
}