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
        private readonly HistorialRiegoService? _historialService;

        public event Action<DatosArduinoModel>? DatosRecibidos;

        public ArduinoService(string portName = "COM3", int baudRate = 9600, HistorialRiegoService? historialService = null)
        {
            _portName = portName;
            _baudRate = baudRate;
            _historialService = historialService;
        }

        public bool Conectar()
        {
            try
            {
                _serialPort = new SerialPort(_portName, _baudRate);
                _serialPort.DataReceived += OnDataReceived;
                _serialPort.Open();
                _isConnected = true;
                Console.WriteLine($"✅ [ARDUINO] Conectado al Arduino en {_portName}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [ARDUINO] Error al conectar: {ex.Message}");
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
                Console.WriteLine("🔌 [ARDUINO] Desconectado del Arduino");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [ARDUINO] Error al desconectar: {ex.Message}");
            }
        }

        public async Task<bool> IniciarRiegoManualAsync()
        {
            Console.WriteLine("📤 [ARDUINO] Enviando comando MANUAL_ON...");
            var resultado = await EnviarComandoAsync("MANUAL_ON");
            Console.WriteLine($"📥 [ARDUINO] Resultado MANUAL_ON: {resultado}");
            return resultado;
        }

        // ✅ GUARDAR EN BD AL DETENER RIEGO
        public async Task<bool> DetenerRiegoManualAsync()
        {
            Console.WriteLine("📤 [ARDUINO] Enviando comando MANUAL_OFF...");

            // ✅ Guardar datos antes de detener
            if (UltimosDatos != null && _historialService != null)
            {
                try
                {
                    var historial = new HistorialRiegoModel
                    {
                        Fecha = DateTime.Now,
                        Humedad = UltimosDatos.Humedad,
                        Temperatura = 0 // ✅ Obtener de sensor si está disponible
                    };

                    bool guardado = await _historialService.GuardarRiegoAsync(historial);
                    if (guardado)
                    {
                        Console.WriteLine("💾 [ARDUINO] Historial guardado en BD");
                    }
                    else
                    {
                        Console.WriteLine("⚠️ [ARDUINO] No se pudo guardar el historial");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ [ARDUINO] Error al guardar historial: {ex.Message}");
                }
            }

            var resultado = await EnviarComandoAsync("MANUAL_OFF");
            Console.WriteLine($"📥 [ARDUINO] Resultado MANUAL_OFF: {resultado}");
            return resultado;
        }

        public async Task<bool> ActivarModoAutomaticoAsync()
        {
            Console.WriteLine("📤 [ARDUINO] Enviando comando AUTO...");
            var resultado = await EnviarComandoAsync("AUTO");
            Console.WriteLine($"📥 [ARDUINO] Resultado AUTO: {resultado}");
            return resultado;
        }

        public async Task<bool> EstablecerLimiteHumedadAsync(int limite)
        {
            return await EnviarComandoAsync($"SET_LIMITE:{limite}");
        }

        public async Task<DatosArduinoModel?> ObtenerEstadoAsync()
        {
            if (!_isConnected || _serialPort?.IsOpen != true)
            {
                Console.WriteLine("⚠️ [ARDUINO] Arduino no conectado");
                return null;
            }

            try
            {
                await EnviarComandoAsync("GET_STATUS");
                await Task.Delay(200);

                if (UltimosDatos != null)
                {
                    Console.WriteLine($"📊 [ARDUINO] Estado obtenido - Humedad: {UltimosDatos.Humedad}, Bomba: {UltimosDatos.BombaEncendida}");
                }

                return UltimosDatos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [ARDUINO] Error al obtener estado: {ex.Message}");
                return null;
            }
        }

        private async Task<bool> EnviarComandoAsync(string comando)
        {
            if (!_isConnected || _serialPort?.IsOpen != true)
            {
                Console.WriteLine("⚠️ [ARDUINO] No se puede enviar comando");
                return false;
            }

            try
            {
                await Task.Run(() =>
                {
                    _serialPort.WriteLine(comando);
                    Console.WriteLine($"✅ [ARDUINO] Comando enviado: {comando}");
                });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [ARDUINO] Error al enviar comando '{comando}': {ex.Message}");
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
                Console.WriteLine($"❌ [ARDUINO] Error al recibir datos: {ex.Message}");
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

                        Console.WriteLine($"📊 [ARDUINO] Humedad: {datos.Humedad}%, Bomba: {(datos.BombaEncendida ? "ON" : "OFF")}");

                        DatosRecibidos?.Invoke(datos);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [ARDUINO] Error al procesar datos: {ex.Message}");
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