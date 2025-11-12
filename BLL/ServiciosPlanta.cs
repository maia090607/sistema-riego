using DAL;
using ENTITY;

namespace BLL
{
    public class ServiciosPlanta
    {
        private readonly PlantaRepository cultivoDAL = new PlantaRepository();
        public Response<Cultivo> Insertar(Cultivo c) => cultivoDAL.Insertar(c);
        public Response<Cultivo> ObtenerTodos() => cultivoDAL.ObtenerTodos();
        public Response<Cultivo> BuscarPorId(int id) => cultivoDAL.ObtenerPorId(id);
        public Response<Cultivo> Actualizar(Cultivo c) => cultivoDAL.Actualizar(c);
        public Response<Cultivo> Eliminar(int id) => cultivoDAL.Eliminar(id);
    }
}
