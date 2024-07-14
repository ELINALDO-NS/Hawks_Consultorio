﻿using HC.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int id);
    }
}
