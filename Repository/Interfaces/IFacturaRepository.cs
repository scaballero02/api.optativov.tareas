using Repository.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFacturaRepository
    {
        Task<bool> Add(FacturaDTO factura);
        Task<FacturaDTO> Get(int id);
        Task<IEnumerable<FacturaDTO>> List();
        Task<bool> Remove(int id);
        Task<bool> Update(FacturaDTO factura);
    }
}
