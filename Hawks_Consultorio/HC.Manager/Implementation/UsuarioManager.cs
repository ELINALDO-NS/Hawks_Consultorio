using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Usuario;
using HC.Manager.Interfaces.Managers;
using HC.Manager.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Implementation
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        public UsuarioManager(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UsuarioView>> GetAsync()
        {
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioView>>(await _repository.GetAsync());

        }

        public async Task<UsuarioView> GetAsync(string login)
        {
            return _mapper.Map<UsuarioView>(await _repository.GetAsync(login));
        }

        public async Task<UsuarioView> InsertAsync(Usuario usuario)
        {
          var passwordhasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordhasher.HashPassword(usuario, usuario.Senha);
            await _repository.InsertAsync(usuario);
            return _mapper.Map<UsuarioView>(usuario);

         
        }

        public async Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario)
        {
            var passwordhasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordhasher.HashPassword(usuario, usuario.Senha);
            await _repository.UpdateAsync(usuario);
            return _mapper.Map<UsuarioView>(usuario);
        }

        public async Task<bool> ValidaSenhaAsync(Usuario usuario)
        {
            var usuarioconsultado = await _repository.GetAsync(usuario.Login);
            if (usuarioconsultado == null)
            {
                return false;
            }

            var passwordhasher = new PasswordHasher<Usuario>();
            var status = passwordhasher.VerifyHashedPassword(usuario, usuarioconsultado.Senha, usuario.Senha);
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                   await UpdateUsuarioAsync(usuario);
                    return true;
                default:
                  throw new  InvalidOperationException();
            }
        }
    }
}
