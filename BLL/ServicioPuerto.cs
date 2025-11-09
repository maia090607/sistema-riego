using System;
using System.IO.Ports;

namespace BLL
{
    public class ServicioPuerto
    {
        private SerialPort _serialPort;
        public event Action<string> DatosRecibidos;

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

                if (data.StartsWith("Humedad del suelo:"))
                {
                    string valorStr = data.Split(':')[1].Trim();
                    if (int.TryParse(valorStr, out int humedad))
                        DatosRecibidos?.Invoke($"Humedad:{humedad}");
                }
                else if (data.Contains("Bomba"))
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
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.WriteLine(comando);
        }

        public void CerrarPuerto()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                Console.WriteLine("Puerto cerrado.");
            }
        }
    }
}
