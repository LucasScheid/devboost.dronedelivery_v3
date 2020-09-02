using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace devboost.dronedelivery.test.Drone
{
    public class MockDroneRepository : IDroneRepository
    {
        public felipe.DTO.Models.Drone GetDrone(int id)
        {
            throw new NotImplementedException();
        }

        public List<StatusDroneDto> GetDroneStatusAsync()
        {
            return SetupTests.GetDroneStatus();
        }

        public felipe.DTO.Models.Drone RetornaDrone()
        {
            throw new NotImplementedException();
        }

        public DroneStatusDto RetornaDroneStatus(int droneId)
        {
            throw new NotImplementedException();
        }

        public void SaveDrone(felipe.DTO.Models.Drone drone)
        {
        }
    }
}
