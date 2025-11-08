using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class AlertasRepository : BaseRepository
    {

        // ✅ Insertar nueva alerta
        public Response<Alertas> Agregar(Alertas entidad)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO HISTORIAL_ALERTAS
                    (ID_ALERTA, FECHA_HORA, TIPO_ALERTA, DESCRIPCION, NIVEL_CRITICO, ESTADO)
                    VALUES (:Id, :FechaHora, :TipoAlerta, :Descripcion, :NivelCritico, :Estado)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":Id", OracleDbType.Int32).Value = entidad.IdAlerta;
                    cmd.Parameters.Add(":FechaHora", OracleDbType.Date).Value = entidad.FechaHora;
                    cmd.Parameters.Add(":TipoAlerta", OracleDbType.Varchar2).Value = entidad.TipoAlerta;
                    cmd.Parameters.Add(":Descripcion", OracleDbType.Varchar2).Value = entidad.Descripcion ?? (object)DBNull.Value;
                    cmd.Parameters.Add(":NivelCritico", OracleDbType.Varchar2).Value = entidad.NivelCritico ?? (object)DBNull.Value;
                    cmd.Parameters.Add(":Estado", OracleDbType.Int32).Value = entidad.Estado ? 1 : 0;

                    try
                    {
                        connection.Open();
                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0
                            ? new Response<Alertas>(true, "Alerta registrada correctamente.", entidad, null)
                            : new Response<Alertas>(false, "No se insertó ningún registro.", null, null);
                    }
                    catch (Exception ex)
                    {
                        return new Response<Alertas>(false, "Error al guardar alerta: " + ex.Message, null, null);
                    }
                }
            }
        }
        public Response<Alertas> Actualizar(Alertas entidad)
        {
            string query = @"
                UPDATE HISTORIAL_ALERTAS
                SET FECHA_HORA = :FechaHora,
                    TIPO_ALERTA = :TipoAlerta,
                    DESCRIPCION = :Descripcion,
                    NIVEL_CRITICO = :NivelCritico,
                    ESTADO = :Estado
                WHERE ID_ALERTA = :Id";

            try
            {
                using (var conexion = CrearConexion())
                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(":FechaHora", OracleDbType.Date).Value = entidad.FechaHora;
                    comando.Parameters.Add(":TipoAlerta", OracleDbType.Varchar2).Value = entidad.TipoAlerta;
                    comando.Parameters.Add(":Descripcion", OracleDbType.Varchar2).Value = entidad.Descripcion ?? (object)DBNull.Value;
                    comando.Parameters.Add(":NivelCritico", OracleDbType.Varchar2).Value = entidad.NivelCritico ?? (object)DBNull.Value;
                    comando.Parameters.Add(":Estado", OracleDbType.Int32).Value = entidad.Estado ? 1 : 0;
                    comando.Parameters.Add(":Id", OracleDbType.Int32).Value = entidad.IdAlerta;

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return new Response<Alertas>(true, "Alerta actualizada correctamente.", entidad, null);
                    }
                    else
                    {
                        return new Response<Alertas>(false, "No se encontró ninguna alerta con el ID especificado.", null, null);
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Alertas>(false, $"Error en Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, $"Error general: {ex.Message}", null, null);
            }
        }

        // ✅ Eliminar alerta
        public Response<Alertas> Eliminar(int id)
        {
            string query = "DELETE FROM HISTORIAL_ALERTAS WHERE ID_ALERTA = :id";

            try
            {
                using (var conexion = CrearConexion())
                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(new OracleParameter(":id", id));
                    conexion.Open();

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0
                        ? new Response<Alertas>(true, "Alerta eliminada correctamente.", null, null)
                        : new Response<Alertas>(false, "No se encontró ninguna alerta con el ID especificado.", null, null);
                }
            }
            catch (OracleException ex)
            {
                return new Response<Alertas>(false, $"Error en Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, $"Error general: {ex.Message}", null, null);
            }
        }

        // ✅ Obtener por ID (usando Mapear)
        public Response<Alertas> ObtenerPorId(int id)
        {
            string query = @"
                SELECT ID_ALERTA, FECHA_HORA, TIPO_ALERTA, DESCRIPCION, NIVEL_CRITICO, ESTADO 
                FROM HISTORIAL_ALERTAS 
                WHERE ID_ALERTA = :id";

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
                            return new Response<Alertas>(true, "Alerta encontrada correctamente.", Mapear(reader), null);
                        else
                            return new Response<Alertas>(false, "No se encontró la alerta con el ID especificado.", null, null);
                    }
                }
            }
            catch (OracleException ex)
            {
                return new Response<Alertas>(false, $"Error Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, $"Error general: {ex.Message}", null, null);
            }
        }

        // ✅ Mostrar todas (usando Mapear)
        public Response<Alertas> MostrarTodos()
        {
            try
            {
                List<Alertas> lista = new List<Alertas>();
                string query = @"
            SELECT ID_ALERTA, FECHA_HORA, TIPO_ALERTA, DESCRIPCION, NIVEL_CRITICO, ESTADO
            FROM HISTORIAL_ALERTAS
            ORDER BY FECHA_HORA DESC";

                using (var conexion = CrearConexion())
                using (var cmd = new OracleCommand(query, conexion))
                {
                    conexion.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(Mapear(reader));
                    }

                    string mensaje = lista.Count > 0
                        ? $"✅ Se encontraron {lista.Count} alertas registradas."
                        : "⚠️ No hay alertas registradas.";

                    return new Response<Alertas>(true, mensaje, null, lista);
                }
            }
            catch (OracleException ex)
            {
                return new Response<Alertas>(false, $"Error de base de datos:\n{ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<Alertas>(false, $"Error al obtener alertas:\n{ex.Message}", null, null);
            }
        }

        private Alertas Mapear(OracleDataReader reader)
        {
            return new Alertas
            {
                IdAlerta = reader["ID_ALERTA"] != DBNull.Value ? Convert.ToInt32(reader["ID_ALERTA"]) : 0,
                FechaHora = reader["FECHA_HORA"] != DBNull.Value ? Convert.ToDateTime(reader["FECHA_HORA"]) : DateTime.MinValue,
                TipoAlerta = reader["TIPO_ALERTA"]?.ToString(),
                Descripcion = reader["DESCRIPCION"]?.ToString(),
                NivelCritico = reader["NIVEL_CRITICO"]?.ToString(),
                Estado = reader["ESTADO"] != DBNull.Value ? Convert.ToInt32(reader["ESTADO"]) == 1 : false
            };
        }

    }
}
