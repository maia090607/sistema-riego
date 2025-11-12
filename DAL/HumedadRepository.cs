using Entity;
using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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
            string query = @"
        INSERT INTO HUMEDAD_PORCENTAJE (PORCENTAJE)
        VALUES (:PORCENTAJE)";

            try
            {
                using (var conn = CrearConexion())
                using (var cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":PORCENTAJE", OracleDbType.Int32).Value = registro.ValorHumedad;

                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();

                    return filas > 0
                        ? new Response<humedad>(true, "Registro de humedad insertado correctamente.", registro, null)
                        : new Response<humedad>(false, "No se insertó el registro de humedad.", null, null);
                }
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
