using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAsync();
        Task<Usuario> GetAsync(string login);
        Task<Usuario> InsertAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
    }
}
