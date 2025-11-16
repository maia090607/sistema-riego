namespace SmartDropUI.Models
{
    public class PlantaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string IdPlanta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int HumedadOptima { get; set; }
        public int TemperaturaOptima { get; set; }
        public string LuzOptima { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}