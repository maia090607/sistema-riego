using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class GraficasRepository : BaseRepository
    {
        public GraficasRepository() : base()
        {
        }

        // ✅ Obtener todos los registros de la tabla GRAFICAS
        public Response<List<Main>> MostrarTodos()
        {
            string query = "SELECT ID, TEMP, HUMIDITY FROM GRAFICAS ORDER BY ID DESC";
            var lista = new List<Main>();

            try
            {
                using (var conexion = CrearConexion())
                using (var comando = new OracleCommand(query, conexion))
                {
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var grafica = new Main
                            {
                                temp = reader["TEMP"] == DBNull.Value ? 0 : Convert.ToDouble(reader["TEMP"]),
                                humidity = reader["HUMIDITY"] == DBNull.Value ? 0 : Convert.ToDouble(reader["HUMIDITY"])
                            };
                            lista.Add(grafica);
                        }
                    }
                }

                return new Response<List<Main>>(true, "Datos de gráficas obtenidos correctamente", lista, null);
            }
            catch (OracleException ex)
            {
                return new Response<List<Main>>(false, $"Error de Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<List<Main>>(false, $"Error general: {ex.Message}", null, null);
            }
        }

        // ✅ Obtener un registro por su ID
        public Response<Main> ObtenerPorId(int id)
        {
            string query = "SELECT ID, TEMP, HUMIDITY FROM GRAFICAS WHERE ID = :id";

            try
            {
                using (var conexion = CrearConexion())
                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(new OracleParameter("id", id));
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var grafica = new Main
                            {
                                temp = Convert.ToDouble(reader["TEMP"]),
                                humidity = Convert.ToDouble(reader["HUMIDITY"])
                            };
                            return new Response<Main>(true, "Gráfica encontrada correctamente", grafica, null);
                        }
                        else
                        {
                            return new Response<Main>(false, "No se encontró la gráfica con el ID especificado", null, null);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Main>(false, $"Error en Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Main>(false, $"Error general: {ex.Message}", null, null);
            }
        }

        // ✅ Guardar un nuevo registro
        public Response<Main> Guardar(Main entidad)
        {
            // ⚠️ Si tu tabla usa una secuencia autoincremental, usa GRAFICAS_SEQ.NEXTVAL en el INSERT
            string query = "INSERT INTO GRAFICAS (ID, TEMP, HUMIDITY) VALUES (GRAFICAS_SEQ.NEXTVAL, :temp, :humidity)";

            try
            {
                using (var conexion = CrearConexion())
                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(new OracleParameter("temp", entidad.temp));
                    comando.Parameters.Add(new OracleParameter("humidity", entidad.humidity));

                    conexion.Open();
                    int filas = comando.ExecuteNonQuery();

                    if (filas > 0)
                        return new Response<Main>(true, "Datos de gráfica guardados correctamente", entidad, null);
                    else
                        return new Response<Main>(false, "No se pudo insertar el registro en la tabla GRAFICAS", null, null);
                }
            }
            catch (OracleException ex)
            {
                return new Response<Main>(false, $"Error en Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Main>(false, $"Error general: {ex.Message}", null, null);
            }
        }
    }
}
