using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

                        cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = usuario.IdUsuario;
                        cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = usuario.Nombre;
                        cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = usuario.Email;
                        cmd.Parameters.Add("p_nombre_usuario", OracleDbType.Varchar2).Value = usuario.NombreUsuario;
                        cmd.Parameters.Add("p_contraseña", OracleDbType.Varchar2).Value = usuario.Password;
                        cmd.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = usuario.Rol;
                        cmd.Parameters.Add("p_ruta_imagen", OracleDbType.Varchar2).Value = usuario.RutaImagen ?? (object)DBNull.Value;

                        // 🔹 Conversión correcta de bool → número
                        cmd.Parameters.Add("p_accedio", OracleDbType.Int32).Value = usuario.Accedio ? 1 : 0;

                        cmd.ExecuteNonQuery();

                        return new Response<Usuario>(true, "Usuario insertado correctamente", usuario, null);
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Usuario>(false, $"Error en la base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error al insertar el usuario:\n{ex.Message}", null, null);
            }
        }


        public Response<Usuario> Actualizar(Usuario entidad)
        {
            try
            {
                if (entidad == null || entidad.IdUsuario <= 0)
                    return new Response<Usuario>(false, "Datos inválidos para actualizar", null, null);

                string sentencia = @"UPDATE USUARIO SET
                                NOMBRE = :p_nombre,
                                EMAIL = :p_email,
                                NOMBRE_USUARIO = :p_usuario,
                                CONTRASEÑA = :p_pass,
                                ROL = :p_rol,
                                RUTA_IMAGEN = :p_ruta,
                                ACCEDIO = :p_accedio
                             WHERE ID_USUARIO = :p_id";

                using (var conexion = new OracleConnection(_connectionString))
                using (var comando = new OracleCommand(sentencia, conexion))
                {
                    // Parámetros
                    comando.Parameters.Add(new OracleParameter("p_nombre", entidad.Nombre));
                    comando.Parameters.Add(new OracleParameter("p_email", entidad.Email));
                    comando.Parameters.Add(new OracleParameter("p_usuario", entidad.NombreUsuario));
                    comando.Parameters.Add(new OracleParameter("p_pass", entidad.Password));
                    comando.Parameters.Add(new OracleParameter("p_rol", entidad.Rol));
                    comando.Parameters.Add(new OracleParameter("p_ruta", entidad.RutaImagen ?? (object)DBNull.Value));
                    comando.Parameters.Add(new OracleParameter("p_accedio", entidad.Accedio ? 1 : 0));
                    comando.Parameters.Add(new OracleParameter("p_id", entidad.IdUsuario));

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        return new Response<Usuario>(true, "Usuario actualizado correctamente", entidad, null);
                    else
                        return new Response<Usuario>(false, "No se encontró el usuario para actualizar", null, null);
                }
            }
            catch (OracleException ex)
            {
                return new Response<Usuario>(false, $"Error en la base de datos: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error al actualizar el usuario: {ex.Message}", null, null);
            }
        }




        public Response<Usuario> Eliminar(int id)
    {
        try
        {
            if (id <= 0)
                return new Response<Usuario>(false, "El ID debe ser mayor a cero", null, null);

                string sentencia = "DELETE FROM USUARIO WHERE ID_USUARIO = :id";

                using (var conexion = new OracleConnection(_connectionString))
            using (var comando = new OracleCommand(sentencia, conexion))
            {
                comando.Parameters.Add(new OracleParameter("id", id));

                conexion.Open();
                int filas = comando.ExecuteNonQuery();

                if (filas > 0)
                    return new Response<Usuario>(true, "Usuario eliminado correctamente", null, null);
                else
                    return new Response<Usuario>(false, "No se encontró el usuario con el ID especificado", null, null);
            }
        }
        catch (OracleException ex)
        {
            return new Response<Usuario>(false, $"Error en la base de datos:\n{ex.Message}", null, null);
        }
        catch (Exception ex)
        {
            return new Response<Usuario>(false, $"Error al eliminar el usuario:\n{ex.Message}", null, null);
        }
    }


        public Response<Usuario> ObtenerPorId(int id)
        {
            try
            {
                string sentencia = "SELECT * FROM USUARIO WHERE ID_USUARIO = :id";

                using (var conexion = new OracleConnection(_connectionString))
                using (var comando = new OracleCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new OracleParameter("id", id));
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return new Response<Usuario>(false, "No se encontró el usuario con el ID especificado", null, null);
                        }

                        // Mapea el usuario directamente
                        var usuario = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                            Nombre = reader["NOMBRE"].ToString(),
                            Email = reader["EMAIL"].ToString(),
                            NombreUsuario = reader["NOMBRE_USUARIO"].ToString(),
                            Password = reader["CONTRASEÑA"].ToString(), // sin tilde
                            Rol = reader["ROL"].ToString(),
                            RutaImagen = reader["RUTA_IMAGEN"]?.ToString(), // puede ser null
                            Accedio = Convert.ToInt32(reader["ACCEDIO"]) == 1
                        };

                        return new Response<Usuario>(true, "Usuario encontrado", usuario, null);
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Usuario>(false, $"Error en la base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error al buscar el usuario:\n{ex.Message}", null, null);
            }
        }


        public Response<Usuario> ObtenerTodos()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                string sentencia = "SELECT * FROM USUARIO ORDER BY NOMBRE"; // ✅ Sin corchetes, todo en mayúsculas

                using (var conexion = new OracleConnection(_connectionString))
                using (var comando = new OracleCommand(sentencia, conexion))
                {
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearUsuario(reader)); // Usa tu función corregida
                        }
                    }
                }

                string mensaje = lista.Count > 0
                    ? $"Se encontraron {lista.Count} usuarios"
                    : "No hay usuarios registrados";

                // ✅ Si no hay usuarios, Estado debe ser false (opcional según tu lógica)
                bool estado = lista.Count > 0;

                return new Response<Usuario>(estado, mensaje, null, lista);
            }
            catch (OracleException ex)
            {
                return new Response<Usuario>(false, $"Error en la base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error al obtener los usuarios:\n{ex.Message}", null, null);
            }
        }

        public Response<Usuario> BuscarPorUsuario(string nombreUsuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreUsuario))
                    return new Response<Usuario>(false, "El nombre de usuario no puede estar vacío", null, null);

                string sentencia = "SELECT * FROM Usuario WHERE nombre_usuario = :usuario";

                using (var conexion = new OracleConnection(_connectionString))
                using (var comando = new OracleCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new OracleParameter("usuario", nombreUsuario));

                    conexion.Open();
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                                Nombre = reader["NOMBRE"]?.ToString(),
                                Email = reader["EMAIL"]?.ToString(),
                                NombreUsuario = reader["NOMBRE_USUARIO"]?.ToString(),
                                Password = reader["CONTRASEÑA"]?.ToString(),
                                Rol = reader["ROL"]?.ToString(),
                                RutaImagen = reader["RUTA_IMAGEN"]?.ToString(),
                                Accedio = Convert.ToInt32(reader["ACCEDIO"]) == 1
                            };

                            return new Response<Usuario>(true, "Usuario encontrado", usuario, null);
                        }
                        else
                        {
                            return new Response<Usuario>(false, "No se encontró el usuario especificado", null, null);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Usuario>(false, $"Error en la base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error al buscar el usuario:\n{ex.Message}", null, null);
            }

        }
        public Response<Usuario> BuscarPorCredenciales(string nombreUsuario, string password)
        {
            string query = "SELECT * FROM USUARIO WHERE NOMBRE_USUARIO = :nombreUsuario AND CONTRASEÑA = :password";

            try
            {
                using (var conexion = CrearConexion())
                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(new OracleParameter("nombreUsuario", OracleDbType.Varchar2)).Value = nombreUsuario;
                    comando.Parameters.Add(new OracleParameter("password", OracleDbType.Varchar2)).Value = password;

                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                                Nombre = reader["NOMBRE"].ToString(),
                                Email = reader["EMAIL"]?.ToString(),
                                NombreUsuario = reader["NOMBRE_USUARIO"].ToString(),
                                Password = reader["CONTRASEÑA"].ToString(),
                                Rol = reader["ROL"]?.ToString(),
                                RutaImagen = reader["RUTA_IMAGEN"]?.ToString(),
                                Accedio = Convert.ToInt32(reader["ACCEDIO"]) == 1
                            };

                            return new Response<Usuario>(true, "Usuario encontrado", usuario, null);
                        }
                    }

                    return new Response<Usuario>(false, "Usuario o contraseña incorrectos", null, null);
                }
            }
            catch (OracleException ex)
            {
                return new Response<Usuario>(false, $"Error en la base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, $"Error inesperado:\n{ex.Message}", null, null);
            }
        }


        private Usuario MapearUsuario(OracleDataReader reader)
        {
            return new Usuario
            {
                IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                Nombre = reader["NOMBRE"]?.ToString(),
                Email = reader["EMAIL"]?.ToString(),
                NombreUsuario = reader["NOMBRE_USUARIO"]?.ToString(),
                Password = reader["CONTRASEÑA"]?.ToString(),
                Rol = reader["ROL"]?.ToString(),
                RutaImagen = reader["RUTA_IMAGEN"]?.ToString(),
                Accedio = Convert.ToInt32(reader["ACCEDIO"]) == 1
            };
        }

    }
}