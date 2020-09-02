using devboost.dronedelivery.felipe.DTO.Extensions;
using System;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class DroneExtensionsTest
    {
        [Fact]
        public void TestToTempoGasto()
        {
            var drone = SetupTests.GetDrone();
            Assert.True(drone.ToTempoGasto(100).Hour == DateTime.Now.AddHours(2).Hour);
        }
    }
}
