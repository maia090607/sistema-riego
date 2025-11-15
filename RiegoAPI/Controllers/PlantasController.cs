using Microsoft.AspNetCore.Mvc;
using BLL;
using ENTITY;
using DAL;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantasController : ControllerBase
    {
        private readonly ServiciosPlanta _serviciosPlanta;

        public PlantasController(ServiciosPlanta serviciosPlanta)
        {
            _serviciosPlanta = serviciosPlanta;
        }

        // GET: api/plantas
        [HttpGet]
        public ActionResult<Response<Cultivo>> ObtenerTodos()
        {
            var resultado = _serviciosPlanta.ObtenerTodos();
            return Ok(resultado);
        }

        // GET: api/plantas/{id}
        [HttpGet("{id}")]
        public ActionResult<Response<Cultivo>> ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosPlanta.BuscarPorId(id);

            if (resultado.Entidad == null)
                return NotFound($"No se encontró planta con ID {id}");

            return Ok(resultado);
        }

        // POST: api/plantas
        [HttpPost]
        public ActionResult<Response<Cultivo>> Insertar([FromBody] Cultivo cultivo)
        {
            if (cultivo == null)
                return BadRequest("La planta no puede ser nula");

            var existente = _serviciosPlanta.BuscarPorId(cultivo.IdPlanta);
            if (existente.Estado)
                return Conflict($"Ya existe una planta con ID {cultivo.IdPlanta}");

            var resultado = _serviciosPlanta.Insertar(cultivo);

            if (resultado.Estado)
                return CreatedAtAction(nameof(ObtenerPorId), new { id = cultivo.IdPlanta }, resultado);

            return BadRequest(resultado.Mensaje);
        }

        // PUT: api/plantas/{id}
        [HttpPut("{id}")]
        public ActionResult<Response<Cultivo>> Actualizar(int id, [FromBody] Cultivo cultivo)
        {
            if (id != cultivo.IdPlanta)
                return BadRequest("El ID no coincide");

            var resultado = _serviciosPlanta.Actualizar(cultivo);

            if (resultado.Estado)
                return Ok(resultado);

            return NotFound(resultado.Mensaje);
        }

        // DELETE: api/plantas/{id}
        [HttpDelete("{id}")]
        public ActionResult<Response<Cultivo>> Eliminar(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor a cero");

            var resultado = _serviciosPlanta.Eliminar(id);

            if (resultado.Estado)
                return Ok(resultado);

            return NotFound(resultado.Mensaje);
        }

        // POST: api/plantas/subir-imagen/{id}
        [HttpPost("subir-imagen/{id}")]
        public async Task<ActionResult> SubirImagen(int id, IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
                return BadRequest("No se proporcionó imagen");

            var planta = _serviciosPlanta.BuscarPorId(id);
            if (planta.Entidad == null)
                return NotFound($"No se encontró planta con ID {id}");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagenes", "plantas");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{id}_{Guid.NewGuid()}{Path.GetExtension(imagen.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            planta.Entidad.RutaImagen = $"/imagenes/plantas/{fileName}";
            _serviciosPlanta.Actualizar(planta.Entidad);

            return Ok(new { rutaImagen = planta.Entidad.RutaImagen });
        }
    }
}