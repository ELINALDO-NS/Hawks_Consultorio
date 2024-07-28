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
using System;
using System.Collections.Generic;
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
        public ClientesControllerTest()
        {
            _menager = Substitute.For<IClienteManager>();
            _logger = Substitute.For<ILogger<ClientesController>>();
            controller = new ClientesController(_menager, _logger);
            clienteView = new ClienteViewFaker().Generate();
            clientesView = new ClienteViewFaker().Generate(10);

        }

        [Fact]
        public async Task Get_OK()
        {
            var controle = new List<ClienteView>();
            clientesView.ForEach(p=> controle.Add(p.CloneTipado()));
            _menager.GetClientesAsync().Returns(clientesView);
            var result = (ObjectResult) await controller.Get();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(controle);

        }
    }
}
