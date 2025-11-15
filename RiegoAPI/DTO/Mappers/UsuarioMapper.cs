using ENTITY;
using RiegoAPI.DTOs.Request;
using RiegoAPI.DTOs.Response;
using System.Collections.Generic;
using System.Linq;

namespace RiegoAPI.DTOs.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario ToEntity(UsuarioRequestDTO dto)
        {
            if (dto == null) return null;

            return new Usuario
            {
                IdUsuario = dto.IdUsuario,
                Nombre = dto.Nombre,
                Email = dto.Email,
                NombreUsuario = dto.NombreUsuario,
                Password = dto.Password,
                Rol = dto.Rol,
                RutaImagen = dto.RutaImagen,
                Accedio = false
            };
        }

        public static UsuarioResponseDTO ToResponseDTO(Usuario entity)
        {
            if (entity == null) return null;

            return new UsuarioResponseDTO
            {
                IdUsuario = entity.IdUsuario,
                Nombre = entity.Nombre,
                Email = entity.Email,
                NombreUsuario = entity.NombreUsuario,
                Rol = entity.Rol,
                RutaImagen = entity.RutaImagen,
                Accedio = entity.Accedio
            };
        }

        public static List<UsuarioResponseDTO> ToResponseDTOList(IList<Usuario> entities)
        {
            if (entities == null) return new List<UsuarioResponseDTO>();
            return entities.Select(u => ToResponseDTO(u)).ToList();
        }
    }
}