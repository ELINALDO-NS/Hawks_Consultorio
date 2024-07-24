using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces.Repositories
{
    public interface IEspecialidadeRepository
    {
        Task<bool> ExisteNaBaseAsync(int id);
    }
}
