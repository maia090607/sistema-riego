using DAL;
using ENTITY;

namespace BLL
{
    public class ServiciosUsuario
    {
        private UsuarioRepository usuarioDAL = new UsuarioRepository();

        public Response<Usuario> Insertar(Usuario u) => usuarioDAL.Insertar(u);

        public Response<Usuario> ObtenerTodos() => usuarioDAL.ObtenerTodos();

        // 🔴 ANTES (Error): public Response<Usuario> BuscarPorId(int id) => usuarioDAL.ObtenerPorId(id);
        // 🟢 AHORA (Corregido): Llamamos a BuscarPorId que es como se llama en el repositorio
        public Response<Usuario> BuscarPorId(int id) => usuarioDAL.BuscarPorId(id);

        public Response<Usuario> Actualizar(Usuario u) => usuarioDAL.Actualizar(u);

        public Response<Usuario> Eliminar(int id) => usuarioDAL.Eliminar(id);

        public Response<Usuario> ValidarNombreUsuario(string nombreUsuario) => usuarioDAL.BuscarPorUsuario(nombreUsuario);

        public Response<Usuario> ValidarCredenciales(string nombreUsuario, string password) => usuarioDAL.BuscarPorCredenciales(nombreUsuario, password);
    }
}