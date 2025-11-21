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

        // Variables de estado
        private int _ultimaHumedad = 0;
        private bool _ultimaBombaActiva = false;
        private bool _ultimoModoManual = false; // ✅ Vital para el botón
        private DateTime _ultimaLectura = DateTime.MinValue;

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
                Console.WriteLine($"❌ Error al abrir puerto: {ex.Message}");
            }
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Leemos lo que manda el Arduino (Ej: "45,1,1")
                string data = _serialPort.ReadLine().Trim();

                // Validamos formato: Humedad, Bomba, Manual
                if (data.Contains(","))
                {
                    var partes = data.Split(',');
                    if (partes.Length == 3 &&
                        int.TryParse(partes[0], out int humedad) &&
                        int.TryParse(partes[1], out int estadoBomba) &&
                        int.TryParse(partes[2], out int modoManual))
                    {
                        _ultimaHumedad = humedad;
                        _ultimaBombaActiva = (estadoBomba == 1);
                        _ultimoModoManual = (modoManual == 1); // ✅ 1 = Manual Activado
                        _ultimaLectura = DateTime.Now;

                        // Notificar a quien esté escuchando (opcional)
                        DatosRecibidos?.Invoke(data);
                    }
                }
            }
            catch { /* Ignorar errores de lectura parcial */ }
        }

        // Método para que el Controller pida los datos limpios
        public (int Humedad, bool BombaActiva, bool ModoManual, DateTime FechaLectura) ObtenerUltimoEstado()
        {
            return (_ultimaHumedad, _ultimaBombaActiva, _ultimoModoManual, _ultimaLectura);
        }

        public void EnviarComando(string comando)
        {
            if (PuertoAbierto) _serialPort.WriteLine(comando);
        }

        public bool EnviarComandoConConfirmacion(string comando, int timeoutMs = 2000)
        {
            try
            {
                if (!PuertoAbierto) return false;

                // Limpiar buffer antes de enviar
                _serialPort.DiscardInBuffer();
                _serialPort.WriteLine(comando);

                var limite = DateTime.Now.AddMilliseconds(timeoutMs);
                while (DateTime.Now < limite)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        string resp = _serialPort.ReadLine().Trim();
                        // El Arduino responde "OK:COMANDO"
                        if (resp.Contains("OK") && resp.Contains(comando)) return true;
                    }
                    Thread.Sleep(10);
                }
            }
            catch { }
            return false;
        }

        public void CerrarPuerto()
        {
            if (PuertoAbierto) _serialPort.Close();
        }
    }
}