using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    // Clase para transportar los datos
    public class DatosArduinoModel
    {
        public int Humedad { get; set; }
        public bool BombaEncendida { get; set; }
        public bool ModoManual { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
    }

    public class ServicioPuerto
    {
        private SerialPort _serialPort;
        // Variable para guardar el último estado conocido
        private DatosArduinoModel _ultimoEstado = new DatosArduinoModel();

        // Evento para notificar a quien escuche (opcional si usas polling)
        public event Action<DatosArduinoModel> DatosRecibidos;

        public bool PuertoAbierto => _serialPort?.IsOpen ?? false;

        public ServicioPuerto(string puerto = "COM3", int baudios = 9600)
        {
            try
            {
                _serialPort = new SerialPort(puerto, baudios)
                {
                    ReadTimeout = 1000,
                    WriteTimeout = 1000,
                    DtrEnable = true,
                    RtsEnable = true
                };
                _serialPort.Open();

                // Hilo de lectura en segundo plano
                Thread readThread = new Thread(LeerPuertoSerial);
                readThread.IsBackground = true;
                readThread.Start();

                Console.WriteLine($"✅ Puerto {puerto} abierto correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al abrir el puerto: {ex.Message}");
            }
        }

        // Método para obtener el estado actual (usado por ArduinoController)
        public DatosArduinoModel ObtenerUltimoEstado()
        {
            return _ultimoEstado;
        }

        private void LeerPuertoSerial()
        {
            while (_serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    string data = _serialPort.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(data) && data.Contains(","))
                    {
                        // Procesar datos: humedad,bomba,manual (ej: "45,0,1")
                        var partes = data.Split(',');
                        if (partes.Length >= 2 &&
                            int.TryParse(partes[0], out int humedad) &&
                            int.TryParse(partes[1], out int bomba))
                        {
                            bool manual = partes.Length > 2 && partes[2] == "1";

                            // Actualizamos la variable local
                            _ultimoEstado = new DatosArduinoModel
                            {
                                Humedad = humedad,
                                BombaEncendida = bomba == 1,
                                ModoManual = manual,
                                FechaHora = DateTime.Now
                            };

                            // Notificamos eventos
                            DatosRecibidos?.Invoke(_ultimoEstado);
                        }
                    }
                }
                catch { }
            }
        }

        public void EnviarComando(string comando)
        {
            try
            {
                if (PuertoAbierto)
                {
                    // No limpiamos el Buffer de ENTRADA (DiscardInBuffer) aquí
                    // para no borrar datos que el hilo de lectura esté a punto de procesar.

                    _serialPort.WriteLine(comando);
                    Console.WriteLine($"📤 Comando enviado (Fire&Forget): {comando}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error enviando comando: {ex.Message}");
            }
        }

        public bool EnviarComandoConConfirmacion(string comando, int timeoutMs = 3000) // Aumentado a 3 seg
        {
            try
            {
                if (!PuertoAbierto) return false;

                // 1. Limpiar buffers
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();

                // 2. Enviar comando
                Console.WriteLine($"📤 Enviando: {comando}");
                _serialPort.WriteLine(comando);

                // 3. Esperar respuesta
                var inicio = DateTime.Now;
                while ((DateTime.Now - inicio).TotalMilliseconds < timeoutMs)
                {
                    try
                    {
                        if (_serialPort.BytesToRead > 0)
                        {
                            string respuesta = _serialPort.ReadExisting(); // Leemos TODO lo que haya
                            Console.WriteLine($"📥 Recibido RAW: {respuesta}");

                            // Buscamos "OK" en cualquier parte del texto recibido
                            if (respuesta.IndexOf("OK", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                return true; // ¡ÉXITO!
                            }
                        }
                    }
                    catch { }
                    Thread.Sleep(50); // Pequeña pausa
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error enviando comando: {ex.Message}");
                return false;
            }
        }

        // Métodos asíncronos de ayuda
        public async Task<bool> IniciarRiegoManualAsync() => await Task.Run(() => EnviarComandoConConfirmacion("MANUAL_ON"));
        public async Task<bool> DetenerRiegoManualAsync() => await Task.Run(() => EnviarComandoConConfirmacion("MANUAL_OFF"));
        public async Task<bool> ActivarModoAutomaticoAsync() => await Task.Run(() => EnviarComandoConConfirmacion("AUTO"));

        public void CerrarPuerto()
        {
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
        }
    }
}