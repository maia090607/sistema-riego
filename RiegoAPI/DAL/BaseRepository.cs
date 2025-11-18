using System;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly string _connectionString;

        public BaseRepository()
        {
            // 🔹 Conexión a tu base de datos Oracle
            _connectionString = "User Id=app_riego;Password=Riego2025;" +
                              "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                              "(CONNECT_DATA=(SID=xe)));";

            TestConnection();
        }

        protected OracleConnection CrearConexion()
        {
            return new OracleConnection(_connectionString);
        }

        private void TestConnection()
        {
            try
            {
                using (var conn = CrearConexion())
                {
                    conn.Open();
                    Console.WriteLine("✅ [API] Conexión a Oracle establecida correctamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [API] Error de conexión Oracle: {ex.Message}");
            }
        }

        public void Dispose() { }
    }
}