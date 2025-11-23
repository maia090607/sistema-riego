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
                    // ✅ Asegúrate que el SQL tenga :p_tipo_riego
                    string query = @"
                        BEGIN 
                            PKG_HISTORIAL_RIEGO.SP_INSERTAR_HISTORIAL(
                                :p_fecha_hora,
                                :p_humedad,
                                :p_temperatura,
                                :p_id_planta,
                                :p_tipo_riego,  -- <--- ESTO ES VITAL
                                :p_id_generado,
                                :p_estado,
                                :p_mensaje
                            );
                        END;";

                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(":p_fecha_hora", OracleDbType.Date).Value = historial.Fecha;
                        cmd.Parameters.Add(":p_humedad", OracleDbType.Single).Value = historial.Humedad;
                        cmd.Parameters.Add(":p_temperatura", OracleDbType.Single).Value = historial.Temperatura;

                        if (historial.IdPlanta > 0)
                            cmd.Parameters.Add(":p_id_planta", OracleDbType.Int32).Value = historial.IdPlanta;
                        else
                            cmd.Parameters.Add(":p_id_planta", OracleDbType.Int32).Value = DBNull.Value;

                        // ✅ ENVIAR EL DATO A ORACLE
                        cmd.Parameters.Add(":p_tipo_riego", OracleDbType.Varchar2).Value = historial.TipoRiego ?? "Manual";

                        var paramId = cmd.Parameters.Add(":p_id_generado", OracleDbType.Int32); paramId.Direction = ParameterDirection.Output;
                        var paramEstado = cmd.Parameters.Add(":p_estado", OracleDbType.Int32); paramEstado.Direction = ParameterDirection.Output;
                        var paramMensaje = cmd.Parameters.Add(":p_mensaje", OracleDbType.Varchar2, 200); paramMensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        if (Convert.ToInt32(paramEstado.Value.ToString()) == 1)
                        {
                            response.Estado = true;
                            response.Mensaje = paramMensaje.Value.ToString();
                            response.Entidad = historial;
                        }
                        else
                        {
                            response.Estado = false;
                            response.Mensaje = paramMensaje.Value.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.Estado = false;
                    response.Mensaje = "Error DAL: " + ex.Message;
                }
            }
            return response;
        }

        public Response<List<Historial_Riego>> MostrarTodos()
        {
            string query = @"
                SELECT h.ID_HISTORIAL_RIEGO, h.FECHA_HORA, h.HUMEDAD, h.TEMPERATURA, h.ID_PLANTA, h.TIPO_RIEGO,
                       c.NOMBRE_PLANTA, u.NOMBRE_USUARIO as PROPIETARIO
                FROM HISTORIAL_RIEGO h
                LEFT JOIN CULTIVO c ON h.ID_PLANTA = c.ID_PLANTA
                LEFT JOIN USUARIO u ON c.ID_USUARIO = u.CEDULA
                ORDER BY h.FECHA_HORA DESC";

            var lista = new List<Historial_Riego>();
            try
            {
                using (var conn = CrearConexion())
                using (var cmd = new OracleCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Historial_Riego
                            {
                                Id = Convert.ToInt32(reader["ID_HISTORIAL_RIEGO"]),
                                Fecha = Convert.ToDateTime(reader["FECHA_HORA"]),
                                Humedad = Convert.ToSingle(reader["HUMEDAD"]),
                                Temperatura = Convert.ToSingle(reader["TEMPERATURA"]),
                                IdPlanta = reader["ID_PLANTA"] != DBNull.Value ? Convert.ToInt32(reader["ID_PLANTA"]) : 0,
                                NombrePlanta = reader["NOMBRE_PLANTA"] != DBNull.Value ? reader["NOMBRE_PLANTA"].ToString() : "Desconocida",
                                NombrePropietario = reader["PROPIETARIO"] != DBNull.Value ? reader["PROPIETARIO"].ToString() : "Sin Asignar",
                                TipoRiego = reader["TIPO_RIEGO"] != DBNull.Value ? reader["TIPO_RIEGO"].ToString() : "Manual"
                            });
                        }
                    }
                }
                return new Response<List<Historial_Riego>>(true, "Ok", lista, null);
            }
            catch (Exception ex) { return new Response<List<Historial_Riego>>(false, ex.Message, null, null); }
        }

        public Response<Historial_Riego> BuscarPorId(int id) => new Response<Historial_Riego>(false, "No implementado", null, null);
    }
}