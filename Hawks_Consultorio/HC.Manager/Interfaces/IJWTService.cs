using HC.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Interfaces
{
    public interface IJWTService
    {
        string GerarTokem(Usuario usuario);
    }
}
