using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Usuario;
using HC.Manager.Interfaces;
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
        private readonly IJWTService _jWT;

        public UsuarioManager(IUsuarioRepository repository, IMapper mapper,IJWTService jWT)
        {
            _repository = repository;
            _mapper = mapper;
            _jWT = jWT;
        }
        public async Task<IEnumerable<UsuarioView>> GetAsync()
        {
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioView>>(await _repository.GetAsync());

        }

        public async Task<UsuarioView> GetAsync(string login)
        {
            return _mapper.Map<UsuarioView>(await _repository.GetAsync(login));
        }

        public async Task<UsuarioView> InsertAsync(NovoUsuario novousuario)
        {
            var usuario = _mapper.Map<Usuario>(novousuario);
            ConverteSenhaEmHash(usuario);
            return _mapper.Map<UsuarioView>(await _repository.InsertAsync(usuario));


        }

        private void ConverteSenhaEmHash(Usuario usuario)
        {
            var passwordhasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordhasher.HashPassword(usuario, usuario.Senha);
        }

        public async Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario)
        {
            var passwordhasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordhasher.HashPassword(usuario, usuario.Senha);
            await _repository.UpdateAsync(usuario);
            return _mapper.Map<UsuarioView>(usuario);
        }

        public async Task<UsuarioLogado> ValidaUsuarioGeraTokemAsync(Usuario usuario)
        {
            var usuarioconsultado = await _repository.GetAsync(usuario.Login);
            if (usuarioconsultado == null)
            {
                return null;
            }
            if (await ValidaEAtualizaHashAsync(usuario,usuarioconsultado.Senha))
            {
                var usuariologado = _mapper.Map<UsuarioLogado>(usuarioconsultado);
               usuariologado.Tokem = _jWT.GerarTokem(usuarioconsultado);
                return usuariologado;
            }
            return null;
        }
        private async Task<bool> ValidaEAtualizaHashAsync(Usuario usuario,string hash)
        {
            var passwordhasher = new PasswordHasher<Usuario>();
            var status = passwordhasher.VerifyHashedPassword(usuario, hash, usuario.Senha);
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
                    throw new InvalidOperationException();
            }
        }
    }
}
