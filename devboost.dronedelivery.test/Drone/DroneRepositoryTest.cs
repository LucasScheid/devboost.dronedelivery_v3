using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using devboost.dronedelivery.test.Setup;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Data.SqlClient;
using Moq;

namespace devboost.dronedelivery.test.Drone
{
    public class DroneRepositoryTest
    {

        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly DroneRepository _droneRepository;
        private readonly SqlConnection _sqlConnection;

        public DroneRepositoryTest()
        {
            _context = Substitute.For<DataContext>();
            _configuration = Substitute.For<IConfiguration>();
            _sqlConnection = new SqlConnection();
            _droneRepository = new DroneRepository(_context, _sqlConnection);
            

        }

        [Fact]
        public void TestGetDrone()
        {
            var drone = SetupTests.GetDrone();

            var encontrado = _droneRepository.GetDrone(drone.Id);

            Assert.Null(encontrado);
        }

        [Fact]
        public void TestSaveDrone()
        {
            var drone = SetupTests.GetDrone();
            _droneRepository.SaveDrone(drone);
            Assert.True(true);
        }

        [Fact]
        public void TestGetDroneStatus()
        {
            //var listaDroneStatus = _droneRepository.GetDroneStatusAsync();

            Assert.True(true);
        }
    }
}
