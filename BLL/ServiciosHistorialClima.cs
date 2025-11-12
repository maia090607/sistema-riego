using DAL;
using Entity;

namespace BLL
{
    public class ServicioClima
    {
        private readonly RepositorioClima _repositorioClima = new RepositorioClima();

        public Response<RegistroClimatico> Guardar(RegistroClimatico registro)
        {
            if (registro == null)
                return new Response<RegistroClimatico>(false, "❌ El registro no puede ser nulo.", null, null);

            return _repositorioClima.Insertar(registro);
        }

        public Response<RegistroClimatico> MostrarTodos()
        {
            return _repositorioClima.MostrarTodos();

        }
    }
}
