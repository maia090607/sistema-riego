using BLL;
using ENTITY;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTOs.Response; // Asegúrate de tener tus DTOs aquí

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumedadController : ControllerBase
    {
        private readonly ServiciosHumedad _serviciosHumedad;

        public HumedadController(ServiciosHumedad serviciosHumedad)
        {
            _serviciosHumedad = serviciosHumedad;
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] float valorHumedad)
        {
            try
            {
                var entidad = new humedad
                {
                    ValorHumedad = valorHumedad,
                    FechaRegistro = DateTime.Now
                };

                var resultado = _serviciosHumedad.insertar(entidad);

                if (resultado.Estado)
                {
                    return Ok(new { success = true, message = resultado.Mensaje });
                }
                return BadRequest(new { success = false, message = resultado.Mensaje });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}