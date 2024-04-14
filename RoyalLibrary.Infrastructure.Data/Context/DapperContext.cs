using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RoyalLibrary.Domain.Repositories.Interface;

namespace RoyalLibrary.Infrastructure.Data.Context
{
    public class DapperContext : IContext
    {
        private readonly string _connectionString;
        private DbConnection _connection;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(_connectionString);

                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}