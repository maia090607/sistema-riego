using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class UsuarioRepository : BaseRepository
    {
        public Response<Usuario> Insertar(Usuario usuario)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();
                    // Usamos el paquete PKG_USUARIO
                    using (var cmd = new OracleCommand("PKG_USUARIO.insertar_usuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = usuario.IdUsuario;
                        cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = usuario.Nombre;
                        cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = usuario.Email;
                        cmd.Parameters.Add("p_nombre_usuario", OracleDbType.Varchar2).Value = usuario.NombreUsuario;
                        cmd.Parameters.Add("p_contrasena", OracleDbType.Varchar2).Value = usuario.Password; // Mapeo clave
                        cmd.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = usuario.Rol;
                        cmd.Parameters.Add("p_ruta_imagen", OracleDbType.Varchar2).Value = usuario.RutaImagen ?? "";
                        
                        var p_estado = cmd.Parameters.Add("p_estado", OracleDbType.Int32);
                        p_estado.Direction = ParameterDirection.Output;
                        var p_mensaje = cmd.Parameters.Add("p_mensaje", OracleDbType.Varchar2, 200);
                        p_mensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool exito = Convert.ToInt32(p_estado.Value.ToString()) == 1;
                        return new Response<Usuario>(exito, p_mensaje.Value.ToString(), usuario, null);
                    }
                }
                catch (Exception ex) { return new Response<Usuario>(false, ex.Message, null, null); }
            }
        }

        public Response<Usuario> Actualizar(Usuario usuario)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("PKG_USUARIO.actualizar_usuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = usuario.IdUsuario;
                        cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = usuario.Nombre;
                        cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = usuario.Email;
                        cmd.Parameters.Add("p_nombre_usuario", OracleDbType.Varchar2).Value = usuario.NombreUsuario;
                        
                        // ✅ IMPORTANTE: Aquí pasamos la contraseña. Si viene nula desde C#, fallará en BD.
                        // El controlador debe asegurar que esto NO sea nulo.
                        cmd.Parameters.Add("p_contrasena", OracleDbType.Varchar2).Value = usuario.Password; 
                        
                        cmd.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = usuario.Rol;
                        cmd.Parameters.Add("p_ruta_imagen", OracleDbType.Varchar2).Value = usuario.RutaImagen ?? "";

                        var p_estado = cmd.Parameters.Add("p_estado", OracleDbType.Int32);
                        p_estado.Direction = ParameterDirection.Output;
                        var p_mensaje = cmd.Parameters.Add("p_mensaje", OracleDbType.Varchar2, 200);
                        p_mensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool exito = Convert.ToInt32(p_estado.Value.ToString()) == 1;
                        return new Response<Usuario>(exito, p_mensaje.Value.ToString(), usuario, null);
                    }
                }
                catch (Exception ex) { return new Response<Usuario>(false, ex.Message, null, null); }
            }
        }

        public Response<Usuario> BuscarPorId(int id)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("PKG_USUARIO.buscar_por_id", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = id;
                        var p_cursor = cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        p_cursor.Direction = ParameterDirection.Output;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Response<Usuario>(true, "Usuario encontrado", MapearUsuario(reader), null);
                            }
                            return new Response<Usuario>(false, "Usuario no encontrado", null, null);
                        }
                    }
                }
                catch (Exception ex) { return new Response<Usuario>(false, ex.Message, null, null); }
            }
        }

        public Response<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("PKG_USUARIO.listar_usuarios", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var p_cursor = cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        p_cursor.Direction = ParameterDirection.Output;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) lista.Add(MapearUsuario(reader));
                        }
                        return new Response<Usuario>(true, "Usuarios listados", null, lista);
                    }
                }
                catch (Exception ex) { return new Response<Usuario>(false, ex.Message, null, null); }
            }
        }

        public Response<Usuario> Eliminar(int id)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("PKG_USUARIO.eliminar_usuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_cedula", OracleDbType.Int32).Value = id;
                        var p_estado = cmd.Parameters.Add("p_estado", OracleDbType.Int32);
                        p_estado.Direction = ParameterDirection.Output;
                        var p_mensaje = cmd.Parameters.Add("p_mensaje", OracleDbType.Varchar2, 200);
                        p_mensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        bool exito = Convert.ToInt32(p_estado.Value.ToString()) == 1;
                        return new Response<Usuario>(exito, p_mensaje.Value.ToString(), null, null);
                    }
                }
                catch (Exception ex) { return new Response<Usuario>(false, ex.Message, null, null); }
            }
        }
        
        public Response<Usuario> BuscarPorUsuario(string nombreUsuario)
        {
             // Implementación básica directa para validaciones
             using (var conn = CrearConexion())
             {
                 try {
                     conn.Open();
                     string query = "SELECT * FROM Usuario WHERE nombre_usuario = :user";
                     using(var cmd = new OracleCommand(query, conn)){
                         cmd.Parameters.Add(":user", OracleDbType.Varchar2).Value = nombreUsuario;
                         using(var reader = cmd.ExecuteReader()){
                             if(reader.Read()) return new Response<Usuario>(true, "Encontrado", MapearUsuario(reader), null);
                             return new Response<Usuario>(false, "No encontrado", null, null);
                         }
                     }
                 } catch(Exception ex) { return new Response<Usuario>(false, ex.Message, null, null); }
             }
        }

        public Response<Usuario> BuscarPorCredenciales(string usuario, string pass)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("PKG_USUARIO.buscar_por_credenciales", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = usuario;
                        cmd.Parameters.Add("p_contrasena", OracleDbType.Varchar2).Value = pass;
                        var p_cursor = cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        p_cursor.Direction = ParameterDirection.Output;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Response<Usuario>(true, "Login correcto", MapearUsuario(reader), null);
                            }
                            return new Response<Usuario>(false, "Credenciales incorrectas", null, null);
                        }
                    }
                }
                catch (Exception ex) { return new Response<Usuario>(false, ex.Message, null, null); }
            }
        }

        // ✅ MAPEO CRÍTICO: Asegura que la columna "contrasena" de la BD vaya a la propiedad "Password"
        private Usuario MapearUsuario(OracleDataReader reader)
        {
            return new Usuario
            {
                IdUsuario = Convert.ToInt32(reader["CEDULA"]),
                Nombre = reader["NOMBRE"].ToString(),
                Email = reader["EMAIL"].ToString(),
                NombreUsuario = reader["NOMBRE_USUARIO"].ToString(),
                Password = reader["CONTRASENA"].ToString(), // ¡AQUÍ ESTABA EL POSIBLE ERROR!
                Rol = reader["ROL"].ToString(),
                RutaImagen = reader["RUTA_IMAGEN"] != DBNull.Value ? reader["RUTA_IMAGEN"].ToString() : "",
                Accedio = reader["ACCEDIO"] != DBNull.Value && Convert.ToInt32(reader["ACCEDIO"]) == 1
            };
        }
    }
}