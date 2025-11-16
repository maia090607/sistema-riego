using Microsoft.AspNetCore.Mvc;
using RiegoAPI.DTO.Response;
using System.IO.Ports;
using System.Text.Json;

namespace RiegoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensoresController : ControllerBase
    {
        private static SerialPort? _serialPort;
        private static readonly object _lock = new object();

        // Configuración del puerto serial (ajusta según tu sistema)
        private const string PUERTO_COM = "COM11"; // Cambia esto según tu puerto (COM3, COM4, etc.)
        private const int BAUD_RATE = 9600;

        public SensoresController()
        {
            InicializarPuertoSerial();
        }

        private void InicializarPuertoSerial()
        {
            lock (_lock)
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    try
                    {
                        _serialPort = new SerialPort(PUERTO_COM, BAUD_RATE);
                        _serialPort.ReadTimeout = 1000;
                        _serialPort.WriteTimeout = 1000;
                        _serialPort.Open();
                        Console.WriteLine($"Puerto serial {PUERTO_COM} abierto correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al abrir puerto serial: {ex.Message}");
                    }
                }
            }
        }

        [HttpGet("actuales")]
        public ActionResult<DatosSensorResponseDTO> ObtenerDatosActuales()
        {
            try
            {
                // Leer datos del Arduino
                var datosArduino = LeerDatosArduino();

                if (datosArduino != null)
                {
                    return Ok(datosArduino);
                }

                return StatusCode(500, "No se pudieron leer los datos del Arduino");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("riego/manual")]
        public ActionResult ActivarRiegoManual()
        {
            try
            {
                EnviarComandoArduino("RIEGO_ON");
                return Ok(new { mensaje = "Riego activado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("puertos")]
        public ActionResult<string[]> ObtenerPuertosDisponibles()
        {
            var puertos = SerialPort.GetPortNames();
            return Ok(puertos);
        }

        private DatosSensorResponseDTO? LeerDatosArduino()
        {
            lock (_lock)
            {
                try
                {
                    if (_serialPort != null && _serialPort.IsOpen)
                    {
                        // Solicitar datos al Arduino
                        _serialPort.WriteLine("GET_DATA");

                        // Esperar respuesta
                        System.Threading.Thread.Sleep(100);

                        if (_serialPort.BytesToRead > 0)
                        {
                            string jsonData = _serialPort.ReadLine();
                            Console.WriteLine($"Datos recibidos del Arduino: {jsonData}");

                            // El Arduino debe enviar JSON en este formato:
                            // {"temp":25,"humAire":60,"humSuelo":45,"bomba":true,"online":true}
                            var datos = JsonSerializer.Deserialize<DatosArduinoJsonDTO>(jsonData);

                            if (datos != null)
                            {
                                return new DatosSensorResponseDTO
                                {
                                    Temperatura = datos.Temp,
                                    HumedadAire = datos.HumAire,
                                    HumedadSuelo = datos.HumSuelo,
                                    BombaActiva = datos.Bomba,
                                    ProgramaOnline = datos.Online,
                                    UltimoRiego = DateTime.Now,
                                    Pronostico = "Despejado",
                                    DireccionViento = "Norte",
                                    VelocidadViento = 10
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error leyendo Arduino: {ex.Message}");
                }

                return null;
            }
        }

        private void EnviarComandoArduino(string comando)
        {
            lock (_lock)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.WriteLine(comando);
                    Console.WriteLine($"Comando enviado: {comando}");
                }
            }
        }
    }

   
}
