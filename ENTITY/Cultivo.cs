
namespace ENTITY
{
    public class Cultivo
    {
        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public float nivel_optimo_humedad { get; set; }
        public float nivel_optimo_temperatura { get; set; }
        public float nivel_optimo_luz { get; set; } //No se sabe si tendremos este sensor, asi que lo pongo como opcional este atributo
        public int IdUsuario { get; set; }

        public override string ToString()
        {
            return $"{IdPlanta};{NombrePlanta};{Descripcion};{RutaImagen};{nivel_optimo_humedad};{nivel_optimo_temperatura};{nivel_optimo_luz}";
        }

    }
}
