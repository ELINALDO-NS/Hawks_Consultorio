﻿using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces.Managers
{
    public interface IUsuarioManager
    {
        Task<IEnumerable<UsuarioView>> GetAsync();
        Task<UsuarioView> GetAsync(string login);
        Task<UsuarioView> InsertAsync(Usuario usuario);
        Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario);
        Task<bool> ValidaSenhaAsync(Usuario usuario);
    }
}