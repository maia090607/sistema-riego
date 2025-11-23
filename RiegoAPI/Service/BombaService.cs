using System;
using System.IO.Ports;

namespace BLL
{
    // Clase dedicada a hablar con el Arduino
    public class BombaService : IDisposable
    {
        private SerialPort _serialPort;
        private bool _isConnected = false;

        // Configura aquí tu puerto si no quieres leerlo de config, o pásalo al constructor
        // NOTA: Asegúrate que coincida con lo que dice tu Arduino IDE (ej. COM3, COM11)
        public BombaService(string nombrePuerto = "COM11", int baudios = 9600)
        {
            try
            {
                _serialPort = new SerialPort(nombrePuerto, baudios);
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                    _isConnected = true;
                    Console.WriteLine($"[HARDWARE] ✅ Conectado al Arduino en {nombrePuerto}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HARDWARE] ❌ Error conectando al puerto {nombrePuerto}: {ex.Message}");
                // No lanzamos excepción para no tumbar la API, pero la bomba no funcionará
            }
        }

        public void Encender()
        {
            if (_isConnected && _serialPort.IsOpen)
            {
                // Enviamos '1' porque es lo común. Si tu Arduino usa 'E', cambia el "1" por "E".
                _serialPort.Write("1");
                Console.WriteLine("[HARDWARE] 💧 Enviado orden: ENCENDER (1)");
            }
            else
            {
                Console.WriteLine("[HARDWARE] ⚠️ No se pudo encender. Puerto cerrado.");
            }
        }

        public void Apagar()
        {
            if (_isConnected && _serialPort.IsOpen)
            {
                _serialPort.Write("0");
                Console.WriteLine("[HARDWARE] 🛑 Enviado orden: APAGAR (0)");
            }
        }

        public void Dispose()
        {
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
        }
    }
}