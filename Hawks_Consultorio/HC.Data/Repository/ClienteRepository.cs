using HC.Core.Domain;
using HC.Data.Context;
using HC.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Data.Repository
{
    public class ClienteRepository: IClienteRepository
    {
      private readonly HCContext _context;

        public ClienteRepository(HCContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await  _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
    }
}
