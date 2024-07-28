using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int id);
        Task DeleteClienteAsync(int id);
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
    }
}
