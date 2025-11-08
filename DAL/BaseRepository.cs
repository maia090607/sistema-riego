using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client; // Asegúrate de tener este paquete NuGet instalado

namespace DAL
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly string _connectionString;

        public BaseRepository()
        {
            // Connection string para Oracle
            _connectionString = "User Id=riego_user02;Password=riego123;Data Source=localhost:1521/xepdb1;";
        }

        // Método helper para crear conexiones Oracle
        protected OracleConnection CrearConexion()
        {
            return new OracleConnection(_connectionString);
        }

        // Implementación de IDisposable
        public void Dispose()
        {
            // Liberar recursos si es necesario
        }
    }
}