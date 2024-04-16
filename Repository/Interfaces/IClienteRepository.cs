
using Repository.Modelos;

namespace Repository.Interfaces
{
    public interface IClienteRepository
    {
        bool Add(ClienteDTO cliente);
        bool Remove(int id);
        bool Update(ClienteDTO cliente);
        ClienteDTO Get(int id);
        IEnumerable<ClienteDTO> List();
    }
}
