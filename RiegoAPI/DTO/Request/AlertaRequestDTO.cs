using System.ComponentModel.DataAnnotations;
using System;

namespace RiegoAPI.DTO.Request
{
    public class AlertaRequestDTO
    {
        public int IdAlerta { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoAlerta { get; set; }
        public string Descripcion { get; set; }
        public string NivelCritico { get; set; }
        public bool Estado { get; set; }
    }

}
