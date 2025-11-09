using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Entity; // Ajusta namespace según tu proyecto

namespace DAL
{
    public class RepositorioClima : BaseRepository
    {
        // Insertar registro (no insertar ID ni FECHA_HORA porque FECHA_HORA tiene DEFAULT SYSDATE)
        public Response<RegistroClimatico> Insertar(RegistroClimatico registro)
        {
            string query = @"
                INSERT INTO REGISTRO_CLIMATICO 
                    (HUMEDAD_SUELO, HUMEDAD_AMBIENTE, TEMPERATURA_AMB, VIENTO)
                VALUES (:HUMEDAD_SUELO, :HUMEDAD_AMBIENTE, :TEMPERATURA_AMB, :VIENTO)";

            try
            {
                using (var conn = CrearConexion())
                using (var cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":HUMEDAD_SUELO", OracleDbType.Double).Value = registro.Humedad_Suelo;
                    cmd.Parameters.Add(":HUMEDAD_AMBIENTE", OracleDbType.Double).Value = registro.Humedad_Ambiente;
                    cmd.Parameters.Add(":TEMPERATURA_AMB", OracleDbType.Double).Value = registro.Temperatura_Ambiente;
                    cmd.Parameters.Add(":VIENTO", OracleDbType.Double).Value = registro.Viento;

                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();

                    return filas > 0
                        ? new Response<RegistroClimatico>(true, "Registro climático insertado correctamente.", registro, null)
                        : new Response<RegistroClimatico>(false, "No se insertó el registro.", null, null);
                }
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
