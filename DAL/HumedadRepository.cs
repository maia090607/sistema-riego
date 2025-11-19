using Entity;
using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HumedadRepository: BaseRepository
    {
        // Insertar registro (no insertar ID ni FECHA_HORA porque FECHA_HORA tiene DEFAULT SYSDATE)
        public Response<humedad> Insertar(humedad registro)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();

                    // ✅ Usar el procedimiento almacenado
                    string query = @"
                BEGIN 
                    PKG_HUMEDAD_PORCENTAJE.SP_INSERTAR_HUMEDAD(
                        :p_porcentaje,
                        :p_resultado,
                        :p_mensaje,
                        :p_id_generado
                    );
                END;";

                    using (var cmd = new OracleCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Parámetro de entrada
                        cmd.Parameters.Add(":p_porcentaje", OracleDbType.Int32).Value = (int)registro.ValorHumedad;

                        // Parámetros de salida
                        var paramResultado = cmd.Parameters.Add(":p_resultado", OracleDbType.Int32);
                        paramResultado.Direction = ParameterDirection.Output;

                        var paramMensaje = cmd.Parameters.Add(":p_mensaje", OracleDbType.Varchar2, 200);
                        paramMensaje.Direction = ParameterDirection.Output;

                        var paramId = cmd.Parameters.Add(":p_id_generado", OracleDbType.Int32);
                        paramId.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        // ✅ Obtener valores de salida
                        int resultado = Convert.ToInt32(paramResultado.Value.ToString());
                        string mensaje = paramMensaje.Value.ToString();

                        if (paramId.Value != DBNull.Value)
                        {
                            registro.IdHumedad = Convert.ToInt32(paramId.Value.ToString());
                        }

                        if (resultado == 1)
                        {
                            return new Response<humedad>(true, mensaje, registro, null);
                        }
                        else
                        {
                            return new Response<humedad>(false, mensaje, null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ [HUMEDAD] Error: {ex}");
                    return new Response<humedad>(false, $"Error general: {ex.Message}", null, null);
                }
            }
        }
        public Response<humedad> MostrarTodo()
        {
            string query = @"SELECT ID_HUMEDAD, PORCENTAJE, FECHA_REGISTRO FROM HUMEDAD_PORCENTAJE";
            var lista = new List<humedad>();

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
                            var registro = new humedad
                            {
                                IdHumedad = reader.GetInt32(0),
                                ValorHumedad = reader.GetInt32(1),
                                FechaRegistro = reader.GetDateTime(2)
                            };
                            lista.Add(registro);
                        }
                    }
                }

                return new Response<humedad>(true, "Registros obtenidos correctamente.", null, lista);
            }
            catch (OracleException ex)
            {
                return new Response<humedad>(false, $"Error Oracle: {ex.Message}", null, null);
            }
            catch (Exception ex)
            {
                return new Response<humedad>(false, $"Error general: {ex.Message}", null, null);
            }
        }


    }
}
