using devboost.dronedelivery.felipe.DTO.Extensions;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class ClienteExtensionsTest
    {
        [Fact]
        public void TestClienteExtension()
        {
            var client = SetupTests.GetCliente();
            Assert.True(client.HasClient());
        }
    }
}
