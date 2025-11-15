namespace RiegoAPI.DTO.Request
{
    public class ComandoRiegoRequestDTO
    {
        public string Comando { get; set; } // "BOMBA_ON", "BOMBA_OFF", "AUTO"
        public int DuracionSegundos { get; set; }
    }
}
