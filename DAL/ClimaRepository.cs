using Entity; // Ajusta namespace según tu proyecto
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class RepositorioClima : BaseRepository
    {
        public Response<RegistroClimatico> Insertar(RegistroClimatico registro)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();

                    // ✅ Usar el procedimiento almacenado
                    string query = @"
                BEGIN 
                    PKG_REGISTRO_CLIMATICO.SP_INSERTAR_REGISTRO(
                        :p_humedad_suelo,
                        :p_humedad_ambiente,
                        :p_temperatura_amb,
                        :p_viento,
                        :p_id_generado,
                        :p_estado,
                        :p_mensaje
                    );
                END;";

                    using (var cmd = new OracleCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Parámetros de entrada
                        cmd.Parameters.Add(":p_humedad_suelo", OracleDbType.Double).Value = registro.Humedad_Suelo;
                        cmd.Parameters.Add(":p_humedad_ambiente", OracleDbType.Double).Value = registro.Humedad_Ambiente;
                        cmd.Parameters.Add(":p_temperatura_amb", OracleDbType.Double).Value = registro.Temperatura_Ambiente;
                        cmd.Parameters.Add(":p_viento", OracleDbType.Double).Value = registro.Viento;

                        // Parámetros de salida
                        var paramId = cmd.Parameters.Add(":p_id_generado", OracleDbType.Int32);
                        paramId.Direction = ParameterDirection.Output;

                        var paramEstado = cmd.Parameters.Add(":p_estado", OracleDbType.Int32);
                        paramEstado.Direction = ParameterDirection.Output;

                        var paramMensaje = cmd.Parameters.Add(":p_mensaje", OracleDbType.Varchar2, 200);
                        paramMensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        // ✅ Obtener valores de salida
                        registro.IdRegistro = Convert.ToInt32(paramId.Value.ToString());
                        int estado = Convert.ToInt32(paramEstado.Value.ToString());
                        string mensaje = paramMensaje.Value.ToString();

                        if (estado == 1)
                        {
                            return new Response<RegistroClimatico>(true, mensaje, registro, null);
                        }
                        else
                        {
                            return new Response<RegistroClimatico>(false, mensaje, null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ [CLIMA] Error: {ex}");
                    return new Response<RegistroClimatico>(false, $"Error general: {ex.Message}", null, null);
                }
            }
        }


        public Response<RegistroClimatico> MostrarTodos()
        {
            string query = @"
                SELECT ID_REGISTRO, FECHA_HORA, HUMEDAD_SUELO, HUMEDAD_AMBIENTE, TEMPERATURA_AMB, VIENTO
                FROM REGISTRO_CLIMATICO
                ORDER BY FECHA_HORA DESC";

            var lista = new List<RegistroClimatico>();

            try
            {
                using (var conn = CrearConexion())
                using (var cmd = new OracleCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(Mapear(reader));
                    }
                }

                return new Response<RegistroClimatico>(true, $"Se encontraron {lista.Count} registros.", null, lista);
            }
            catch (OracleException ex)
            {
                return new Response<RegistroClimatico>(false, $"Error Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<RegistroClimatico>(false, $"Error general: {ex.Message}", null, null);
            }
        }

        private RegistroClimatico Mapear(OracleDataReader reader)
        {
            return new RegistroClimatico
            {
                IdRegistro = reader["ID_REGISTRO"] != DBNull.Value ? Convert.ToInt32(reader["ID_REGISTRO"]) : 0,
                Fecha = reader["FECHA_HORA"] != DBNull.Value ? Convert.ToDateTime(reader["FECHA_HORA"]) : DateTime.MinValue,
                Humedad_Suelo = reader["HUMEDAD_SUELO"] != DBNull.Value ? Convert.ToSingle(reader["HUMEDAD_SUELO"]) : 0f,
                Humedad_Ambiente = reader["HUMEDAD_AMBIENTE"] != DBNull.Value ? Convert.ToSingle(reader["HUMEDAD_AMBIENTE"]) : 0f,
                Temperatura_Ambiente = reader["TEMPERATURA_AMB"] != DBNull.Value ? Convert.ToSingle(reader["TEMPERATURA_AMB"]) : 0f,
                Viento = reader["VIENTO"] != DBNull.Value ? Convert.ToSingle(reader["VIENTO"]) : 0f
            };
        }
    }
}
