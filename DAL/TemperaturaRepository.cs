using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace DAL
{
    public class TemperaturaRepository : BaseRepository
    {
        public Response<Temperatura> Insertar(Temperatura entidad)
        {
            using (var conn = CrearConexion())
            {
                try
                {
                    conn.Open();
                    string query = @"
                    BEGIN 
                        PKG_TEMPERATURA.SP_INSERTAR_TEMPERATURA(
                            :p_temp_ambiente,
                            :p_temp_suelo,
                            :p_observacion,
                            :p_id_planta,   -- ✅ Nuevo parámetro
                            :p_id_generado,
                            :p_estado,
                            :p_mensaje
                        );
                    END;";

                    using (var cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":p_temp_ambiente", OracleDbType.Single).Value = entidad.TempAmbiente;
                        cmd.Parameters.Add(":p_temp_suelo", OracleDbType.Single).Value = entidad.TempSuelo;
                        cmd.Parameters.Add(":p_observacion", OracleDbType.Varchar2).Value = entidad.Observacion ?? "";

                        // ✅ Enviar ID Planta (o DBNull si es 0)
                        if (entidad.IdPlanta > 0)
                            cmd.Parameters.Add(":p_id_planta", OracleDbType.Int32).Value = entidad.IdPlanta;
                        else
                            cmd.Parameters.Add(":p_id_planta", OracleDbType.Int32).Value = DBNull.Value;

                        // Salidas
                        var paramId = cmd.Parameters.Add(":p_id_generado", OracleDbType.Int32);
                        paramId.Direction = ParameterDirection.Output;

                        var paramEstado = cmd.Parameters.Add(":p_estado", OracleDbType.Int32);
                        paramEstado.Direction = ParameterDirection.Output;

                        var paramMensaje = cmd.Parameters.Add(":p_mensaje", OracleDbType.Varchar2, 200);
                        paramMensaje.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        entidad.IdTemperatura = Convert.ToInt32(paramId.Value.ToString());
                        string mensaje = paramMensaje.Value.ToString();
                        bool exito = Convert.ToInt32(paramEstado.Value.ToString()) == 1;

                        return new Response<Temperatura>(exito, mensaje, entidad, null);
                    }
                }
                catch (Exception ex)
                {
                    return new Response<Temperatura>(false, "Error DAL: " + ex.Message, null, null);
                }
            }
        }
    }
}