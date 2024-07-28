using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HC.Core.Shared.ModelViews.Especialidade;

namespace HC.Core.Shared.ModelViews.Medico
{
    public class NovoMedico
    {
        public string Nome { get; set; }
        public int CRM { get; set; }
        public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
    }
}
