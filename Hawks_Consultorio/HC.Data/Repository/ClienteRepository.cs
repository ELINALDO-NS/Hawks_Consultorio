using HC.Core.Domain;
using HC.Data.Context;
using HC.Manager.Interfaces.Repositories;
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
            return await _context.Clientes.Include(e => e.Endereco).
                Include(t => t.Telefones).
                AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _context.Clientes.Include(x => x.Endereco).
                 Include(t => t.Telefones).
                AsNoTracking().
                SingleOrDefaultAsync(x => x.Id==id);
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsulltado = _context.Clientes.Find(cliente.Id);
            if (clienteConsulltado == null)
            {
                return null;
            }


            _context.Entry(clienteConsulltado).CurrentValues.SetValues(cliente);
            _context.Update(clienteConsulltado);
             await _context.SaveChangesAsync();
            return clienteConsulltado;
        }

        public async Task DeleteClienteAsync(int id)
        {
            var clienteConsulltado = _context.Clientes.Find(id);
            if (clienteConsulltado != null)
            {
                _context.Remove(clienteConsulltado);
                await _context.SaveChangesAsync();
            }

        }
    }
}
