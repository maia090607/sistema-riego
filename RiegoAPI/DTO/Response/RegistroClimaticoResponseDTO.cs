using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class RegistroClimaticoResponseDTO
    {
        public int IdRegistro { get; set; }
        public DateTime Fecha { get; set; }
        public float HumedadSuelo { get; set; }
        public float HumedadAmbiente { get; set; }
        public float TemperaturaAmbiente { get; set; }
        public float Viento { get; set; }
    }
}
