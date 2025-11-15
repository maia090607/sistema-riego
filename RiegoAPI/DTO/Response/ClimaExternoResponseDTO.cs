using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class ClimaExternoResponseDTO
    {
        public float Temperatura { get; set; }
        public float Humedad { get; set; }
        public float Viento { get; set; }
        public string Descripcion { get; set; }
    }
}
