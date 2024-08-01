using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Cliente;
using HC.Manager.Interfaces.Managers;
using HC.Manager.Interfaces.Repositories;
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

        public async Task<IEnumerable<ClienteView>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteView>>(clientes);
        }

        public async Task<ClienteView> GetClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteAsync(id);
            return _mapper.Map<Cliente, ClienteView>(cliente);
        }

        public async Task<ClienteView> DeleteClienteAsync(int id)
        {
            var clienteremovido = await _clienteRepository.DeleteClienteAsync(id);
            return _mapper.Map<ClienteView>(clienteremovido);

        }

        public async Task<ClienteView> InsertClienteAsync(NovoCliente  novocliente)
        {
            var cliente = _mapper.Map<Cliente>(novocliente);
            var clienteretornado = await _clienteRepository.InsertClienteAsync(cliente);
            return _mapper.Map<ClienteView>(clienteretornado);
        }

        public async Task<ClienteView> UpdateClienteAsync(AlteraCliente alteracliente)
        {
            var cliente = _mapper.Map<Cliente>(alteracliente);
            var clienteretornado = await _clienteRepository.UpdateClienteAsync(cliente);
            return _mapper.Map<ClienteView>(clienteretornado);
        }
    }
}
