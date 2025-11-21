namespace SmartDropUI.Models
{
    public class PlantaModel
    {
        // Estos nombres deben coincidir EXACTAMENTE con los que usa Plantas.razor
        // y con los que devuelve tu API (JSON)

        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string RutaImagen { get; set; } = string.Empty;

        // Usamos float porque en la API son float
        public float NivelOptimoHumedad { get; set; }
        public float NivelOptimoTemperatura { get; set; }
        public float NivelOptimoLuz { get; set; }
    }
}