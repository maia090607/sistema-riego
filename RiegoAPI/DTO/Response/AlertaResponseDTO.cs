using System;
using System.Collections.Generic;

namespace RiegoAPI.DTOs.Response
{
    public class AlertaResponseDTO
    {
        public int IdAlerta { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoAlerta { get; set; }
        public string Descripcion { get; set; }
        public string NivelCritico { get; set; }
        public bool Estado { get; set; }
    }
}