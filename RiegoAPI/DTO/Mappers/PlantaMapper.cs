using ENTITY;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Request;
using RiegoAPI.DTOs.Response;
using System.Collections.Generic;
using System.Linq;


namespace RiegoAPI.DTO.Mappers
{
    public class PlantaMapper
    {
        /// Convierte de PlantaRequestDTO a Cultivo (Entity)
        public static Cultivo ToEntity(PlantaRequestDTO dto)
        {
            if (dto == null) return null;
            return new Cultivo
            {
                IdPlanta = dto.IdPlanta,
                NombrePlanta = dto.NombrePlanta,
                Descripcion = dto.Descripcion,
                RutaImagen = dto.RutaImagen,
                nivel_optimo_humedad = dto.NivelOptimoHumedad,
                nivel_optimo_temperatura = dto.NivelOptimoTemperatura,
                nivel_optimo_luz = dto.NivelOptimoLuz,
                IdUsuario = dto.IdUsuario // ✅ IMPORTANTE: Asignar el usuario
            };
        }

        /// Convierte de Cultivo (Entity) a PlantaResponseDTO
        public static PlantaResponseDTO ToResponseDTO(Cultivo entity)
        {
            if (entity == null) return null;
            return new PlantaResponseDTO
            {
                IdPlanta = entity.IdPlanta,
                NombrePlanta = entity.NombrePlanta,
                Descripcion = entity.Descripcion,
                RutaImagen = entity.RutaImagen,
                NivelOptimoHumedad = entity.nivel_optimo_humedad,
                NivelOptimoTemperatura = entity.nivel_optimo_temperatura,
                NivelOptimoLuz = entity.nivel_optimo_luz,
                IdUsuario = entity.IdUsuario 
            };
        }

        /// Convierte lista de Cultivos a lista de DTOs
        public static List<PlantaResponseDTO> ToResponseDTOList(IList<Cultivo> entities)
        {
            if (entities == null) return new List<PlantaResponseDTO>();
            return entities.Select(p => ToResponseDTO(p)).ToList();
        }

        /// Actualiza un Cultivo existente con datos del DTO
        public static void UpdateEntity(Cultivo entity, PlantaRequestDTO dto)
        {
            if (entity == null || dto == null) return;

            entity.NombrePlanta = dto.NombrePlanta;
            entity.Descripcion = dto.Descripcion;
            entity.RutaImagen = dto.RutaImagen;
            entity.nivel_optimo_humedad = dto.NivelOptimoHumedad;
            entity.nivel_optimo_temperatura = dto.NivelOptimoTemperatura;
            entity.nivel_optimo_luz = dto.NivelOptimoLuz;
        }

    }
}
