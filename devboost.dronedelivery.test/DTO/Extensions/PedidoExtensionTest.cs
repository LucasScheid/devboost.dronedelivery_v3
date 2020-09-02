using devboost.dronedelivery.felipe.DTO.Extensions;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class PedidoExtensionTest
    {
        [Fact]
        public void TestGetPoint()
        {
            var pedido = SetupTests.GetPedido();
            var point = pedido.GetPoint();
            Assert.True(point.Latitude == pedido.Cliente.Latitude && point.Longitude == pedido.Cliente.Longitude);
        }
    }
}
