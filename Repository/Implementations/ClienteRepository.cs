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
        private readonly string EstadoActivo = "Activo";
        private readonly string EstadoInactivo = "Inactivo";

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ClienteDTO cliente)
        {
            try
            {
                var existeCliente = await _context.ClientesEF.AsNoTracking()
                                                             .Where(e => e.Documento.Equals(cliente.Documento) && e.Estado.Equals(EstadoActivo))
                                                             .AnyAsync();

                if (!existeCliente)
                {
                    cliente.Estado = EstadoActivo;
                    await _context.ClientesEF.AddAsync(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteDTO> Get(int id)
        {
            try
            {
                return await _context.ClientesEF.FirstOrDefaultAsync(c => c.Id == id && c.Estado == EstadoActivo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClienteDTO>> List()
        {
            try
            {
                return await _context.ClientesEF
                    .Where(c => c.Estado.Equals(EstadoActivo))
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var cliente = await _context.ClientesEF.FindAsync(id);
                if (cliente is not null)
                {
                    cliente.Estado = EstadoInactivo;
                    _context.ClientesEF.Update(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(ClienteDTO cliente)
        {
            try
            {
                var existeDocumento = await _context.ClientesEF.AsNoTracking()
                                                    .Where(e => e.Documento.Equals(cliente.Documento) && e.Estado.Equals(EstadoActivo))
                                                    .AnyAsync();

                var existeCliente = await _context.ClientesEF.AsNoTracking()
                                                            .Where(e => e.Id.Equals(cliente.Id) && e.Estado.Equals(EstadoActivo))
                                                            .AnyAsync();
                if (!existeDocumento && existeCliente)
                {
                    _context.ClientesEF.Update(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
