using System.Collections;
using System.Collections.Generic;

namespace DAL
{
    public class Response<T>
    {
        public Response()
        {
            Estado = false;
            Mensaje = string.Empty;
            Entidad = default(T);
            Lista = null;
        }


        public Response(bool estado, string mensaje, T entidad, List<T> lista)
        {
            Estado = estado;
            Mensaje = mensaje;
            Entidad = entidad;
            Lista = lista;
        }
        public bool Estado { get; set; }

        public string Mensaje { get; set; }
        public T Entidad { get; set; }
        public IList<T> Lista { get; set; }
    }
}