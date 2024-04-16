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
    public class FacturaRepository : IFacturaRepository
    {
        private IDbConnection conexionDB;
        public FacturaRepository(string _connectionString)
        {
            conexionDB = new DbConnection(_connectionString).dbConnection();
        }
        public bool Add(FacturaDTO factura)
        {
            try
            {
                if (conexionDB.Execute("INSERT INTO Factura (Id_cliente, Nro_Factura, Fecha_Hora, Total, Total_iva5, Total_iva10, Total_iva, Total_letras, Sucursal) VALUES (@IdCliente, @NroFactura, @FechaHora, @Total, @TotalIvaCinco, @TotalIvaDiez, @TotalIva, @TotalLetras, @Sucursal)", factura) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FacturaDTO Get(int id)
        {
            try
            {
                return conexionDB.Query<FacturaDTO>("Select id, id_cliente as IdCliente, nro_factura as NroFactura, fecha_hora as FechaHora, total, total_iva5 as TotalIvaCinco, total_iva10 as TotalIvaDiez, total_iva as TotalIva, total_letras as TotalLetras, sucursal from Factura where id = @id", new { id }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<FacturaDTO> List()
        {

            try
            {
                return conexionDB.Query<FacturaDTO>("Select id, id_cliente as IdCliente, nro_factura as NroFactura, fecha_hora as FechaHora, total, total_iva5 as TotalIvaCinco, total_iva10 as TotalIvaDiez, total_iva as TotalIva, total_letras as TotalLetras, sucursal from Factura");
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
                if (conexionDB.Execute("Delete from Factura where id = @id", new { id }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(FacturaDTO factura)
        {

            try
            {
                if (conexionDB.Execute("UPDATE Factura SET Id_cliente = @IdCliente, Nro_Factura = @NroFactura, Fecha_Hora = @FechaHora, Total = @Total, Total_iva5 = @TotalIvaCinco, Total_iva10 = @TotalIvaDiez, Total_iva = @TotalIva, Total_Letras = @TotalLetras, Sucursal = @Sucursal WHERE Id = @Id", factura) > 0)
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
