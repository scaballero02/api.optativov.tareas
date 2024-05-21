using Repository.Database;
using Repository.Interfaces;
using Repository.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ClienteDTO cliente)
        {
            try
            {
                await _context.ClientesEF.AddAsync(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteDTO> Get(int id)
        {
            try
            {
                return await _context.ClientesEF.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ClienteDTO>> List()
        {
            try
            {
                return await _context.ClientesEF.Where(c => c.Estado != "inactivo").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var cliente = await _context.ClientesEF.FindAsync(id);
                if (cliente != null)
                {
                    cliente.Estado = "inactivo";
                    _context.ClientesEF.Update(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(ClienteDTO cliente)
        {
            try
            {
                _context.ClientesEF.Update(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
