using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security;
using devboost.dronedelivery.felipe.Security.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test
{
    public class AccessManagerTests
    {
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly ILoginValidator _loginValidator;

        public AccessManagerTests()
        {
            _signingConfigurations = Substitute.For<SigningConfigurations>();
            _tokenConfigurations = Substitute.For<TokenConfigurations>();
            _loginValidator = Substitute.For<ILoginValidator>();
        }

        [Fact]
        public async Task TestAccessManagerLoginSuccess()
        {
            var accessManager = new AccessManager(_signingConfigurations, _tokenConfigurations, _loginValidator);
            _loginValidator.GetUserById(Arg.Any<string>()).Returns(new ApplicationUser());
            _loginValidator.CheckPasswordUserAsnc(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(true);
            _loginValidator.ValidateRoleAsnc(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(true);
            var valid = await accessManager.ValidateCredentials(SetupTests.GetCliente());
            Assert.True(valid);
        }
    }
}
