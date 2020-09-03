using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using NSubstitute;
using System.Linq;
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


        [Fact]
        public void GetCliente()
        {

            var cliente = SetupTests.GetCliente();
            var clienteRepository = new ClienteRepository(_context);

            var result = clienteRepository.GetCliente(cliente.Id);

            _context.Received().Find<felipe.DTO.Models.Cliente>(cliente.Id);

        }

        [Fact]
        public void GetClientes()
        {

            _context.Received().Cliente.AsQueryable<felipe.DTO.Models.Cliente>();

        }

    }
}
