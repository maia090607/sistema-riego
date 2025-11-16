namespace RiegoAPI.DTO.Response
{
    public class DatosArduinoJsonDTO
    {
        public int Temp { get; set; }
        public int HumAire { get; set; }
        public int HumSuelo { get; set; }
        public bool Bomba { get; set; }
        public bool Online { get; set; }
    }
}
