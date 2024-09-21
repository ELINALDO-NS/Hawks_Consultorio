using HC.Core.Domain;
using HC.Data.Context;
using HC.Data.Repository;
using HC.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using HC.FakeData.ClienteData;
using FluentAssertions;
using FluentAssertions.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Win32;
using HC.FakeData.TelefoneData;


namespace HC.Repository.Tests.Repository
{
    public class ClienteRepositoryTest : IDisposable
    {
        private readonly IClienteRepository repository;
        private readonly HCContext context;
        private readonly Cliente cliente;
        private ClienteFaker ClienteFaker;

        public ClienteRepositoryTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<HCContext>();
            optionBuilder.UseInMemoryDatabase("DB_Teste");
            context = new HCContext(optionBuilder.Options);
            repository = new ClienteRepository(context);
            ClienteFaker = new ClienteFaker();
            cliente = ClienteFaker.Generate();

        }

        private async Task<List<Cliente>> InsereRegistros()
        {
            var cliente = ClienteFaker.Generate(100);
            foreach (var item in cliente)
            {
                item.Id = 0;
                await context.AddAsync(item);
            }
            await context.SaveChangesAsync();
            return cliente;
        }
        [Fact]
        public async Task GetClientesAsync_ComRetorno()
        {
            var registro = await InsereRegistros();
            var retorno = await repository.GetClientesAsync();
            retorno.Should().HaveCount(registro.Count);
            retorno.First().Endereco.Should().NotBeNull();
            retorno.First().Telefones.Should().NotBeNull();

        }
        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            var retorno = await repository.GetClientesAsync();
            retorno.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetClientesAsync_Encontrado()
        {
            var registro = await InsereRegistros();
            var retorno = await repository.GetClienteAsync(registro.First().Id);
            retorno.Should().BeEquivalentTo(registro.First());
        }

        [Fact]
        public async Task GetClientesAsync_NaoEncontrado()
        {
            var retorno = await repository.GetClienteAsync(88888);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task InsertClienteAsync_Sucesso()
        {
            var retorno = await repository.InsertClienteAsync(cliente);
            retorno.Should().BeEquivalentTo(cliente);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            var registro = await InsereRegistros();
            var clienteAlterado = registro.First();
            clienteAlterado.Nome = "Jubileu";
            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);

        }

        [Fact]
        public async Task UpdateClienteAsync_AdicionaTelefone()
        {
            var registro = await InsereRegistros();
            var clientealterado = registro.First();
            clientealterado.Telefones.Add(new TelefoneFaker(clientealterado.Id).Generate());
            var retorno = await repository.UpdateClienteAsync(clientealterado);
            retorno.Should().BeEquivalentTo(clientealterado);

        }

        [Fact]
        public async Task UpdateClienteAsync_RemoveTelefone()
        {
            var registro = await InsereRegistros();
            var clientealterado = registro.First();
            clientealterado.Telefones.Remove(clientealterado.Telefones.First());
            var retorno = await repository.UpdateClienteAsync(clientealterado);
            retorno.Should().BeEquivalentTo(clientealterado);

        }

        [Fact]
        public async Task UpdateClienteAsync_RemoveTodosTelefone()
        {
            var registro = await InsereRegistros();
            var clientealterado = registro.First();
            clientealterado.Telefones.Clear();
            var retorno = await repository.UpdateClienteAsync(clientealterado);
            retorno.Should().BeEquivalentTo(clientealterado);

        }
        [Fact]
        public async Task UpdateClienteAsync_NaoEncontrado()
        {
            
            var retorno = await repository.UpdateClienteAsync(cliente);
            retorno.Should().BeNull();

        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            var registro = await InsereRegistros();
            var retorno = await repository.DeleteClienteAsync(registro.First().Id);
            retorno.Should().BeEquivalentTo(registro.First());

        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncontrado()
        {

            var retorno = await repository.DeleteClienteAsync(1);
            retorno.Should().BeNull();

        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
