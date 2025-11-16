namespace RiegoAPI.DTOs.Response
{
    public class EstadisticasHistorialResponseDTO
    {
        public int TotalRegistros { get; set; }
        public float HumedadPromedio { get; set; }
        public float HumedadMinima { get; set; }
        public float HumedadMaxima { get; set; }
        public float TemperaturaPromedio { get; set; }
        public float TemperaturaMinima { get; set; }
        public float TemperaturaMaxima { get; set; }
        public int PeriodoAnalizado { get; set; }
    }
}
