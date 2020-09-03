﻿using devboost.dronedelivery.felipe.Controllers;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security;
using devboost.dronedelivery.felipe.Security.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Controller
{
    public class LoginControllerTests
    {
        private readonly AccessManager _accessManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly ILoginValidator _loginValidator;

        public LoginControllerTests()
        {
            _signingConfigurations = Substitute.For<SigningConfigurations>();
            _tokenConfigurations = new TokenConfigurations() {Seconds = 1000 };
            _loginValidator = Substitute.For<ILoginValidator>();
            _accessManager = new AccessManager(_signingConfigurations, _tokenConfigurations, _loginValidator);
        }
        [Fact]
        public async Task PostTest()
        {
            _loginValidator.CheckPasswordUserAsync(Arg.Any<ApplicationUser>(),Arg.Any<string>()).Returns(true);
            _loginValidator.GetUserById(Arg.Any<string>()).Returns(new ApplicationUser());
            _loginValidator.ValidateRoleAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(true);
            var loginController = new LoginController(_accessManager);
            var token = await loginController.Post(SetupTests.GetCliente()) as Token;
            
            Assert.True(!string.IsNullOrEmpty(token.AccessToken));
            Assert.True(!string.IsNullOrEmpty(token.Message));
            Assert.True(token.Authenticated);
            Assert.True(!string.IsNullOrEmpty(token.Created));
            Assert.True(!string.IsNullOrEmpty(token.Expiration));


        }

        [Fact]
        public async Task PostFailedTest()
        {
            _loginValidator.CheckPasswordUserAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(false);
            _loginValidator.GetUserById(Arg.Any<string>()).Returns(new ApplicationUser());
            _loginValidator.ValidateRoleAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>()).Returns(false);
            var loginController = new LoginController(_accessManager);
            var token = await loginController.Post(SetupTests.GetCliente()) as Token;
            Assert.True(token == null);

        }

    }
}
