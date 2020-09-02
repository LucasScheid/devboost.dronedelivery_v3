using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using devboost.dronedelivery.felipe.DTO.Extensions;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class DroneExtensionsTests
    {
        [Fact]
        public void TestToTempoGasto()
        {
            var drone = SetupTests.GetDrone();
            var date = drone.ToTempoGasto(100);
            Assert.True(date.Hour == DateTime.Now.AddHours(2).Hour);
        }
    }
}
