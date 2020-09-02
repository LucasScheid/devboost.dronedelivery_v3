using devboost.dronedelivery.felipe.DTO.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class ClienteExtensionsTests
    {
        [Fact]
        public void ClienteHasUserTest()
        {
            var cliente = SetupTests.GetCliente();
            Assert.True(cliente.HasClient());
        }
    }
}
