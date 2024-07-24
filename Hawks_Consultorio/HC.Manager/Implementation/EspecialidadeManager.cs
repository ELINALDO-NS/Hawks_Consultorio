using HC.Manager.Interfaces.Managers;
using HC.Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Implementation
{
    public class EspecialidadeManager : IEspecialidadeManager
    {
        private readonly IEspecialidadeRepository _repository;

        public EspecialidadeManager(IEspecialidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExisteNaBaseAsync(int id)
        {
          return await _repository.ExisteNaBaseAsync(id) ;
        }
    }
}
