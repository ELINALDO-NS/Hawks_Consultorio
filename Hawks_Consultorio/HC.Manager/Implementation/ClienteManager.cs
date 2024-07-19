using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews;
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
        private readonly IMapper _mapper;



        public ClienteManager(IClienteRepository repository, IMapper mapper)
        {
            _clienteRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _clienteRepository.GetClienteAsync(id);
        }

        public async Task DeleteClienteAsync(int id)
        {
          await _clienteRepository.DeleteClienteAsync(id);
        }

        public async Task<Cliente> InsertClienteAsync(NovoCliente  novocliente)
        {
            var cliente = _mapper.Map<Cliente>(novocliente);
            return await _clienteRepository.InsertClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateClienteAsync(AlteraCliente alteracliente)
        {
            var cliente = _mapper.Map<Cliente>(alteracliente);
           return await _clienteRepository.UpdateClienteAsync(cliente);
        }
    }
}
