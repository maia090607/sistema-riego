using ENTITY;
using System;
using System.IO.Ports;
using System.Threading;

namespace BLL
{
    public class ServicioPuerto
    {
        private SerialPort _serialPort;
        public event Action<string> DatosRecibidos;
        public bool PuertoAbierto => _serialPort?.IsOpen ?? false;

        // Últimos datos recibidos
        private int _ultimaHumedad = 0;
        private bool _ultimaBombaActiva = false;
        private bool _ultimoModoManual = false;
        private DateTime _ultimaLectura = DateTime.MinValue;

        // ✅ NUEVO: Variables para detectar cambios de estado
        private bool _bombaAnteriorEncendida = false;

        // ✅ NUEVO: Evento para notificar cambios de estado de riego
        public event Action<RiegoAutomaticoEventArgs> RiegoAutomaticoDetectado;

        public ServicioPuerto(string puerto = "COM3", int baudios = 9600)
        {
            try
            {
                _serialPort = new SerialPort(puerto, baudios);
                _serialPort.DataReceived += SerialDataReceived;
                _serialPort.Open();
                Console.WriteLine($"✅ Puerto {puerto} abierto correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al abrir el puerto: {ex.Message}");
            }
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadLine().Trim();
                Console.WriteLine($"📡 [PUERTO] Datos recibidos: '{data}'");

                if (data.Contains(","))
                {
                    var partes = data.Split(',');

                    // Formato: humedad,bomba,modoManual
                    if (partes.Length == 3 &&
                        int.TryParse(partes[0], out int humedad) &&
                        int.TryParse(partes[1], out int estadoBomba) &&
                        int.TryParse(partes[2], out int modoManual))
                    {
                        _ultimaHumedad = humedad;
                        _ultimaBombaActiva = estadoBomba == 1;
                        _ultimoModoManual = modoManual == 1;
                        _ultimaLectura = DateTime.Now;

                        Console.WriteLine($"✅ [PUERTO] H:{humedad}% B:{(_ultimaBombaActiva ? "ON" : "OFF")} M:{(_ultimoModoManual ? "MANUAL" : "AUTO")}");

                        // ✅ DETECTAR RIEGO AUTOMÁTICO
                        // Si la bomba se encendió Y NO estamos en modo manual = RIEGO AUTOMÁTICO
                        if (_ultimaBombaActiva && !_bombaAnteriorEncendida && !_ultimoModoManual)
                        {
                            Console.WriteLine("🌊 [PUERTO] ¡RIEGO AUTOMÁTICO DETECTADO!");

                            // Disparar evento para que el controller lo capture
                            RiegoAutomaticoDetectado?.Invoke(new RiegoAutomaticoEventArgs
                            {
                                Humedad = humedad,
                                FechaHora = DateTime.Now
                            });
                        }

                        DatosRecibidos?.Invoke(data);
                        _bombaAnteriorEncendida = _ultimaBombaActiva;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [PUERTO] Error: {ex.Message}");
            }
        }

        // ✅ CORREGIDO: Ahora devuelve 4 valores (agregado ModoManual)
        public (int Humedad, bool BombaActiva, bool ModoManual, DateTime FechaLectura) ObtenerUltimoEstado()
        {
            return (_ultimaHumedad, _ultimaBombaActiva, _ultimoModoManual, _ultimaLectura);
        }

        public void EnviarComando(string comando)
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.WriteLine(comando);
                    Console.WriteLine($"📤 [PUERTO] Comando enviado: {comando}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [PUERTO] Error: {ex.Message}");
            }
        }

        public bool EnviarComandoConConfirmacion(string comando, int timeoutMs = 2000)
        {
            try
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    Console.WriteLine("❌ [PUERTO] Puerto no disponible");
                    return false;
                }

                Console.WriteLine($"📤 [PUERTO] Enviando: {comando}");
                _serialPort.WriteLine(comando);

                var tiempoInicio = DateTime.Now;

                while ((DateTime.Now - tiempoInicio).TotalMilliseconds < timeoutMs)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        string respuesta = _serialPort.ReadLine().Trim();
                        Console.WriteLine($"📥 [PUERTO] Respuesta: {respuesta}");

                        if (respuesta.Equals($"OK:{comando}", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("✅ [PUERTO] Confirmación recibida");
                            return true;
                        }
                    }

                    Thread.Sleep(50);
                }

                Console.WriteLine("⏱️ [PUERTO] Timeout esperando confirmación");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [PUERTO] Error: {ex.Message}");
                return false;
            }
        }

        public void CerrarPuerto()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    Console.WriteLine("🔌 Puerto cerrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error cerrando el puerto: {ex.Message}");
            }
        }
    }

    // ✅ NUEVO: Clase para el evento de riego automático
    public class RiegoAutomaticoEventArgs : EventArgs
    {
        public int Humedad { get; set; }
        public DateTime FechaHora { get; set; }
    }
}