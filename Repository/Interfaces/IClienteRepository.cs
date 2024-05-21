
using Repository.Modelos;

namespace Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<bool> Add(ClienteDTO cliente);
        Task<bool> Remove(int id);
        Task<bool> Update(ClienteDTO cliente);
        Task<ClienteDTO> Get(int id);
        Task<IEnumerable<ClienteDTO>> List();
    }
}
