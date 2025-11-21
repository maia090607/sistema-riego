using System;

namespace ENTITY
{
    public class Temperatura
    {
        public int IdTemperatura { get; set; }
        public DateTime FechaHora { get; set; }
        public float TempAmbiente { get; set; }
        public float TempSuelo { get; set; }
        public string Observacion { get; set; }
    }
}