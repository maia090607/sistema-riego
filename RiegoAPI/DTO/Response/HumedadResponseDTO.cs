using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class HumedadResponseDTO
    {
        public int IdHumedad { get; set; }
        public float ValorHumedad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}