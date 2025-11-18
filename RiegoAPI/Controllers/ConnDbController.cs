using BLL;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

// Comentario: la cadena de conexion que ya tienes esta bien, solo prueba y ya
// Este controlador es para probar la conexion a la db, no subir a git, aparece en swagger como ConDb  y un 
// unico endpoint get, por si se va a probar fuera de swagger la ruta es: /api/ConnDb/conn
namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnDbController : ControllerBase
    {

        // endpoint para probar la conexion a la db si esta bien o mal
        // revisa los logs en la consola, si la conexion no es exitosa tanto en la consola como en la respuesta
        // se dice que fallo
        [HttpGet("conn")]
        public IActionResult ProbarConexion([FromServices] IConfiguration config)
        {
            string connString = config.GetConnectionString("OracleConnection");

            try
            {
                using var conn = new OracleConnection(connString);
                conn.Open();

                return Ok("conexion a exitosa a la db oracle");
            }
            catch (Exception ex)
            {
                return BadRequest("error en la conexion: " + ex.Message);
            }
        }

    }

}