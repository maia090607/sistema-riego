namespace SmartDropUI.Models
{
    public class HistorialRiegoModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Humedad { get; set; }
        public float Temperatura { get; set; }
        public int IdPlanta { get; set; } // ✅ Nuevo
    }
}