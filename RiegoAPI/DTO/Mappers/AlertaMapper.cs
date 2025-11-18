using ENTITY;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;
using System.Collections.Generic;
using System.Linq;

namespace RiegoAPI.DTO.Mappers
{
    public class AlertaMapper
    {
        public static Alertas ToEntity(AlertaRequestDTO dto)
        {
            if (dto == null)
                return new Alertas(); // Nunca retorna null

            return new Alertas
            {
                IdAlerta = dto.IdAlerta,
                FechaHora = dto.FechaHora,
                TipoAlerta = dto.TipoAlerta,
                Descripcion = dto.Descripcion,
                NivelCritico = dto.NivelCritico,
                Estado = dto.Estado
            };
        }

        public static AlertaResponseDTO ToResponseDTO(Alertas entity)
        {
            if (entity == null)
                return new AlertaResponseDTO(); // Evita null

            return new AlertaResponseDTO
            {
                IdAlerta = entity.IdAlerta,
                FechaHora = entity.FechaHora,
                TipoAlerta = entity.TipoAlerta,
                Descripcion = entity.Descripcion,
                NivelCritico = entity.NivelCritico,
                Estado = entity.Estado
            };
        }

        public static List<AlertaResponseDTO> ToResponseDTOList(IList<Alertas> entities)
        {
            if (entities == null || entities.Count == 0)
                return new List<AlertaResponseDTO>();

            return entities
                .Select(a => ToResponseDTO(a))
                .ToList();
        }

        /// Actualiza una Alerta existente con datos del DTO
        public static void UpdateEntity(Alertas entity, AlertaRequestDTO dto)
        {
            if (entity == null || dto == null)
                return;

            entity.FechaHora = dto.FechaHora;
            entity.TipoAlerta = dto.TipoAlerta;
            entity.Descripcion = dto.Descripcion;
            entity.NivelCritico = dto.NivelCritico;
            entity.Estado = dto.Estado;
        }
    }
}
