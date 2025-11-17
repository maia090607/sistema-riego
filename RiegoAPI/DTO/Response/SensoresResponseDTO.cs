namespace RiegoAPI.DTO.Response
{
    namespace SmartDropUI.DTO.Response
    {
        public class SensoresResponse
        {
            public bool success { get; set; }
            public DatosSensoresDTO? datos { get; set; }
            public DateTime timestamp { get; set; }
        }

        public class DatosSensoresDTO
        {
            public double Temperatura { get; set; }
            public double Humedad { get; set; }
            public double HumedadSuelo { get; set; }
            public DateTime FechaLectura { get; set; }
        }
    }

}
