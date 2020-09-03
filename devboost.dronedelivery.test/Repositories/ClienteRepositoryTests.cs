using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class ClienteRepositoryTests
    {
        private readonly DataContext _context;
        public ClienteRepositoryTests()
        {
            _context = Substitute.For<DataContext>();
        }

        [Fact]
        public async Task TestSaveClient()
        {
            var clienteRepository = new ClienteRepository(_context);
            await clienteRepository.SaveCliente(SetupTests.GetCliente());
            _context.Received().Cliente.Add(Arg.Any<felipe.DTO.Models.Cliente>());
            await _context.Received().SaveChangesAsync();


        }
    }
}
