using DAL;
using ENTITY;

namespace BLL
{
    public class ServiciosHumedad
    {
        private readonly HumedadRepository HumedadDAL = new HumedadRepository();

        public Response<humedad> insertar (humedad numero) => HumedadDAL.Insertar(numero);
        public Response<humedad> MostrarTodos() => HumedadDAL.MostrarTodo();
    }
}
