using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class HistorialRiegoResponseDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Humedad { get; set; }
        public float Temperatura { get; set; }
    }
}