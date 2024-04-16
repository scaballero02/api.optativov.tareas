using Dapper;
using Repository.Database;
using Repository.Interfaces;
using Repository.Modelos;
using System.Data;

namespace Repository.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private IDbConnection conexionDB;
        public ClienteRepository(string _connectionString)
        {
            conexionDB = new DbConnection(_connectionString).dbConnection();
        }
        public bool Add(ClienteDTO cliente)
        {
            try
            {
                if (conexionDB.Execute("INSERT INTO cliente (Id_banco, Nombre, Apellido, Documento, Direccion, mail, Celular, Estado) VALUES (@IdBanco, @Nombre, @Apellido, @Documento, @Direccion, @Email, @Celular, @Estado)", cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ClienteDTO Get(int id)
        {
            try
            {
                return conexionDB.Query<ClienteDTO>("Select * from Cliente where id = @id", new { id }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<ClienteDTO> List()
        {

            try
            {
                return conexionDB.Query<ClienteDTO>("Select * from Cliente where Estado != 'inactivo'");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Remove(int id)
        {

            try
            {
                if (conexionDB.Execute("UPDATE Cliente SET Estado = 'inactivo' WHERE Id = @Id", new { id }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(ClienteDTO cliente)
        {

            try
            {
                if (conexionDB.Execute("UPDATE Cliente SET Id_banco = @IdBanco, Nombre = @Nombre, Apellido = @Apellido, Documento = @Documento, Direccion = @Direccion, Mail = @Email, Celular = @Celular, Estado = @Estado WHERE Id = @Id", cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
