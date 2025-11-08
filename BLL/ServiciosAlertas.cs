using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiciosAlertas
    {
        private readonly AlertasRepository alertasDAL = new AlertasRepository();

        public Response<Alertas> Agregar(Alertas alerta) => alertasDAL.Agregar(alerta);
        public Response<Alertas> MostrarTodos() => alertasDAL.MostrarTodos();
        public Response<Alertas> ObtenerPorId(int id) => alertasDAL.ObtenerPorId(id);
        public Response<Alertas> Eliminar(int id) => alertasDAL.Eliminar(id);
        public Response<Alertas> Actualizar(Alertas alerta) => alertasDAL.Actualizar(alerta);

    }
}
