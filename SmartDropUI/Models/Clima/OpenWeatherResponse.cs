namespace SmartDropUI.Models.Clima
{
    // Modelo principal que coincide con la estructura de la API
    public class OpenWeatherResponse
    {
        // Contiene temperatura y humedad
        public Main main { get; set; } = new Main();

        // Es un array, contiene la descripción del clima
        public List<Weather> weather { get; set; } = new List<Weather>();

        // Contiene la velocidad del viento
        public Wind wind { get; set; } = new Wind();

        // Tiempo de actualización en formato Unix (Epoch time)
        public long dt { get; set; }
    }

    // Estructura para los datos principales (Main)
    public class Main
    {
        // Temperatura actual (°C, gracias al parámetro &units=metric)
        public double temp { get; set; }

        // Humedad relativa (%)
        public int humidity { get; set; }
    }

    // Estructura para la descripción del clima (Weather)
    public class Weather
    {
        // Descripción (ej: "cielo claro", "lluvia ligera")
        public string description { get; set; } = string.Empty;
    }

    // Estructura para el viento (Wind)
    public class Wind
    {
        // Velocidad del viento (m/s)
        public double speed { get; set; }
    }
}