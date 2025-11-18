using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class UsuarioRepository : BaseRepository, IRepository<Usuario>
    {
        public Response<Usuario> Insertar(Usuario usuario)
        {
            try
            {
                using (var conn = CrearConexion())
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand("pkg_usuario.insertar_usuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = usuario.IdUsuario;
                        cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = usuario.Nombre;
                        cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = usuario.Email;
                        cmd.Parameters.Add("p_nombre_usuario", OracleDbType.Varchar2).Value = usuario.NombreUsuario;
                        cmd.Parameters.Add("p_contrasena", OracleDbType.Varchar2).Value = usuario.Password;
                        cmd.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = usuario.Rol;
                        cmd.Parameters.Add("p_ruta_imagen", OracleDbType.Varchar2).Value = usuario.RutaImagen ?? (object)DBNull.Value;

                        // Parámetros de salida
                        var pEstado = cmd.Parameters.Add("p_estado", OracleDbType.Int32);
                        pEstado.Direction = ParameterDirection.Output;

                        var pMensaje = cmd.Parameters.Add("p_mensaje", OracleDbType.Varchar2, 200);
                        pMensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        int estado = Convert.ToInt32(pEstado.Value.ToString());
                        string mensaje = pMensaje.Value.ToString();

                        return new Response<Usuario>(estado == 1, mensaje, usuario, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error: {ex.Message}", null, null);
            }
        }

        public Response<Usuario> Actualizar(Usuario entidad)
        {
            try
            {
                using (var conn = CrearConexion())
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand("pkg_usuario.actualizar_usuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = entidad.IdUsuario;
                        cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = entidad.Nombre;
                        cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = entidad.Email;
                        cmd.Parameters.Add("p_nombre_usuario", OracleDbType.Varchar2).Value = entidad.NombreUsuario;
                        cmd.Parameters.Add("p_contrasena", OracleDbType.Varchar2).Value = entidad.Password;
                        cmd.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = entidad.Rol;
                        cmd.Parameters.Add("p_ruta_imagen", OracleDbType.Varchar2).Value = entidad.RutaImagen ?? (object)DBNull.Value;

                        var pEstado = cmd.Parameters.Add("p_estado", OracleDbType.Int32);
                        pEstado.Direction = ParameterDirection.Output;

                        var pMensaje = cmd.Parameters.Add("p_mensaje", OracleDbType.Varchar2, 200);
                        pMensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        int estado = Convert.ToInt32(pEstado.Value.ToString());
                        string mensaje = pMensaje.Value.ToString();

                        return new Response<Usuario>(estado == 1, mensaje, entidad, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error: {ex.Message}", null, null);
            }
        }

        public Response<Usuario> Eliminar(int id)
        {
            try
            {
                using (var conn = CrearConexion())
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand("pkg_usuario.eliminar_usuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = id;

                        var pEstado = cmd.Parameters.Add("p_estado", OracleDbType.Int32);
                        pEstado.Direction = ParameterDirection.Output;

                        var pMensaje = cmd.Parameters.Add("p_mensaje", OracleDbType.Varchar2, 200);
                        pMensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        int estado = Convert.ToInt32(pEstado.Value.ToString());
                        string mensaje = pMensaje.Value.ToString();

                        return new Response<Usuario>(estado == 1, mensaje, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error: {ex.Message}", null, null);
            }
        }

        public Response<Usuario> ObtenerPorId(int id)
        {
            try
            {
                using (var conn = CrearConexion())
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand("pkg_usuario.buscar_por_id", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = id;

                        var pCursor = cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        pCursor.Direction = ParameterDirection.Output;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var usuario = MapearUsuario(reader);
                                return new Response<Usuario>(true, "Usuario encontrado", usuario, null);
                            }
                            else
                            {
                                return new Response<Usuario>(false, "Usuario no encontrado", null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error: {ex.Message}", null, null);
            }
        }

        public Response<Usuario> ObtenerTodos()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();

                using (var conn = CrearConexion())
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand("pkg_usuario.listar_usuarios", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        var pCursor = cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        pCursor.Direction = ParameterDirection.Output;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(MapearUsuario(reader));
                            }
                        }
                    }
                }

                string mensaje = lista.Count > 0
                    ? $"Se encontraron {lista.Count} usuarios"
                    : "No hay usuarios registrados";

                return new Response<Usuario>(true, mensaje, null, lista);
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error: {ex.Message}", null, null);
            }
        }

        public Response<Usuario> BuscarPorUsuario(string nombreUsuario)
        {
            try
            {
                string query = "SELECT * FROM Usuario WHERE nombre_usuario = :usuario";

                using (var conn = CrearConexion())
                using (var cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2).Value = nombreUsuario;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var usuario = MapearUsuario(reader);
                            return new Response<Usuario>(true, "Usuario encontrado", usuario, null);
                        }
                        else
                        {
                            return new Response<Usuario>(false, "Usuario no encontrado", null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error: {ex.Message}", null, null);
            }
        }

        public Response<Usuario> BuscarPorCredenciales(string nombreUsuario, string password)
        {
            try
            {
                using (var conn = CrearConexion())
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand("pkg_usuario.buscar_por_credenciales", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = nombreUsuario;
                        cmd.Parameters.Add("p_contrasena", OracleDbType.Varchar2).Value = password;

                        var pCursor = cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        pCursor.Direction = ParameterDirection.Output;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var usuario = MapearUsuario(reader);
                                return new Response<Usuario>(true, "Credenciales válidas", usuario, null);
                            }
                            else
                            {
                                return new Response<Usuario>(false, "Credenciales inválidas", null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error: {ex.Message}", null, null);
            }
        }

        private Usuario MapearUsuario(OracleDataReader reader)
        {
            return new Usuario
            {
                IdUsuario = Convert.ToInt32(reader["CEDULA"]),        // ⬅️ CEDULA
                Nombre = reader["NOMBRE"]?.ToString(),
                Email = reader["EMAIL"]?.ToString(),
                NombreUsuario = reader["NOMBRE_USUARIO"]?.ToString(),
                Password = reader["CONTRASENA"]?.ToString(),           // ⬅️ CONTRASENA
                Rol = reader["ROL"]?.ToString(),
                RutaImagen = reader["RUTA_IMAGEN"]?.ToString(),
                Accedio = reader["ACCEDIO"] != DBNull.Value && Convert.ToInt32(reader["ACCEDIO"]) == 1
            };
        }
    }
}