using Bogus;
using HC.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.FakeData.TelefoneData
{
    public class TelefoneFaker : Faker<Telefone>
    {
        public TelefoneFaker(int clientId)
        {
            RuleFor(o => o.CLienteId, f => clientId);
            RuleFor(o => o.Numero, f => f.Person.Phone);
        }
    }
}
