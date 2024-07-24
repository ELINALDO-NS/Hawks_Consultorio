using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces.Managers
{
    public interface IEspecialidadeManager
    {
        Task<bool> ExisteNaBaseAsync(int id);
    }
}
