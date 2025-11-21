namespace SmartDropUI.Models
{
    public class PlantaModel
    {
        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string RutaImagen { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public float NivelOptimoHumedad { get; set; }
        public float NivelOptimoTemperatura { get; set; }
        public float NivelOptimoLuz { get; set; }
    }
}