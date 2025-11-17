namespace SmartDropUI.Models
{
    public class DatosClimaModel
    {
        /// <summary>
        /// Temperatura actual en grados Celsius (°C).
        /// </summary>
        public double Temperatura { get; set; }

        /// <summary>
        /// Humedad relativa del aire en porcentaje (%).
        /// </summary>
        public int Humedad { get; set; }

        /// <summary>
        /// Probabilidad de precipitación (lluvia) en porcentaje (0.0 a 1.0, o 0 a 100).
        /// Usaremos 0.0 a 1.0 para compatibilidad con APIs.
        /// </summary>
        public double ProbabilidadLluvia { get; set; }

        /// <summary>
        /// Descripción textual del clima (ej: "Cielo despejado", "Lluvia ligera").
        /// </summary>
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Velocidad del viento en metros por segundo (m/s).
        /// Relevante para la evaporación del agua.
        /// </summary>
        public double VelocidadViento { get; set; }

        /// <summary>
        /// Indica la hora y fecha de la última actualización de los datos.
        /// </summary>
        public DateTime FechaHoraActualizacion { get; set; }
    }
}