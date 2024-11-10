using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace records_api.Repository
{
	public class DataContext
	{
		private string _connectionString;

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
		{
			return new NpgsqlConnection(_connectionString);
		}
	}
}
