using Bogus;
using HC.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.FakeData.TelefoneData
{
    public class TelefoneViewFaker:Faker<TelefoneView>
    {
        public TelefoneViewFaker()
        {
            RuleFor(x => x.Id,f=> f.Random.Number(1,10));
            RuleFor(x => x.Numero,f=> f.Person.Phone);
        }
    }
}
