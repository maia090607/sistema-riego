namespace SmartDropUI.Models
{
    public class ClimaValleduparModel
    {
        public int Temperatura { get; set; }
        public int HumedadAire { get; set; }
        public string Pronostico { get; set; } = string.Empty;
        public string DireccionViento { get; set; } = string.Empty;
        public int VelocidadViento { get; set; }
    }
}