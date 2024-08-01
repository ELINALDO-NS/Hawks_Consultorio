using Bogus;
using HC.Core.Shared.ModelViews.Cliente;
using HC.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.FakeData.TelefoneData
{
    public class NovoTelefoneFaker:Faker<NovoTelefone>
    {
        public NovoTelefoneFaker()
        {
            RuleFor(x => x.Numero, f => f.Person.Phone);
        }
    }
}
