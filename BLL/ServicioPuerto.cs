using ENTITY;
using System;
using System.IO.Ports;

namespace BLL
{
    public class ServicioPuerto
    {
        private SerialPort _serialPort;
        public event Action<string> DatosRecibidos;
        public bool PuertoAbierto => _serialPort?.IsOpen ?? false;

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
                if (data.Contains(","))
                {
                    DatosRecibidos?.Invoke(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error leyendo datos: {ex.Message}");
            }
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
}
