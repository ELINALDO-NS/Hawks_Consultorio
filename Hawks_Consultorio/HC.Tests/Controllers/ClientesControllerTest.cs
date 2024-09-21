using Castle.Core.Logging;
using FluentAssertions;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Cliente;
using HC.FakeData.ClienteData;
using HC.Manager.Interfaces.Managers;
using HC.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HC.Tests.Controllers
{
    public class ClientesControllerTest
    {
        private readonly IClienteManager _menager;
        private readonly ILogger<ClientesController> _logger;
        private readonly ClientesController controller;
        private readonly ClienteView clienteView;
        private readonly List<ClienteView> clientesView;
        private readonly NovoCliente novoCLiente;
        public ClientesControllerTest()
        {
            _menager = Substitute.For<IClienteManager>();
            _logger = Substitute.For<ILogger<ClientesController>>();
            controller = new ClientesController(_menager, _logger);
            clienteView = new ClienteViewFaker().Generate();
            clientesView = new ClienteViewFaker().Generate(10);
            novoCLiente = new NovoClienteFaker().Generate();

        }

        [Fact]
        public async Task Get_OK()
        {
            var controle = new List<ClienteView>();
            clientesView.ForEach(p => controle.Add(p.CloneTipado()));
            _menager.GetClientesAsync().Returns(clientesView);


            var result = (ObjectResult)await controller.Get();
            await _menager.Received().GetClientesAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(controle);

        }
        [Fact]
        public async Task Not_Found()
        {
            _menager.GetClientesAsync().Returns(new List<ClienteView>());
            var resultado = (StatusCodeResult)await controller.Get();
            await _menager.Received().GetClientesAsync();
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
        [Fact]
        public async Task GetById_OK()
        {
            _menager.GetClienteAsync(Arg.Any<int>()).Returns(clienteView.CloneTipado());
            var resultado = (ObjectResult)await controller.Get(clienteView.Id);
            resultado.Value.Should().BeEquivalentTo(clienteView);
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
        [Fact]
        public async Task GetById_NotFount()
        {
            _menager.GetClienteAsync(Arg.Any<int>()).Returns(new ClienteView());
            var resultado = (ObjectResult)await controller.Get(1);
            await _menager.Received().GetClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Post_Created()
        {
            _menager.InsertClienteAsync(Arg.Any<NovoCliente>()).Returns(clienteView.CloneTipado());
            var resultado = (ObjectResult)await controller.Post(novoCLiente);
            await _menager.Received().InsertClienteAsync(Arg.Any<NovoCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
            resultado.Value.Should().BeEquivalentTo(clienteView);

        }
        [Fact]
        public async Task Put_OK()
        {
            _menager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).Returns(clienteView.CloneTipado());
            var resultado = (ObjectResult)await controller.Put(new AlteraCliente());
            await _menager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(clienteView);


        }
        [Fact]
        public async Task Put_NotFountd()
        {
            _menager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).ReturnsNull();
            var resultado = (StatusCodeResult) await controller.Put(new AlteraCliente());
            await _menager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);

        }
        [Fact]
        public async Task Delete_NoContent()
        {
            _menager.DeleteClienteAsync(Arg.Any<int>()).Returns(clienteView);
            var resultado = (StatusCodeResult)await controller.Delete(1);
            await _menager.Received().DeleteClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            
        }
        [Fact]
        public async Task Delete_NotFound()
        {
            _menager.DeleteClienteAsync(Arg.Any<int>()).ReturnsNull();
            var resultado = (StatusCodeResult)await controller.Delete(1);
            await _menager.Received().DeleteClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);


        }
    }
}
