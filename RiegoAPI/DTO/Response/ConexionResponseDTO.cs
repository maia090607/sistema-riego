namespace RiegoAPI.DTO.Response
{
    public class ConexionResponseDTO
    {
        public bool success { get; set; }
        public bool conectado { get; set; }
        public string puerto { get; set; } = "";
        public DateTime timestamp { get; set; }
    }
}
