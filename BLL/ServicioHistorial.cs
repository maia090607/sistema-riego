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

        // Método para mostrar todos los registros de historial
        public ReadOnlyCollection<Historial_Riego> MostrarTodos()
        {
            var respuesta = _historialRepository.MostrarTodos();
            var lista = respuesta != null && respuesta.Entidad != null
                ? respuesta.Entidad
                : new List<Historial_Riego>();

            return new ReadOnlyCollection<Historial_Riego>(lista);
        }

        // Método para guardar un registro de historial
        public string Guardar(Historial_Riego entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad), "El registro que se intentó guardar es nulo");

            var respuesta = _historialRepository.Insertar(entidad);

            // Si la inserción fue exitosa, el ID ya fue asignado en el objeto entidad
            return respuesta.Estado
                ? $"Historial registrado correctamente. ID generado: {entidad.Id}"
                : respuesta.Mensaje;
        }

        // Método para obtener un historial por su ID
        public Historial_Riego ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "El id debe ser mayor a cero");

            var respuesta = _historialRepository.BuscarPorId(id);
            return respuesta?.Entidad;
        }
    }
}
