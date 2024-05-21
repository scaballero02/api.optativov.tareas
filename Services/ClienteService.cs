using Repository.Interfaces;
using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Add(ClienteDTO cliente)
        {
            try
            {
                return await _clienteRepository.Add(cliente);
            }
            catch (Exception ex)
            {
                // Puedes agregar manejo de excepciones específico o registrar el error aquí
                throw new Exception("Error al agregar el cliente", ex);
            }
        }

        public async Task<bool> Update(ClienteDTO cliente)
        {
            try
            {
                return await _clienteRepository.Update(cliente);
            }
            catch (Exception ex)
            {
                // Puedes agregar manejo de excepciones específico o registrar el error aquí
                throw new Exception("Error al actualizar el cliente", ex);
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                return await _clienteRepository.Remove(id);
            }
            catch (Exception ex)
            {
                // Puedes agregar manejo de excepciones específico o registrar el error aquí
                throw new Exception("Error al eliminar el cliente", ex);
            }
        }

        public async Task<ClienteDTO> Get(int id)
        {
            try
            {
                return await _clienteRepository.Get(id);
            }
            catch (Exception ex)
            {
                // Puedes agregar manejo de excepciones específico o registrar el error aquí
                throw new Exception("Error al obtener el cliente", ex);
            }
        }

        public async Task<IEnumerable<ClienteDTO>> List()
        {
            try
            {
                return await _clienteRepository.List();
            }
            catch (Exception ex)
            {
                // Puedes agregar manejo de excepciones específico o registrar el error aquí
                throw new Exception("Error al listar los clientes", ex);
            }
        }
    }
}
