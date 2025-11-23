namespace ENTITY
{
    public class Cultivo
    {
        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string RutaImagen { get; set; } = string.Empty;
        public float nivel_optimo_humedad { get; set; }
        public float nivel_optimo_temperatura { get; set; }
        public float nivel_optimo_luz { get; set; }
        public int IdUsuario { get; set; }

        // ✅ NUEVA PROPIEDAD (No se guarda en tabla Cultivo, viene del JOIN)
        public string NombrePropietario { get; set; } = "";

        public override string ToString()
        {
            return $"{IdPlanta};{NombrePlanta};{Descripcion};{RutaImagen}";
        }
    }
}