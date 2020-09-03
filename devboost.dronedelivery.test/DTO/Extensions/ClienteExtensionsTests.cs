using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.test.Setup;
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
