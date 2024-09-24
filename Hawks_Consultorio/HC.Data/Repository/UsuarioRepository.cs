using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Usuario;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HCContext context;
        public UsuarioRepository(HCContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAsync()
        {
            return await context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetAsync(string login)
        {
            return await context.Usuarios.
                Include(u => u.Funcoes).
                AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login);
        }
        public async Task<Usuario> InsertAsync(Usuario usuario)
        {
            await InsertUsuarioFuncaAsync(usuario);
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        private async Task InsertUsuarioFuncaAsync(Usuario usuario)
        {
          var funcoesconsultadas = new List<Funcao>();
            foreach (var funcao in usuario.Funcoes)
            {
                var func = await context.Funcoes.FindAsync(funcao.Id);
                funcoesconsultadas.Add(func);
            }
            usuario.Funcoes = funcoesconsultadas;
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            var usuarioConsultado = await context.Usuarios.FindAsync(usuario.Login);
            if (usuarioConsultado == null)
            {
                return null;
            }
            context.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
            await context.SaveChangesAsync();
            return usuarioConsultado;
        }
    }
}
