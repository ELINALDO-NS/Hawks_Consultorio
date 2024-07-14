using HC.Core.Domain;
using HC.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Implementation
{
    public class ClienteManager: IClienteManager
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteManager(IClienteRepository repository)
        {
            _clienteRepository = repository;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _clienteRepository.GetClienteAsync(id);
        }
    }
}
