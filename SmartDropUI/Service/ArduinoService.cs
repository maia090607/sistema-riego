using System.IO.Ports;
using SmartDropUI.Models;

namespace SmartDropUI.Services
{
    public class ArduinoService : IDisposable
    {
        private SerialPort? _serialPort;
        private readonly string _portName;
        private readonly int _baudRate;
        private bool _isConnected = false;

        // Evento para notificar cambios en los datos
        public event Action<DatosArduinoModel>? DatosRecibidos;

        public ArduinoService(string portName = "COM3", int baudRate = 9600)
        {
            _portName = portName;
            _baudRate = baudRate;
        }

        public bool Conectar()
        {
            try
            {
                _serialPort = new SerialPort(_portName, _baudRate);
                _serialPort.DataReceived += OnDataReceived;
                _serialPort.Open();
                _isConnected = true;
                Console.WriteLine($"✅ Conectado al Arduino en {_portName}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al conectar con Arduino: {ex.Message}");
                _isConnected = false;
                return false;
            }
        }

        public void Desconectar()
        {
            try
            {
                if (_serialPort?.IsOpen == true)
                {
                    _serialPort.Close();
                }
                _isConnected = false;
                Console.WriteLine("🔌 Desconectado del Arduino");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al desconectar: {ex.Message}");
            }
        }

        public async Task<bool> IniciarRiegoManualAsync()
        {
            return await EnviarComandoAsync("MANUAL_ON");
        }

        public async Task<bool> DetenerRiegoManualAsync()
        {
            return await EnviarComandoAsync("MANUAL_OFF");
        }

        public async Task<bool> ActivarModoAutomaticoAsync()
        {
            return await EnviarComandoAsync("AUTO");
        }

        public async Task<bool> EstablecerLimiteHumedadAsync(int limite)
        {
            return await EnviarComandoAsync($"SET_LIMITE:{limite}");
        }

        public async Task<DatosArduinoModel?> ObtenerEstadoAsync()
        {
            if (!_isConnected || _serialPort?.IsOpen != true)
            {
                Console.WriteLine("⚠️ Arduino no conectado");
                return null;
            }

            try
            {
                await EnviarComandoAsync("GET_STATUS");
                await Task.Delay(200); // Esperar respuesta
                return UltimosDatos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener estado: {ex.Message}");
                return null;
            }
        }

        private async Task<bool> EnviarComandoAsync(string comando)
        {
            if (!_isConnected || _serialPort?.IsOpen != true)
            {
                Console.WriteLine("⚠️ No se puede enviar comando, Arduino no conectado");
                return false;
            }

            try
            {
                await Task.Run(() =>
                {
                    _serialPort.WriteLine(comando);
                    Console.WriteLine($"📤 Comando enviado: {comando}");
                });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al enviar comando: {ex.Message}");
                return false;
            }
        }

        private DatosArduinoModel? UltimosDatos { get; set; }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_serialPort?.IsOpen == true)
                {
                    string data = _serialPort.ReadLine();
                    ProcesarDatos(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al recibir datos: {ex.Message}");
            }
        }

        private void ProcesarDatos(string data)
        {
            try
            {
                // Formato esperado: DATOS:humedad,bombaEstado,modo
                if (data.StartsWith("DATOS:"))
                {
                    var partes = data.Substring(6).Split(',');
                    if (partes.Length == 3)
                    {
                        var datos = new DatosArduinoModel
                        {
                            Humedad = int.Parse(partes[0]),
                            BombaEncendida = partes[1] == "ON",
                            ModoManual = partes[2] == "MANUAL",
                            FechaHora = DateTime.Now
                        };

                        UltimosDatos = datos;
                        DatosRecibidos?.Invoke(datos);

                        Console.WriteLine($"📊 Humedad: {datos.Humedad}, Bomba: {(datos.BombaEncendida ? "ON" : "OFF")}, Modo: {(datos.ModoManual ? "Manual" : "Automático")}");
                    }
                }
                else if (data.StartsWith("OK:"))
                {
                    Console.WriteLine($"✅ {data}");
                }
                else
                {
                    Console.WriteLine($"📨 Arduino: {data}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al procesar datos: {ex.Message}");
            }
        }

        public bool EstaConectado => _isConnected && _serialPort?.IsOpen == true;

        public void Dispose()
        {
            Desconectar();
            _serialPort?.Dispose();
        }
    }
}