using System;

namespace ENTITY
{
    public class Historial_Riego
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Humedad { get; set; }
        public float Temperatura { get; set; }
        public int IdPlanta { get; set; }

        // ✅ ESTA PROPIEDAD FALTABA:
        public string TipoRiego { get; set; } = "Manual";

        // Propiedades extendidas (para los JOINs)
        public string NombrePlanta { get; set; } = "";
        public string NombrePropietario { get; set; } = "";
    }
}