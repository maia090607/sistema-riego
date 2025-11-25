using BLL;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTO.Mappers;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Mappers;
using RiegoAPI.DTOs.Request;
using RiegoAPI.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantasController : ControllerBase
    {
        private readonly ServiciosPlanta _serviciosPlanta;
        private readonly ServiciosUsuario _serviciosUsuario; // 🟢 Añadir ServiciosUsuario

        // 🟢 MODIFICAR CONSTRUCTOR para inyectar ambos servicios
        public PlantasController(ServiciosPlanta serviciosPlanta, ServiciosUsuario serviciosUsuario)
        {
            _serviciosPlanta = serviciosPlanta;
            _serviciosUsuario = serviciosUsuario; // 🟢 Asignar ServiciosUsuario
        }

        // GET: api/plantas
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var resultado = _serviciosPlanta.ObtenerTodos();
            var plantasDto = PlantaMapper.ToResponseDTOList(resultado.Lista);

            return Ok(ApiResponseDTO<List<PlantaResponseDTO>>.Success(
                plantasDto,
                $"Se encontraron {plantasDto.Count} plantas"
            ));
        }

        // GET: api/plantas/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponseDTO<object>.Error("El ID debe ser mayor a cero"));

            var resultado = _serviciosPlanta.BuscarPorId(id);

            if (resultado.Estado && resultado.Entidad != null)
            {
                var plantaDto = PlantaMapper.ToResponseDTO(resultado.Entidad);
                return Ok(ApiResponseDTO<PlantaResponseDTO>.Success(
                    plantaDto,
                    "Planta encontrada"
                ));
            }

            return NotFound(ApiResponseDTO<object>.Error($"No se encontró planta con ID {id}"));
        }

        // POST: api/plantas
        [HttpPost]
        public IActionResult Insertar([FromBody] PlantaRequestDTO plantaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponseDTO<object>.Error("Datos inválidos"));

            var existente = _serviciosPlanta.BuscarPorId(plantaDto.IdPlanta);
            if (existente.Estado && existente.Entidad != null)
                return Conflict(ApiResponseDTO<object>.Error($"Ya existe una planta con ID {plantaDto.IdPlanta}"));

            var planta = PlantaMapper.ToEntity(plantaDto);
            var resultado = _serviciosPlanta.Insertar(planta);

            if (resultado.Estado)
            {
                var plantaResponse = PlantaMapper.ToResponseDTO(resultado.Entidad);
                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = planta.IdPlanta },
                    ApiResponseDTO<PlantaResponseDTO>.Success(plantaResponse, resultado.Mensaje)
                );
            }

            return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        // PUT: api/plantas/{id}
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] PlantaRequestDTO plantaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponseDTO<object>.Error("Datos inválidos"));

            if (id != plantaDto.IdPlanta)
                return BadRequest(ApiResponseDTO<object>.Error("El ID no coincide"));

            var plantaExistente = _serviciosPlanta.BuscarPorId(id);

            if (!plantaExistente.Estado || plantaExistente.Entidad == null)
                return NotFound(ApiResponseDTO<object>.Error("Planta no encontrada"));

            // Asumiendo que PlantaMapper.UpdateEntity existe
            // PlantaMapper.UpdateEntity(plantaExistente.Entidad, plantaDto); 

            // Si no existe, puedes hacer el mapeo manual o corregir el mapper:
            // plantaExistente.Entidad.NombrePlanta = plantaDto.NombrePlanta; // etc.

            var resultado = _serviciosPlanta.Actualizar(plantaExistente.Entidad);

            if (resultado.Estado)
            {
                var plantaResponse = PlantaMapper.ToResponseDTO(resultado.Entidad);
                return Ok(ApiResponseDTO<PlantaResponseDTO>.Success(
                    plantaResponse,
                    resultado.Mensaje
                ));
            }

            return NotFound(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        // DELETE: api/plantas/{id}
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponseDTO<object>.Error("El ID debe ser mayor a cero"));

            var resultado = _serviciosPlanta.Eliminar(id);

            if (resultado.Estado)
                return Ok(ApiResponseDTO<object>.Success(null, resultado.Mensaje));

            return NotFound(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        // POST: api/plantas/subir-imagen/{id}
        [HttpPost("subir-imagen/{id}")]
        public async Task<IActionResult> SubirImagen(int id, [FromForm] IFormFile imagen) // Asegurarse de usar [FromForm] si es necesario
        {
            if (imagen == null || imagen.Length == 0)
                return BadRequest(ApiResponseDTO<object>.Error("No se proporcionó imagen"));

            var planta = _serviciosPlanta.BuscarPorId(id);
            if (!planta.Estado || planta.Entidad == null)
                return NotFound(ApiResponseDTO<object>.Error($"No se encontró planta con ID {id}"));

            // Nota: Este código asume que la aplicación está alojada con acceso a disco local (wwwroot)
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagenes", "plantas");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{id}_{Guid.NewGuid()}{Path.GetExtension(imagen.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }

                planta.Entidad.RutaImagen = $"/imagenes/plantas/{fileName}";
                _serviciosPlanta.Actualizar(planta.Entidad);

                return Ok(ApiResponseDTO<object>.Success(
                    new { rutaImagen = planta.Entidad.RutaImagen },
                    "Imagen subida correctamente"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<object>.Error($"Error al subir la imagen: {ex.Message}"));
            }
        }

        [HttpGet("usuario/{idUsuario}")]
        public IActionResult ObtenerPorUsuario(int idUsuario)
        {
            var resultado = _serviciosPlanta.ObtenerPorUsuario(idUsuario);
            var plantasDto = PlantaMapper.ToResponseDTOList(resultado.Lista);

            return Ok(ApiResponseDTO<List<PlantaResponseDTO>>.Success(
                plantasDto,
                $"Se encontraron {plantasDto.Count} plantas para el usuario {idUsuario}"
            ));
        }

        // GET: api/plantas/usuario/mapear-telefono?telefono={numero_telefono}
        [HttpGet("usuario/mapear-telefono")]
        public IActionResult MapearTelefonoAId([FromQuery] string telefono)
        {
            if (string.IsNullOrEmpty(telefono))
            {
                return BadRequest(ApiResponseDTO<object>.Error("El número de teléfono es requerido."));
            }

            // 🟢 CÓDIGO CORREGIDO: Llama a ServiciosUsuario
            var resultadoMapeo = _serviciosUsuario.MapearTelefonoAId(telefono);

            if (resultadoMapeo.Estado && resultadoMapeo.Entidad != null)
            {
                // La entidad es un objeto Usuario, accedemos a su IdUsuario
                return Ok(ApiResponseDTO<object>.Success(
                    new { idUsuario = resultadoMapeo.Entidad.IdUsuario }, // 🟢 Acceder a la Entidad (Usuario) y luego a IdUsuario
                    "Mapeo de ID exitoso"
                ));
            }

            // Si no se encuentra el usuario
            return NotFound(ApiResponseDTO<object>.Error($"No se encontró usuario con el teléfono {telefono}"));
        }
    }
}