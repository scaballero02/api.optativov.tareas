using Dapper;
using Repository.Database;
using Repository.Interfaces;
using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class PersonaRepository : IPersonaRepository
    {
        private IDbConnection conexionDB;
        public PersonaRepository(string _connectionString)
        {
            conexionDB = new DbConnection(_connectionString).dbConnection();
        }
        public bool Add(PersonaDTO persona)
        {
            try
            {
                if (conexionDB.Execute("Insert into Persona(nombre, apellido, cedula) values(@nombre, @apellido, @cedula)", persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PersonaDTO Get(string cedula)
        {
            try
            {
                return conexionDB.Query<PersonaDTO>("Select * from Persona where cedula = @cedula", new { cedula }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<PersonaDTO> List()
        {

            try
            {
                return conexionDB.Query<PersonaDTO>("Select * from Persona");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Remove(string cedula)
        {

            try
            {
                if (conexionDB.Execute("Delete from Persona where cedula = @cedula", new { cedula }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(PersonaDTO persona)
        {

            try
            {
                if (conexionDB.Execute("Update persona set nombre = @nombre, apellido = @apellido where cedula = @cedula", persona) > 0)
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
