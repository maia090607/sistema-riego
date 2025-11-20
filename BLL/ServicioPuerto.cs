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

        // Últimos datos recibidos
        private int _ultimaHumedad = 0;
        private bool _ultimaBombaActiva = false;
        private DateTime _ultimaLectura = DateTime.MinValue;

        // ✅ Necesaria para detectar transiciones de OFF → ON y ON → OFF
        private bool bombaAnteriorEncendida = false;

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
                Console.WriteLine($"📡 [PUERTO] Datos crudos recibidos: '{data}'");

                if (data.Contains(","))
                {
                    var partes = data.Split(',');

                    if (partes.Length == 2 &&
                        int.TryParse(partes[0], out int humedad) &&
                        int.TryParse(partes[1], out int estadoBomba))
                    {
                        _ultimaHumedad = humedad;
                        _ultimaBombaActiva = estadoBomba == 1;
                        _ultimaLectura = DateTime.Now;

                        Console.WriteLine($"✅ [PUERTO] H:{humedad}% B:{(_ultimaBombaActiva ? "ON" : "OFF")}");

                        // 🔥 Notificar SIEMPRE si la bomba está activa
                        if (_ultimaBombaActiva)
                        {
                            DatosRecibidos?.Invoke(data);
                        }
                        // 🔥 Notificar cuando pase de ON → OFF (cambio importante)
                        else if (bombaAnteriorEncendida && !_ultimaBombaActiva)
                        {
                            DatosRecibidos?.Invoke(data);
                        }

                        // Actualizar estado anterior
                        bombaAnteriorEncendida = _ultimaBombaActiva;
                    }
                    else
                    {
                        Console.WriteLine($"⚠️ [PUERTO] No se pudo parsear: '{data}'");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [PUERTO] Error: {ex.Message}");
            }
        }

        public (int Humedad, bool BombaActiva, DateTime FechaLectura) ObtenerUltimoEstado()
        {
            return (_ultimaHumedad, _ultimaBombaActiva, _ultimaLectura);
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
