using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security;
using devboost.dronedelivery.felipe.Security.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test
{
    public class AccessManagerTests
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly ILoginValidator _loginValidator;

        public AccessManagerTests()
        {
            var store = Substitute.For<IUserStore<ApplicationUser>>();
            var optionsAccessor = Substitute.For<IOptions<IdentityOptions>>();
            var passwordHasher = Substitute.For<IPasswordHasher<ApplicationUser>>();
            var userValidators = Substitute.For<IEnumerable<IUserValidator<ApplicationUser>>>();
            var passwordValidators = Substitute.For<IEnumerable<IPasswordValidator<ApplicationUser>>>();
            var keyNormalizer = Substitute.For<ILookupNormalizer>();
            var errors = Substitute.For<IdentityErrorDescriber>();
            var services = Substitute.For<IServiceProvider>();
            var logger = Substitute.For<ILogger<UserManager<ApplicationUser>>>();

            _userManager = Substitute.For<UserManager<ApplicationUser>>(store, optionsAccessor,
                passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
                services, logger);
            _signingConfigurations = Substitute.For<SigningConfigurations>();
            _tokenConfigurations = Substitute.For<TokenConfigurations>();
            _loginValidator = Substitute.For<ILoginValidator>();
        }

        [Fact]
        public async Task TestValidateCredencials()
        {
            var accessManager = new AccessManager(_userManager,
                _signingConfigurations,
                _tokenConfigurations,
                _loginValidator);
            _userManager.FindByNameAsync(Arg.Any<string>()).Returns(new ApplicationUser());
            _loginValidator.CheckUserAndPassword(Arg.Any<ApplicationUser>(), Arg.Any<string>(), Arg.Any<bool>())
                .Returns(true);
            _userManager.IsInRoleAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(true);
            var credentials = await accessManager.ValidateCredentials(SetupTests.GetCliente());
            Assert.True(credentials);

        }
    }
}
