namespace RiegoAPI.DTO.Response
{
    namespace SmartDropUI.DTO.Response
    {
        public class SensoresResponse
        {
            public bool success { get; set; }
            public DatosResponseDTO? datos { get; set; }
            public DateTime timestamp { get; set; }
        }
    }

}
