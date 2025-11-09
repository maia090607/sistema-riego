using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

