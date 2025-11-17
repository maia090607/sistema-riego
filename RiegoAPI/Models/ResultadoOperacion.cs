namespace RiegoAPI.Models
{
    public class ResultadoOperacion
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = "";
        public DateTime FechaHora { get; set; }
    }
}
