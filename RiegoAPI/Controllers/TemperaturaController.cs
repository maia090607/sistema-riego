using BLL;
using ENTITY;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTOs.Response;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperaturaController : ControllerBase
    {
        private readonly ServicioTemperatura _servicio;

        public TemperaturaController(ServicioTemperatura servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] Temperatura temperatura)
        {
            var resultado = _servicio.Guardar(temperatura);
            if (resultado.Estado)
            {
                return Ok(ApiResponseDTO<Temperatura>.Success(resultado.Entidad, resultado.Mensaje));
            }
            return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }
    }
}