using Bogus;
using HC.Core.Shared.ModelViews.Cliente;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HC.FakeData.TelefoneData;
using HC.FakeData.EderecoData;

namespace HC.FakeData.ClienteData
{
    public class NovoClienteFaker:Faker<NovoCliente>
    {
        public NovoClienteFaker()
        {
            RuleFor(c => c.Nome, f => f.Person.FullName);
            RuleFor(c => c.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(c => c.Documento, f => f.Person.Cpf());
            RuleFor(c => c.DataNascimento, f => f.Date.Past());
            RuleFor(c => c.Telefones, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(c => c.Endereco, f => new NovoEnderecoFaker().Generate());
        }
    }
}
