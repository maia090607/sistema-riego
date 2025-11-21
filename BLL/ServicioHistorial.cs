using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BLL
{
    public class ServicioHistorial
    {
        private readonly HistorialRepository _historialRepository;

        public ServicioHistorial()
        {
            _historialRepository = new HistorialRepository();
        }

        public ReadOnlyCollection<Historial_Riego> MostrarTodos()
        {
            var respuesta = _historialRepository.MostrarTodos();
            var lista = respuesta != null && respuesta.Entidad != null
                ? respuesta.Entidad
                : new List<Historial_Riego>();
            return new ReadOnlyCollection<Historial_Riego>(lista);
        }

        // ✅ CORREGIDO: Ahora devuelve Response<T> en lugar de string
        public Response<Historial_Riego> Guardar(Historial_Riego entidad)
        {
            if (entidad == null)
            {
                return new Response<Historial_Riego>(false, "El registro es nulo", null, null);
            }

            // Retornamos el objeto respuesta completo (Estado, Mensaje, Entidad)
            return _historialRepository.Insertar(entidad);
        }

        public Historial_Riego ObtenerPorId(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            var respuesta = _historialRepository.BuscarPorId(id);
            return respuesta?.Entidad;
        }
    }
}