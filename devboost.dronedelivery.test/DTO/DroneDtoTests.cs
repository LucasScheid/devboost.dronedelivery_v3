using devboost.dronedelivery.felipe.DTO;
using Xunit;

namespace devboost.dronedelivery.test.DTO
{
    public class DroneDtoTests
    {
        [Fact]
        public void TestConstructor()
        {
            var droneDto = new DroneDto(
                    new DroneStatusDto()
                    {
                        Drone = SetupTests.GetDrone(),
                        SomaDistancia = 100,
                        SomaPeso = 100
                    }, 100);

            Assert.True(droneDto.Distancia == 100);
            Assert.True(droneDto.DroneStatus.SomaDistancia == 100);
            Assert.True(droneDto.DroneStatus.SomaPeso == 100);


        }
    }
}
