namespace SmartDropUI.Models
{
    
    public class DatosSensorModel
    {
        // Datos de sensores locales
        public int Temperatura { get; set; }
        public int HumedadAire { get; set; }
        public int HumedadSuelo { get; set; }
        public bool BombaActiva { get; set; }
        public bool ProgramaOnline { get; set; }
        public DateTime UltimoRiego { get; set; } = DateTime.Now;

        // Datos del clima externo
        public string Pronostico { get; set; } = "Despejado";
        public string DireccionViento { get; set; } = "Norte";
        public int VelocidadViento { get; set; }
    }
}
