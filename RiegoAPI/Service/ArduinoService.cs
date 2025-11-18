using RiegoAPI.Controllers;
using RiegoAPI.Models;
using System.IO.Ports;
using System.Text;

namespace RiegoAPI.Services
{
    public class ArduinoService : IArduinoService, IDisposable
    {
        private SerialPort? _serialPort;
        private readonly ILogger<ArduinoService> _logger;
        private readonly IConfiguration _configuration;
        private bool _bombaEncendida = false;

        public ArduinoService(ILogger<ArduinoService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            InicializarPuertoSerial();
        }

        private void InicializarPuertoSerial()
        {
            try
            {
                // Obtener el puerto del Arduino desde la configuración
                var puerto = _configuration["Arduino:Puerto"] ?? "COM3";
                var baudRate = int.Parse(_configuration["Arduino:BaudRate"] ?? "9600");

                _serialPort = new SerialPort(puerto, baudRate)
                {
                    DtrEnable = true,
                    RtsEnable = true,
                    ReadTimeout = 3000,
                    WriteTimeout = 3000
                };

                _serialPort.Open();
                Thread.Sleep(2000); // Esperar a que el Arduino se inicialice

                _logger.LogInformation($"Conectado al Arduino en {puerto} a {baudRate} baudios");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al inicializar puerto serial");
            }
        }

        public async Task<bool> EncenderBombaAsync()
        {
            try
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    _logger.LogWarning("Puerto serial no está abierto");
                    return false;
                }

                // Enviar comando al Arduino para encender la bomba
                _serialPort.WriteLine("BOMBA:ON");
                await Task.Delay(100);

                // Leer respuesta del Arduino
                var respuesta = _serialPort.ReadLine().Trim();

                if (respuesta == "OK:BOMBA:ON")
                {
                    _bombaEncendida = true;
                    _logger.LogInformation("Bomba encendida correctamente");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al encender bomba");
                return false;
            }
        }

        public async Task<bool> ApagarBombaAsync()
        {
            try
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    _logger.LogWarning("Puerto serial no está abierto");
                    return false;
                }

                // Enviar comando al Arduino para apagar la bomba
                _serialPort.WriteLine("BOMBA:OFF");
                await Task.Delay(100);

                // Leer respuesta del Arduino
                var respuesta = _serialPort.ReadLine().Trim();

                if (respuesta == "OK:BOMBA:OFF")
                {
                    _bombaEncendida = false;
                    _logger.LogInformation("Bomba apagada correctamente");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al apagar bomba");
                return false;
            }
        }

        public async Task<bool> ObtenerEstadoBombaAsync()
        {
            try
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    return _bombaEncendida;
                }

                // Solicitar estado al Arduino
                _serialPort.WriteLine("ESTADO:BOMBA");
                await Task.Delay(100);

                var respuesta = _serialPort.ReadLine().Trim();

                if (respuesta == "BOMBA:ON")
                {
                    _bombaEncendida = true;
                }
                else if (respuesta == "BOMBA:OFF")
                {
                    _bombaEncendida = false;
                }

                return _bombaEncendida;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estado de bomba");
                return _bombaEncendida;
            }
        }

        public async Task<DatosSensoresModel> ObtenerDatosSensoresAsync()
        {
            try
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    throw new InvalidOperationException("Puerto serial no está abierto");
                }

                // Solicitar datos al Arduino
                _serialPort.WriteLine("LEER:SENSORES");
                await Task.Delay(500);

                var respuesta = _serialPort.ReadLine().Trim();

                // Formato esperado: "SENSORES:TEMP:25.5,HUM:60,SUELO:45"
                var datos = ParsearDatosSensores(respuesta);
                return datos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener datos de sensores");
                return new DatosSensoresModel
                {
                    FechaLectura = DateTime.Now
                };
            }
        }

        private DatosSensoresModel ParsearDatosSensores(string respuesta)
        {
            var datos = new DatosSensoresModel { FechaLectura = DateTime.Now };

            try
            {
                // Parsear respuesta del formato: "SENSORES:TEMP:25.5,HUM:60,SUELO:45"
                var partes = respuesta.Replace("SENSORES:", "").Split(',');

                foreach (var parte in partes)
                {
                    var keyValue = parte.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0].ToUpper())
                        {
                            case "TEMP":
                                datos.Temperatura = double.Parse(keyValue[1]);
                                break;
                            case "HUM":
                                datos.Humedad = double.Parse(keyValue[1]);
                                break;
                            case "SUELO":
                                datos.HumedadSuelo = double.Parse(keyValue[1]);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al parsear datos de sensores");
            }

            return datos;
        }

        public bool EstaConectado()
        {
            return _serialPort != null && _serialPort.IsOpen;
        }

        public string ObtenerPuerto()
        {
            return _serialPort?.PortName ?? "No conectado";
        }

        public void Dispose()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }
    }
}