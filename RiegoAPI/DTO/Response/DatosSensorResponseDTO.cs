namespace RiegoAPI.DTO.Response
{
    public class DatosSensorResponseDTO
    {
        public int Temperatura { get; set; }
        public int HumedadAire { get; set; }
        public int HumedadSuelo { get; set; }
        public bool BombaActiva { get; set; }
        public bool ProgramaOnline { get; set; }
        public DateTime UltimoRiego { get; set; }
        public string Pronostico { get; set; } = "";
        public string DireccionViento { get; set; } = "";
        public int VelocidadViento { get; set; }

    }
}
