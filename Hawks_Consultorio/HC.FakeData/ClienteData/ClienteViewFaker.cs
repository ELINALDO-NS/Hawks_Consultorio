using Bogus;
using Bogus.Extensions.Brazil;
using HC.Core.Shared.ModelViews.Cliente;
using HC.FakeData.EderecoData;
using HC.FakeData.TelefoneData;


namespace HC.FakeData.ClienteData
{
    public class ClienteViewFaker:Faker<ClienteView>
    {
        public ClienteViewFaker()
        {
            var id = new Faker().Random.Number(1, 99999);
            RuleFor(c => c.Id, f => id);
            RuleFor(c => c.Nome, f => f.Person.FullName);
            RuleFor(c => c.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(c => c.Documento, f => f.Person.Cpf());
            RuleFor(c => c.Criacao, f => f.Date.Past());
            RuleFor(c => c.UltimaAtualizacao, f => f.Date.Past());
            RuleFor(c => c.DataNascimento, f => f.Date.Past());
            RuleFor(c => c.Telefones, f => new TelefoneViewFaker().Generate(3));
            RuleFor(c => c.Endereco, f => new EnderecoViewFaker().Generate());

        }
    }
}
