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
    public class EspecialidadeRepository:IEspecialidadeRepository
    {
        private readonly HCContext _context;

        public EspecialidadeRepository(HCContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteNaBaseAsync(int id)
        {
            
            return await _context.Especialidades.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id) != null;
        }
    }
}
