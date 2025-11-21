namespace RiegoAPI.DTO.Request
{
    public class RegistroClimaticoRequestDTO
    {
        public float HumedadSuelo { get; set; }
        public float HumedadAmbiente { get; set; }
        public float TemperaturaAmbiente { get; set; }
        public float Viento { get; set; }
        public int IdPlanta { get; set; } // ✅ Nuevo Campo
    }
}