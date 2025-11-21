namespace RiegoAPI.DTO.Request
{
    public class HistorialRiegoRequestDTO
    {
        public DateTime Fecha { get; set; }
        public float Humedad { get; set; }
        public float Temperatura { get; set; }
        public int IdPlanta { get; set; } // ✅ Nuevo
    }
}