using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class HistorialRepository : BaseRepository
    {
        public Response<Historial_Riego> Insertar(Historial_Riego historial)
        {
            Response<Historial_Riego> response = new Response<Historial_Riego>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Obtener el siguiente valor de la secuencia
                    using (var cmdSeq = new OracleCommand("SELECT SEQ_HISTORIAL_RIEGO.NEXTVAL FROM DUAL", connection))
                    {
                        historial.Id = Convert.ToInt32(cmdSeq.ExecuteScalar());
                    }

                    // Insertar el registro con el ID generado
                    string query = @"
                INSERT INTO HISTORIAL_RIEGO (ID_HISTORIAL_RIEGO, FECHA_HORA, HUMEDAD, TEMPERATURA)
                VALUES (:IdHistorialRiego, :FechaHora, :Humedad, :Temperatura)";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(":IdHistorialRiego", OracleDbType.Int32).Value = historial.Id;
                        cmd.Parameters.Add(":FechaHora", OracleDbType.Date).Value = historial.Fecha;
                        cmd.Parameters.Add(":Humedad", OracleDbType.Single).Value = historial.Humedad;
                        cmd.Parameters.Add(":Temperatura", OracleDbType.Single).Value = historial.Temperatura;

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            response.Estado = true;
                            response.Mensaje = "Historial guardado correctamente.";
                            response.Entidad = historial;
                        }
                        else
                        {
                            response.Estado = false;
                            response.Mensaje = "No se insertó ningún registro.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.Estado = false;
                    response.Mensaje = "Error al guardar historial: " + ex.Message;
                }
            }

            return response;
        }


        public Response<Historial_Riego> BuscarPorId(int id)
        {
            string query = "SELECT ID_HISTORIAL_RIEGO, FECHA_HORA, HUMEDAD, TEMPERATURA FROM HISTORIAL_RIEGO WHERE ID_HISTORIAL_RIEGO = :id";

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
                            var historial = new Historial_Riego
                            {
                                Id = Convert.ToInt32(reader["ID_HISTORIAL_RIEGO"]),
                                Fecha = Convert.ToDateTime(reader["FECHA_HORA"]),
                                Humedad = Convert.ToSingle(reader["HUMEDAD"]),
                                Temperatura = Convert.ToSingle(reader["TEMPERATURA"])
                            };

                            return new Response<Historial_Riego>(true, "Historial encontrado correctamente", historial, null);
                        }
                        else
                        {
                            return new Response<Historial_Riego>(false, "No se encontró el historial con el ID especificado", null, null);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Historial_Riego>(false, $"Error en la base de datos: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Historial_Riego>(false, $"Error general: {ex.Message}", null, null);
            }
        }

        public Response<List<Historial_Riego>> MostrarTodos()
        {
            string query = "SELECT ID_HISTORIAL_RIEGO, FECHA_HORA, HUMEDAD, TEMPERATURA FROM HISTORIAL_RIEGO";
            var lista = new List<Historial_Riego>();

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
                            lista.Add(new Historial_Riego
                            {
                                Id = Convert.ToInt32(reader["ID_HISTORIAL_RIEGO"]),
                                Fecha = Convert.ToDateTime(reader["FECHA_HORA"]),
                                Humedad = Convert.ToSingle(reader["HUMEDAD"]),
                                Temperatura = Convert.ToSingle(reader["TEMPERATURA"])
                            });
                        }
                    }
                }

                return new Response<List<Historial_Riego>>(true, "Lista obtenida correctamente", lista, null);
            }
            catch (OracleException ex)
            {
                return new Response<List<Historial_Riego>>(false, $"Error Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<List<Historial_Riego>>(false, $"Error general: {ex.Message}", null, null);
            }
        }
    }
}