using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class PlantaRepository : BaseRepository, IRepository<Cultivo>
    {
        public Response<Cultivo> Insertar(Cultivo planta)
        {
            try
            {
                using (var conn = new OracleConnection(_connectionString))
                {
                    conn.Open();
                    // ✅ Se agregó ID_USUARIO al INSERT
                    string sentencia = @"INSERT INTO Cultivo
                        (id_planta, nombre_planta, descripcion, ruta_imagen,
                            nivel_optimo_humedad, nivel_optimo_temperatura, nivel_optimo_luz, ID_USUARIO)
                        VALUES (:id, :nombre, :descripcionParam, :ruta, 
                        :humedad, :temp, :luz, :idUsu)";

                    using (var cmd = new OracleCommand(sentencia, conn))
                    {
                        cmd.Parameters.Add("id", OracleDbType.Int32).Value = planta.IdPlanta;
                        cmd.Parameters.Add("nombre", OracleDbType.Varchar2).Value = planta.NombrePlanta ?? "";
                        cmd.Parameters.Add("descripcionParam", OracleDbType.Varchar2).Value = planta.Descripcion ?? "";
                        cmd.Parameters.Add("ruta", OracleDbType.Varchar2).Value = planta.RutaImagen ?? "";
                        cmd.Parameters.Add("humedad", OracleDbType.Single).Value = planta.nivel_optimo_humedad;
                        cmd.Parameters.Add("temp", OracleDbType.Single).Value = planta.nivel_optimo_temperatura;
                        cmd.Parameters.Add("luz", OracleDbType.Single).Value = planta.nivel_optimo_luz;

                        // ✅ Parámetro del usuario (si es 0, enviamos DBNull para evitar error, aunque debería tener valor)
                        if (planta.IdUsuario > 0)
                            cmd.Parameters.Add("idUsu", OracleDbType.Int32).Value = planta.IdUsuario;
                        else
                            cmd.Parameters.Add("idUsu", OracleDbType.Int32).Value = DBNull.Value;

                        int filas = cmd.ExecuteNonQuery();

                        return new Response<Cultivo>(
                            filas > 0,
                            filas > 0 ? "Planta registrada correctamente" : "No se pudo insertar",
                            planta,
                            null
                        );
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Cultivo>(false, $"Error BD: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Cultivo>(false, $"Error General: {ex.Message}", null, null);
            }
        }


        public Response<Cultivo> Actualizar(Cultivo planta)
        {
            try
            {
                string sentencia = "UPDATE Cultivo SET " +
                                   "nombre_planta = :nombre, " +
                                   "descripcion = :descripcionParam, " +
                                   "ruta_imagen = :ruta, " +
                                   "nivel_optimo_humedad = :humedad, " +
                                   "nivel_optimo_temperatura = :temp, " +
                                   "nivel_optimo_luz = :luz " +
                                   "WHERE id_planta = :id";

                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sentencia, conn))
                {
                    // 🔹 Parámetros con validación nula o vacía
                    if (string.IsNullOrWhiteSpace(planta.NombrePlanta))
                        cmd.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = planta.NombrePlanta;

                    if (string.IsNullOrWhiteSpace(planta.Descripcion))
                        cmd.Parameters.Add(":descripcionParam", OracleDbType.Varchar2).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(":descripcionParam", OracleDbType.Varchar2).Value = planta.Descripcion;

                    if (string.IsNullOrWhiteSpace(planta.RutaImagen))
                        cmd.Parameters.Add(":ruta", OracleDbType.Varchar2).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(":ruta", OracleDbType.Varchar2).Value = planta.RutaImagen;

                    cmd.Parameters.Add(":humedad", OracleDbType.Single).Value = planta.nivel_optimo_humedad;
                    cmd.Parameters.Add(":temp", OracleDbType.Single).Value = planta.nivel_optimo_temperatura;
                    cmd.Parameters.Add(":luz", OracleDbType.Single).Value = planta.nivel_optimo_luz;

                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = planta.IdPlanta;

                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();

                    return new Response<Cultivo>(
                        filas > 0,
                        filas > 0 ? "✅ Planta actualizada correctamente" : "⚠️ No se encontró la planta con ese ID",
                        planta,
                        null
                    );
                }
            }
            catch (OracleException ex)
            {
                return new Response<Cultivo>(false, $"Error de base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Cultivo>(false, $"Error al actualizar planta:\n{ex.Message}", null, null);
            }
        }


        public Response<Cultivo> Eliminar(int id)
        {
            try
            {
                string sentencia = "DELETE FROM Cultivo WHERE id_planta = :id";

                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sentencia, conn))
                {
                    // Siempre usar el nombre del parámetro con ":" también al agregarlo
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = id;

                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();

                    return new Response<Cultivo>(
                        filas > 0,
                        filas > 0 ? "✅ Planta eliminada correctamente" : "⚠️ No se encontró la planta con ese ID",
                        null,
                        null
                    );
                }
            }
            catch (OracleException ex)
            {
                return new Response<Cultivo>(false, $"Error de base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Cultivo>(false, $"Error al eliminar planta:\n{ex.Message}", null, null);
            }
        }

        public Response<Cultivo> ObtenerPorId(int id)
        {
            try
            {
                string sentencia = "SELECT * FROM Cultivo WHERE id_planta = :id";

                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sentencia, conn))
                {
                    // 🔹 Importante: usar el mismo formato del parámetro (:id)
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = id;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var planta = MapearPlanta(reader);
                            return new Response<Cultivo>(true, "✅ Planta encontrada", planta, null);
                        }
                        else
                        {
                            return new Response<Cultivo>(false, "⚠️ No se encontró la planta con ese ID", null, null);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Cultivo>(false, $"Error de base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Cultivo>(false, $"Error al obtener planta:\n{ex.Message}", null, null);
            }
        }

        public Response<Cultivo> ObtenerTodos()
        {
            try
            {
                List<Cultivo> lista = new List<Cultivo>();
                string sentencia = "SELECT * FROM Cultivo ORDER BY nombre_planta";

                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sentencia, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearPlanta(reader));
                        }
                    }

                    string mensaje = lista.Count > 0
                        ? $"✅ Se encontraron {lista.Count} plantas registradas."
                        : "⚠️ No hay plantas registradas.";

                    return new Response<Cultivo>(true, mensaje, null, lista);
                }
            }
            catch (OracleException ex)
            {
                return new Response<Cultivo>(false, $"Error de base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Cultivo>(false, $"Error al obtener plantas:\n{ex.Message}", null, null);
            }
        }

        public Response<Cultivo> ObtenerPorUsuario(int idUsuario)
        {
            try
            {
                List<Cultivo> lista = new List<Cultivo>();
                // ✅ Filtramos por usuario
                string sentencia = "SELECT * FROM Cultivo WHERE ID_USUARIO = :idUsu ORDER BY nombre_planta";

                using (var conn = new OracleConnection(_connectionString))
                using (var cmd = new OracleCommand(sentencia, conn))
                {
                    cmd.Parameters.Add("idUsu", OracleDbType.Int32).Value = idUsuario;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) lista.Add(MapearPlanta(reader));
                    }
                    return new Response<Cultivo>(true, $"Encontradas {lista.Count}", null, lista);
                }
            }
            catch (Exception ex) { return new Response<Cultivo>(false, ex.Message, null, null); }
        }

        private Cultivo MapearPlanta(OracleDataReader reader)
        {
            return new Cultivo
            {
                IdPlanta = reader["ID_PLANTA"] != DBNull.Value ? Convert.ToInt32(reader["ID_PLANTA"]) : 0,
                NombrePlanta = reader["NOMBRE_PLANTA"]?.ToString(),
                Descripcion = reader["DESCRIPCION"]?.ToString(),
                RutaImagen = reader["RUTA_IMAGEN"]?.ToString(),
                nivel_optimo_humedad = reader["NIVEL_OPTIMO_HUMEDAD"] != DBNull.Value ? Convert.ToSingle(reader["NIVEL_OPTIMO_HUMEDAD"]) : 0,
                nivel_optimo_temperatura = reader["NIVEL_OPTIMO_TEMPERATURA"] != DBNull.Value ? Convert.ToSingle(reader["NIVEL_OPTIMO_TEMPERATURA"]) : 0,
                nivel_optimo_luz = reader["NIVEL_OPTIMO_LUZ"] != DBNull.Value ? Convert.ToSingle(reader["NIVEL_OPTIMO_LUZ"]) : 0,
                IdUsuario = reader["ID_USUARIO"] != DBNull.Value ? Convert.ToInt32(reader["ID_USUARIO"]) : 0 
            };
        }

    }
}