namespace RiegoAPI.DTOs.Response
{
    public class PlantaResponseDTO
    {
        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public float NivelOptimoHumedad { get; set; }
        public float NivelOptimoTemperatura { get; set; }
        public float NivelOptimoLuz { get; set; }
        public int IdUsuario { get; set; } 
    }
}