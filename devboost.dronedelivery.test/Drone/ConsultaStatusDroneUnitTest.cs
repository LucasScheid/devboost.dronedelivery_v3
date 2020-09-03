using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Services;
using devboost.dronedelivery.felipe.Services.Interfaces;
using NSubstitute;
using Xunit;

namespace devboost.dronedelivery.test.Drone
{
    public class ConsultaStatusDroneUnitTest
    {
        [Fact]
        public void ConsultarStatusDrone()
        {
            ICoordinateService coordinateService = new CoordinateService();
            IPedidoDroneRepository pedidoDroneRepository = null;
            IDroneRepository droneRepository = new MockDroneRepository();             

            IPedidoRepository pedidoRepository = null;

            IDroneService droneService = new DroneService(coordinateService, pedidoDroneRepository, droneRepository, pedidoRepository);

            droneService.GetDroneStatusAsync();

            Assert.Equal<int>(2,droneService.GetDroneStatusAsync().Count);

            
        }

        [Fact]
        public void CriarDroneStatusResult()
        {
            DroneStatusResult drone = new DroneStatusResult
            {
                Id = 1,
                Capacidade = 80,
                Velocidade = 100,
                Autonomia = 4,
                Carga = 300,
                Perfomance = 467.7F,
                SomaPeso = 111,
                SomaDistancia = 453
            };

            Assert.NotNull(drone);

        }
    }
}
