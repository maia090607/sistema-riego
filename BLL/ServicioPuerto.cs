using System;
using System.IO.Ports;

namespace BLL
{
    public class ServicioPuerto
    {
        private SerialPort _serialPort;

        // Evento para notificar cuando llegan datos
        public event Action<string> DatosRecibidos;

        public bool PuertoAbierto => _serialPort?.IsOpen ?? false;

        public ServicioPuerto(string puerto = "COM3", int baudios = 9600)
        {
            try
            {
                _serialPort = new SerialPort(puerto, baudios);
                _serialPort.DataReceived += SerialDataReceived;
                _serialPort.Open();
                Console.WriteLine($"Puerto {puerto} abierto correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir el puerto: {ex.Message}");
            }
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadLine().Trim();

                // 🔹 Si el dato viene como "57,1" (humedad,bomba)
                if (data.Contains(","))
                {
                    DatosRecibidos?.Invoke(data); // Ejemplo: "57,1"
                }

                else
                {
                    DatosRecibidos?.Invoke(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error leyendo datos: {ex.Message}");
            }
        }

        public void EnviarComando(string comando)
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                    _serialPort.WriteLine(comando);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando comando: {ex.Message}");
            }
        }

        public void CerrarPuerto()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    Console.WriteLine("Puerto cerrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cerrando el puerto: {ex.Message}");
            }
        }
    }
}