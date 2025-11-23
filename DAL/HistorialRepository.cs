using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

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

                    // Definición de la consulta llamando al procedimiento almacenado
                    string query = @"
            BEGIN 
                PKG_HISTORIAL_RIEGO.SP_INSERTAR_HISTORIAL(
                    :p_fecha_hora,
                    :p_humedad,
                    :p_temperatura,
                    :p_id_planta,   -- ✅ Nuevo parámetro agregado
                    :p_id_generado,
                    :p_estado,
                    :p_mensaje
                );
            END;";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        // --- PARÁMETROS DE ENTRADA ---
                        cmd.Parameters.Add(":p_fecha_hora", OracleDbType.Date).Value = historial.Fecha;
                        cmd.Parameters.Add(":p_humedad", OracleDbType.Single).Value = historial.Humedad;
                        cmd.Parameters.Add(":p_temperatura", OracleDbType.Single).Value = historial.Temperatura;

                        // ✅ Enviar ID de planta (o DBNull si es 0/inválido)
                        if (historial.IdPlanta > 0)
                        {
                            cmd.Parameters.Add(":p_id_planta", OracleDbType.Int32).Value = historial.IdPlanta;
                        }
                        else
                        {
                            cmd.Parameters.Add(":p_id_planta", OracleDbType.Int32).Value = DBNull.Value;
                        }

                        // --- PARÁMETROS DE SALIDA ---
                        var paramId = cmd.Parameters.Add(":p_id_generado", OracleDbType.Int32);
                        paramId.Direction = ParameterDirection.Output;

                        var paramEstado = cmd.Parameters.Add(":p_estado", OracleDbType.Int32);
                        paramEstado.Direction = ParameterDirection.Output;

                        var paramMensaje = cmd.Parameters.Add(":p_mensaje", OracleDbType.Varchar2, 200);
                        paramMensaje.Direction = ParameterDirection.Output;

                        // --- EJECUCIÓN ---
                        cmd.ExecuteNonQuery();

                        // Recuperar valores de salida
                        // Validar si el ID generado no es nulo antes de convertir
                        if (paramId.Value != DBNull.Value)
                        {
                            historial.Id = Convert.ToInt32(paramId.Value.ToString());
                        }

                        int estado = Convert.ToInt32(paramEstado.Value.ToString());
                        string mensaje = paramMensaje.Value.ToString();

                        // Configurar respuesta
                        if (estado == 1)
                        {
                            response.Estado = true;
                            response.Mensaje = mensaje;
                            response.Entidad = historial;
                        }
                        else
                        {
                            response.Estado = false;
                            response.Mensaje = mensaje;
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.Estado = false;
                    response.Mensaje = "Error en HistorialRepository: " + ex.Message;
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
            // ✅ QUERY ACTUALIZADA CON JOINS A CULTIVO Y USUARIO
            string query = @"
                SELECT 
                    h.ID_HISTORIAL_RIEGO, 
                    h.FECHA_HORA, 
                    h.HUMEDAD, 
                    h.TEMPERATURA,
                    h.ID_PLANTA,
                    c.NOMBRE_PLANTA,
                    u.NOMBRE_USUARIO as PROPIETARIO
                FROM HISTORIAL_RIEGO h
                LEFT JOIN CULTIVO c ON h.ID_PLANTA = c.ID_PLANTA
                LEFT JOIN USUARIO u ON c.ID_USUARIO = u.CEDULA
                ORDER BY h.FECHA_HORA DESC";

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
                                Temperatura = Convert.ToSingle(reader["TEMPERATURA"]),

                                // ✅ LECTURA DE NUEVOS DATOS
                                IdPlanta = reader["ID_PLANTA"] != DBNull.Value ? Convert.ToInt32(reader["ID_PLANTA"]) : 0,
                                NombrePlanta = reader["NOMBRE_PLANTA"] != DBNull.Value ? reader["NOMBRE_PLANTA"].ToString() : "Desconocida",
                                NombrePropietario = reader["PROPIETARIO"] != DBNull.Value ? reader["PROPIETARIO"].ToString() : "Sin Asignar"
                            });
                        }
                    }
                }
                return new Response<List<Historial_Riego>>(true, "Lista obtenida correctamente", lista, null);
            }
            catch (Exception ex)
            {
                return new Response<List<Historial_Riego>>(false, $"Error: {ex.Message}", null, null);
            }
        }
    }
}