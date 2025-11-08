using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BLL
{
    public class ServicioGraficas
    {
        private readonly GraficasRepository _GraficasRepository;

        public ServicioGraficas()
        {
            _GraficasRepository = new GraficasRepository();
        }

        public ReadOnlyCollection<Main> MostrarTodos()
        {
            var respuesta = _GraficasRepository.MostrarTodos();
            var lista = respuesta.Entidad != null && respuesta.Entidad != null ? respuesta.Entidad : new List<Main>();
            return new ReadOnlyCollection<Main>(lista);
        }

        public string Guardar(Main entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El registro que se intentó guardar es nulo");

            var respuesta = _GraficasRepository.Guardar(entidad);
            return respuesta.Estado ? "Historial registrado correctamente" : respuesta.Mensaje;
        }

        public Main ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("El id debe ser mayor a cero");

            var respuesta = _GraficasRepository.ObtenerPorId(id);
            return respuesta.Entidad;
        }
    }
}

