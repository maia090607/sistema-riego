using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class EstadoSistemaResponseDTO
    {
        public float HumedadActual { get; set; }
        public float TemperaturaActual { get; set; }
        public bool BombaEncendida { get; set; }
        public DateTime UltimoRiego { get; set; }
        public string EstadoConexion { get; set; }
    }
}
