using Bogus;
using Bogus.Extensions.Brazil;
using HC.Core.Domain;
using HC.FakeData.EderecoData;
using HC.FakeData.TelefoneData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.FakeData.ClienteData
{
    public class ClienteFaker:Faker<Cliente>
    {
        public ClienteFaker()
        {
            var id = new Faker().Random.Number(1, 999999);
            RuleFor(o => o.Id, f => id);
            RuleFor(o => o.Nome, f => f.Person.FullName);
            RuleFor(o => o.Sexo, f => f.PickRandom<Sexo>());
            RuleFor(o => o.Documento, f => f.Person.Cpf());
            RuleFor(o => o.Criacao, f => f.Date.Past());
            RuleFor(o => o.UltimaAtualização, f => f.Date.Past());
            RuleFor(o => o.Telefones, f => new TelefoneFaker(id).Generate(1));
            RuleFor(o => o.Endereco, f => new EnderecoFaker(id).Generate());
        }
    }
}
