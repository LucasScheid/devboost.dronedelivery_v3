using devboost.dronedelivery.felipe.DTO.Models;
using NSubstitute;
using Xunit;

namespace devboost.dronedelivery.test
{
    public class LoginTest
    {

        [Fact]
        public void ValidarCredencial()
        {

            var cliente = new devboost.dronedelivery.felipe.DTO.Models.Cliente()
            {
                Id = 0,
                Nome = "Usuario Acesso",
                UserId = "admin_drone",
                Password = "AdminAPIDrone01!"
            };
            var applicationUser = Substitute.For<ApplicationUser>();

            //NSubstitute.

            //var mock = Substitute.For<UserManager<C>>();

            //var userIdentity = mock.FindByNameAsync(cliente.UserId).Result;



        }

    }
}
