namespace SmartDropUI.Models
{
    public class DatosRiegoModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Temperatura { get; set; } = 90.8;
        public string HumedadAire { get; set; } = "H";
        public double Humedad { get; set; } = 75.0;
        public bool BombaActiva { get; set; } = true;
        public string UltimoRiego { get; set; } = "Hoy 08:30";
        public string Pronostico { get; set; } = "Despejado";
        public string Viento { get; set; } = "Norte";
        public string HumedadSuelo { get; set; } = "Humedad";
        public string Estado { get; set; } = "Activo";
    }
}