using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security;
using devboost.dronedelivery.felipe.Security.Interfaces;
using Microsoft.Extensions.Options;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using System.Configuration;
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

        [Fact]
        public void GenerateToken()
        {
            _tokenConfigurations.Audience = "ExemploAudience";
            _tokenConfigurations.Issuer = "ExemploIssuer";
            _tokenConfigurations.Seconds = 90;

            var accessManager = new AccessManager(_signingConfigurations, _tokenConfigurations, _loginValidator);
            var token = accessManager.GenerateToken(SetupTests.GetCliente());

            Assert.True(token.Authenticated);
            Assert.IsType<string>(token.AccessToken);
            Assert.IsType<Token>(token);

        }

        [Fact]
        public void CheckPasswordUserAsnc()
        {
            _loginValidator.CheckPasswordUserAsnc(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(true);
        }

        [Fact]
        public void GetUserById()
        {
            _loginValidator.GetUserById(Arg.Any<string>()).Returns(new ApplicationUser());
        }

        [Fact]
        public void ValidateRoleAsnc()
        {
            _loginValidator.ValidateRoleAsnc(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(true);
        }
    }
}
