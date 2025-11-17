namespace SmartDropUI.Models
{
    public class PlantaModel
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double TemperaturaOptima { get; set; }
        public double HumedadOptima { get; set; }
        public string LuzOptima { get; set; } = string.Empty;
        public string FrecuenciaRiego { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}