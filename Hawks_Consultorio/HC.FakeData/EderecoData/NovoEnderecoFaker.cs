using Bogus;
using HC.Core.Shared.ModelViews.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.FakeData.EderecoData
{
    public class NovoEnderecoFaker:Faker<NovoEndereco>
    {
        public NovoEnderecoFaker()
        {
            RuleFor(c => c.Numero, f => f.Address.BuildingNumber());
            RuleFor(c => c.CEP,f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
            RuleFor(c => c.Cidade, f => f.Address.City());
            RuleFor(c => c.Estado, f => f.PickRandom<EstadoView>());
            RuleFor(c => c.Logradouro, f => f.Address.StreetAddress());
            RuleFor(c => c.Complemento, f => f.Lorem.Sentence(20));

        }
    }
}
