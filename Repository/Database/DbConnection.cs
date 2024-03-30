using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class DbConnection
    {
        private string connectionString;

        public DbConnection(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        public IDbConnection dbConnection()
        {

            try
            {
                IDbConnection conexion = new NpgsqlConnection(connectionString);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.Message);
            }
        }
    }
}
