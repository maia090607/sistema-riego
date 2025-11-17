namespace RiegoAPI.Models
{
    public class ConexionArduino
    {
        public bool Conectado { get; set; }
        public string Puerto { get; set; } = "";
        public DateTime FechaVerificacion { get; set; }
    }
}
