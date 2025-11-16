namespace RiegoAPI.DTO.Response
{
    public class EstadisticasResponseDTO
    {
        public int TotalRiegos { get; set; }
        public double HumedadPromedio { get; set; }
        public double TemperaturaPromedio { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
    }
}
