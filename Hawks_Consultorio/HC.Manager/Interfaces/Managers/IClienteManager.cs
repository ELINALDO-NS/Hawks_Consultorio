using HC.Core.Domain;
using HC.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces.Managers
{
    public interface IClienteManager
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int id);
        Task DeleteClienteAsync(int id);
        Task<Cliente> InsertClienteAsync(NovoCliente novocliente);
        Task<Cliente> UpdateClienteAsync(AlteraCliente cliente);
    }
}
