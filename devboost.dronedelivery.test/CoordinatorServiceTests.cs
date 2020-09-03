using devboost.dronedelivery.felipe.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using devboost.dronedelivery.felipe.DTO.Extensions;

namespace devboost.dronedelivery.test
{
    public class CoordinatorServiceTests
    {
        [Fact]
        public void GetKmDistanceTest()
        {
            var coordinatiorService = new CoordinateService();
            var pedido = SetupTests.GetPedido();
            var distance = coordinatiorService.GetKmDistance(pedido.GetPoint(), new felipe.DTO.Point());
            Assert.True(distance == 489.8);
        }
    }
}
