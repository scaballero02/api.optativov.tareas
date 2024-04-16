using Repository.Interfaces;
using Repository.Modelos;


namespace Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public bool add(ClienteDTO cliente)
        {
            try
            {
                if (_clienteRepository.Add(cliente))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool update(ClienteDTO cliente)
        {
            try
            {
                if (_clienteRepository.Update(cliente))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool remove(int id)
        {
            try
            {
                if (_clienteRepository.Remove(id))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ClienteDTO get(int id)
        {
            try
            {
                return _clienteRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<ClienteDTO> list()
        {
            try
            {
                return _clienteRepository.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
