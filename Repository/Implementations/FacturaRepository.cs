using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(FacturaDTO factura)
        {
            try
            {
                await _context.FacturasEF.AddAsync(factura);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la factura", ex);
            }
        }

        public async Task<FacturaDTO> Get(int id)
        {
            try
            {
                return await _context.FacturasEF.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura", ex);
            }
        }

        public async Task<IEnumerable<FacturaDTO>> List()
        {
            try
            {
                return await _context.FacturasEF.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las facturas", ex);
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var factura = await _context.FacturasEF.FindAsync(id);
                if (factura != null)
                {
                    _context.FacturasEF.Remove(factura);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la factura", ex);
            }
        }

        public async Task<bool> Update(FacturaDTO factura)
        {
            try
            {
                _context.FacturasEF.Update(factura);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la factura", ex);
            }
        }
    }
}
