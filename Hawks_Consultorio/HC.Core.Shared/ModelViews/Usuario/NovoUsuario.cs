using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Core.Shared.ModelViews.Usuario
{
    public class NovoUsuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public ICollection<ReferenciaFuncao> Funcoes { get; set; }
    }
}
