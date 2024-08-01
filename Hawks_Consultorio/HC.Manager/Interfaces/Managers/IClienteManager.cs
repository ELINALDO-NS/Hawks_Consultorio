using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces.Managers
{
    public interface IClienteManager
    {
        Task<IEnumerable<ClienteView>> GetClientesAsync();
        Task<ClienteView> GetClienteAsync(int id);
        Task<ClienteView> DeleteClienteAsync(int id);
        Task<ClienteView> InsertClienteAsync(NovoCliente novocliente);
        Task<ClienteView> UpdateClienteAsync(AlteraCliente cliente);
    }
}
