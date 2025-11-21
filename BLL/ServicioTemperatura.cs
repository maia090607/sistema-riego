using DAL;
using ENTITY;

namespace BLL
{
    public class ServicioTemperatura
    {
        private readonly TemperaturaRepository _repo = new TemperaturaRepository();

        public Response<Temperatura> Guardar(Temperatura t)
        {
            return _repo.Insertar(t);
        }
    }
}