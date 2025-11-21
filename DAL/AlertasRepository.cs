using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class AlertasRepository : BaseRepository
    {
        // ================================================================
        // MÉTODO AGREGAR (USANDO STORED PROCEDURE)
        // ================================================================
        public Response<Alertas> Agregar(Alertas entidad)
        {
            Response<Alertas> response = new Response<Alertas>();

            using (var connection = CrearConexion())
            {
                try
                {
                    connection.Open();
                    string query = @"
                    BEGIN 
                        PKG_HISTORIAL_ALERTAS.SP_INSERTAR_ALERTA(
                            :p_fecha_hora,
                            :p_tipo_alerta,
                            :p_descripcion,
                            :p_nivel_critico,
                            :p_estado,
                            :p_id_generado,
                            :p_resultado,
                            :p_mensaje
                        );
                    END;";

                    using (var cmd = new OracleCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Parámetros de entrada
                        cmd.Parameters.Add(":p_fecha_hora", OracleDbType.Date).Value = entidad.FechaHora;
                        cmd.Parameters.Add(":p_tipo_alerta", OracleDbType.Varchar2).Value = entidad.TipoAlerta;
                        cmd.Parameters.Add(":p_descripcion", OracleDbType.Varchar2).Value = entidad.Descripcion ?? "";
                        cmd.Parameters.Add(":p_nivel_critico", OracleDbType.Varchar2).Value = entidad.NivelCritico ?? "Bajo";
                        cmd.Parameters.Add(":p_estado", OracleDbType.Int32).Value = entidad.Estado ? 1 : 0;

                        // Parámetros de Salida
                        var paramId = cmd.Parameters.Add(":p_id_generado", OracleDbType.Int32);
                        paramId.Direction = ParameterDirection.Output;

                        var paramResultado = cmd.Parameters.Add(":p_resultado", OracleDbType.Int32);
                        paramResultado.Direction = ParameterDirection.Output;

                        var paramMensaje = cmd.Parameters.Add(":p_mensaje", OracleDbType.Varchar2, 200);
                        paramMensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        // Leer resultados
                        // Validar si los valores de salida no son nulos
                        int resultado = paramResultado.Value != DBNull.Value ? Convert.ToInt32(paramResultado.Value.ToString()) : 0;
                        string mensaje = paramMensaje.Value != DBNull.Value ? paramMensaje.Value.ToString() : "Error desconocido";

                        if (resultado == 1)
                        {
                            if (paramId.Value != DBNull.Value)
                            {
                                entidad.IdAlerta = Convert.ToInt32(paramId.Value.ToString());
                            }
                            return new Response<Alertas>(true, mensaje, entidad, null);
                        }
                        else
                        {
                            return new Response<Alertas>(false, mensaje, null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new Response<Alertas>(false, "Error DAL: " + ex.Message, null, null);
                }
            }
        }

        // ================================================================
        // MÉTODO MOSTRAR TODOS
        // ================================================================
        public Response<Alertas> MostrarTodos()
        {
            try
            {
                List<Alertas> lista = new List<Alertas>();
                string query = "SELECT * FROM Historial_Alertas ORDER BY fecha_hora DESC";

                using (var connection = CrearConexion())
                using (var cmd = new OracleCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(Mapear(reader));
                        }
                    }
                }
                return new Response<Alertas>(true, $"Se encontraron {lista.Count} alertas.", null, lista);
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, "Error al listar: " + ex.Message, null, null);
            }
        }

        // ================================================================
        // MÉTODO ACTUALIZAR
        // ================================================================
        public Response<Alertas> Actualizar(Alertas entidad)
        {
            try
            {
                using (var connection = CrearConexion())
                {
                    connection.Open();
                    string query = @"UPDATE Historial_Alertas 
                                     SET fecha_hora = :fecha, 
                                         tipo_alerta = :tipo, 
                                         descripcion = :descrip, 
                                         nivel_critico = :nivel, 
                                         estado = :est 
                                     WHERE id_alerta = :id";

                    using (var cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(":fecha", OracleDbType.Date).Value = entidad.FechaHora;
                        cmd.Parameters.Add(":tipo", OracleDbType.Varchar2).Value = entidad.TipoAlerta;
                        cmd.Parameters.Add(":descrip", OracleDbType.Varchar2).Value = entidad.Descripcion ?? "";
                        cmd.Parameters.Add(":nivel", OracleDbType.Varchar2).Value = entidad.NivelCritico ?? "Bajo";
                        cmd.Parameters.Add(":est", OracleDbType.Int32).Value = entidad.Estado ? 1 : 0;
                        cmd.Parameters.Add(":id", OracleDbType.Int32).Value = entidad.IdAlerta;

                        int filas = cmd.ExecuteNonQuery();
                        return new Response<Alertas>(filas > 0, filas > 0 ? "Actualizado" : "No encontrado", entidad, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, "Error al actualizar: " + ex.Message, null, null);
            }
        }

        // ================================================================
        // MÉTODO ELIMINAR
        // ================================================================
        public Response<Alertas> Eliminar(int id)
        {
            try
            {
                using (var connection = CrearConexion())
                {
                    connection.Open();
                    string query = "DELETE FROM Historial_Alertas WHERE id_alerta = :id";
                    using (var cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(":id", OracleDbType.Int32).Value = id;
                        int filas = cmd.ExecuteNonQuery();
                        return new Response<Alertas>(filas > 0, filas > 0 ? "Eliminado" : "No encontrado", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, "Error al eliminar: " + ex.Message, null, null);
            }
        }

        // ================================================================
        // MÉTODO OBTENER POR ID
        // ================================================================
        public Response<Alertas> ObtenerPorId(int id)
        {
            try
            {
                using (var connection = CrearConexion())
                {
                    connection.Open();
                    string query = "SELECT * FROM Historial_Alertas WHERE id_alerta = :id";
                    using (var cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(":id", OracleDbType.Int32).Value = id;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Response<Alertas>(true, "Encontrado", Mapear(reader), null);
                            }
                            return new Response<Alertas>(false, "No encontrado", null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, "Error al buscar: " + ex.Message, null, null);
            }
        }

        // ================================================================
        // MÉTODO AUXILIAR DE MAPEO
        // ================================================================
        private Alertas Mapear(OracleDataReader reader)
        {
            return new Alertas
            {
                IdAlerta = Convert.ToInt32(reader["ID_ALERTA"]),
                FechaHora = Convert.ToDateTime(reader["FECHA_HORA"]),
                TipoAlerta = reader["TIPO_ALERTA"].ToString(),
                Descripcion = reader["DESCRIPCION"] != DBNull.Value ? reader["DESCRIPCION"].ToString() : "",
                NivelCritico = reader["NIVEL_CRITICO"] != DBNull.Value ? reader["NIVEL_CRITICO"].ToString() : "",
                Estado = Convert.ToInt32(reader["ESTADO"]) == 1
            };
        }
    }
}