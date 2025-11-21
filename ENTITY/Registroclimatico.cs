using System;

namespace Entity
{
    public class RegistroClimatico
    {
        public int IdRegistro { get; set; }
        public DateTime Fecha { get; set; }
        public float Humedad_Suelo { get; set; }
        public float Humedad_Ambiente { get; set; }
        public float Temperatura_Ambiente { get; set; }
        public float Viento { get; set; }
        public int IdPlanta { get; set; } // ✅ Nuevo Campo
    }
}