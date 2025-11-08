using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Alertas
    {
        public Alertas() { }
        public int IdAlerta { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoAlerta { get; set; }
        public string Descripcion { get; set; }
        public string NivelCritico { get; set; }
        public bool Estado { get; set; }
    }
}
