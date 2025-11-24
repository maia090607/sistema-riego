using BLL;
using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTO.Mappers;
using RiegoAPI.DTO.Request;
using RiegoAPI.DTOs.Response;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private readonly ServiciosAlertas _serviciosAlertas;

        public AlertasController(ServiciosAlertas serviciosAlertas)
        {
            _serviciosAlertas = serviciosAlertas;
        }

        [HttpGet]
        public IActionResult ObtenerTodas()
        {
            var resultado = _serviciosAlertas.MostrarTodos();
            var alertasDto = AlertaMapper.ToResponseDTOList(resultado.Lista);

            return Ok(ApiResponseDTO<List<AlertaResponseDTO>>.Success(
                alertasDto,
                $"Se encontraron {alertasDto.Count} alertas"
            ));
        }


        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponseDTO<object>.Error("El ID debe ser mayor a cero"));

            var resultado = _serviciosAlertas.ObtenerPorId(id);

            if (resultado.Estado && resultado.Entidad != null)
            {
                var alertaDto = AlertaMapper.ToResponseDTO(resultado.Entidad);
                return Ok(ApiResponseDTO<AlertaResponseDTO>.Success(
                    alertaDto,
                    "Alerta encontrada"
                ));
            }

            return NotFound(ApiResponseDTO<object>.Error($"No se encontró alerta con ID {id}"));
        }

        [HttpGet("activas")]
        public IActionResult ObtenerActivas()
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var activas = todas.Lista?.Where(a => !a.Estado).ToList() ?? new List<ENTITY.Alertas>();
            var activasDto = AlertaMapper.ToResponseDTOList(activas);

            return Ok(ApiResponseDTO<List<AlertaResponseDTO>>.Success(
                activasDto,
                $"Se encontraron {activasDto.Count} alertas activas"
            ));
        }

        [HttpGet("por-nivel/{nivel}")]
        public IActionResult ObtenerPorNivel(string nivel)
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var filtradas = todas.Lista?
                .Where(a => a.NivelCritico.Equals(nivel, StringComparison.OrdinalIgnoreCase))
                .ToList() ?? new List<ENTITY.Alertas>();

            var filtradasDto = AlertaMapper.ToResponseDTOList(filtradas);

            return Ok(ApiResponseDTO<List<AlertaResponseDTO>>.Success(
                filtradasDto,
                $"Se encontraron {filtradasDto.Count} alertas de nivel {nivel}"
            ));
        }

        [HttpGet("por-tipo/{tipo}")]
        public IActionResult ObtenerPorTipo(string tipo)
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var filtradas = todas.Lista?
                .Where(a => a.TipoAlerta.Contains(tipo, StringComparison.OrdinalIgnoreCase))
                .ToList() ?? new List<ENTITY.Alertas>();

            var filtradasDto = AlertaMapper.ToResponseDTOList(filtradas);

            return Ok(ApiResponseDTO<List<AlertaResponseDTO>>.Success(
                filtradasDto,
                $"Se encontraron {filtradasDto.Count} alertas del tipo {tipo}"
            ));
        }

        [HttpGet("por-fecha")]
        public IActionResult ObtenerPorFecha([FromQuery] DateTime fecha)
        {
            var todas = _serviciosAlertas.MostrarTodos();
            var filtradas = todas.Lista?
                .Where(a => a.FechaHora.Date == fecha.Date)
                .ToList() ?? new List<ENTITY.Alertas>();

            var filtradasDto = AlertaMapper.ToResponseDTOList(filtradas);

            return Ok(ApiResponseDTO<List<AlertaResponseDTO>>.Success(
                filtradasDto,
                $"Se encontraron {filtradasDto.Count} alertas para la fecha {fecha:dd/MM/yyyy}"
            ));
        }

        [HttpPost]
        public IActionResult Agregar([FromBody] AlertaRequestDTO alertaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponseDTO<object>.Error("Datos inválidos"));

            var todas = _serviciosAlertas.MostrarTodos();
            int nuevoId = (todas.Lista?.Any() ?? false) ? todas.Lista.Max(a => a.IdAlerta) + 1 : 1;

            alertaDto.IdAlerta = nuevoId;
            alertaDto.FechaHora = DateTime.Now;

            var alerta = AlertaMapper.ToEntity(alertaDto);
            var resultado = _serviciosAlertas.Agregar(alerta);

            if (resultado.Estado)
            {
                var alertaResponse = AlertaMapper.ToResponseDTO(resultado.Entidad);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = alerta.IdAlerta },
                    ApiResponseDTO<AlertaResponseDTO>.Success(alertaResponse, resultado.Mensaje));
            }

            return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] AlertaRequestDTO alertaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponseDTO<object>.Error("Datos inválidos"));

            if (id != alertaDto.IdAlerta)
                return BadRequest(ApiResponseDTO<object>.Error("El ID no coincide"));

            var alertaExistente = _serviciosAlertas.ObtenerPorId(id);

            if (!alertaExistente.Estado || alertaExistente.Entidad == null)
                return NotFound(ApiResponseDTO<object>.Error("Alerta no encontrada"));

            AlertaMapper.UpdateEntity(alertaExistente.Entidad, alertaDto);
            var resultado = _serviciosAlertas.Actualizar(alertaExistente.Entidad);

            if (resultado.Estado)
            {
                var alertaResponse = AlertaMapper.ToResponseDTO(resultado.Entidad);
                return Ok(ApiResponseDTO<AlertaResponseDTO>.Success(
                    alertaResponse, resultado.Mensaje
                ));
            }

            return NotFound(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        [HttpPatch("{id}/estado")]
        public IActionResult CambiarEstado(int id, [FromBody] AlertaEstadoRequestDTO estadoDto)
        {
            var alertaExistente = _serviciosAlertas.ObtenerPorId(id);

            if (!alertaExistente.Estado || alertaExistente.Entidad == null)
                return NotFound(ApiResponseDTO<object>.Error("Alerta no encontrada"));

            alertaExistente.Entidad.Estado = estadoDto.Estado;
            var resultado = _serviciosAlertas.Actualizar(alertaExistente.Entidad);

            if (resultado.Estado)
            {
                var alertaResponse = AlertaMapper.ToResponseDTO(resultado.Entidad);
                return Ok(ApiResponseDTO<AlertaResponseDTO>.Success(
                    alertaResponse,
                    $"Alerta {(estadoDto.Estado ? "resuelta" : "activada")} correctamente"
                ));
            }

            return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        [HttpPatch("{id}/marcar-leida")]
        public IActionResult MarcarComoLeida(int id)
        {
            var alerta = _serviciosAlertas.ObtenerPorId(id);

            if (!alerta.Estado || alerta.Entidad == null)
                return NotFound(ApiResponseDTO<object>.Error($"No se encontró alerta con ID {id}"));

            alerta.Entidad.Estado = true;
            var resultado = _serviciosAlertas.Actualizar(alerta.Entidad);

            if (resultado.Estado)
            {
                var alertaDto = AlertaMapper.ToResponseDTO(resultado.Entidad);
                return Ok(ApiResponseDTO<AlertaResponseDTO>.Success(
                    alertaDto, "Alerta marcada como leída"
                ));
            }

            return BadRequest(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponseDTO<object>.Error("El ID debe ser mayor a cero"));

            var resultado = _serviciosAlertas.Eliminar(id);

            if (resultado.Estado)
                return Ok(ApiResponseDTO<object>.Success(null, resultado.Mensaje));

            return NotFound(ApiResponseDTO<object>.Error(resultado.Mensaje));
        }

        [HttpGet("resumen")]
        public IActionResult ObtenerResumen()
        {
            var todas = _serviciosAlertas.MostrarTodos().Lista ?? new List<ENTITY.Alertas>();

            var resumen = new
            {
                TotalAlertas = todas.Count,
                AlertasActivas = todas.Count(a => !a.Estado),
                AlertasLeidas = todas.Count(a => a.Estado),
                AlertasCriticasActivas = todas.Count(a => !a.Estado && a.NivelCritico == "Alto"),
                AlertasPorNivel = todas.GroupBy(a => a.NivelCritico)
                    .ToDictionary(g => g.Key, g => g.Count()),
                UltimaAlerta = todas.OrderByDescending(a => a.FechaHora).FirstOrDefault()
            };

            return Ok(ApiResponseDTO<object>.Success(resumen, "Resumen de alertas"));
        }

        ///TE VOY A AGREGAR AQUI UN  ENDPOINT DE EJEMPLO, PORQUE EL QUE TIENES ALLA NO FUNCIONA
        [HttpGet("ejm-riegos")]
        public IActionResult ObtenerDemoRiego()
        {
            var alarmas = new List<object>
{
    new {
        IdAlarma = 1,
        Tipo = "Humedad Baja",
        Cultivo = "Naranja",
        Nivel = "Alto",
        Estado = "Activa",
        Descripcion = "El nivel de humedad en el sector norte cayó por debajo del 25%",
        HumedadActual = 22.5,
        Umbral = 25.0,
        Sector = "Norte",
        Fecha = DateTime.Now.AddMinutes(-20).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new {
        IdAlarma = 2,
        Tipo = "Caudal Excesivo",
        Nivel = "Medio",
        Estado = "Activa",
        Descripcion = "El caudal del sistema supera el límite recomendado",
        CaudalActual = 180,
        Umbral = 150,
        Sector = "Centro",
        Fecha = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new {
        IdAlarma = 3,
        Tipo = "Sensor Desconectado",
        Cultivo = "Mango",
        Nivel = "Crítico",
        Estado = "Activa",
        Descripcion = "El sensor de humedad en el sector sur no está transmitiendo datos",
        SensorId = "HM-SUR-04",
        Sector = "Sur",
        Fecha = DateTime.Now.AddMinutes(-3).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new {
        IdAlarma = 4,
        Tipo = "Humedad Óptima",
        Cultivo = "Sabila",
        Nivel = "Bajo",
        Estado = "Resuelta",
        Descripcion = "Humedad estabilizada dentro del rango ideal (30% - 45%)",
        HumedadActual = 37.2,
        Sector = "Oeste",
        Fecha = DateTime.Now.AddHours(-3).ToString("yyyy-MM-dd HH:mm:ss")
    }
};

            return Ok(ApiResponseDTO<object>.Success(
                alarmas,
                "Alarmas activas registradas el día de hoy"
            ));
        }


    }
}