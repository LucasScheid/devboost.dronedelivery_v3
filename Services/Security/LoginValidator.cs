﻿using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Security
{
    public class LoginValidator : ILoginValidator
    {
        private const bool LOCKOUT_ON_FAILURE = false;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginValidator(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> CheckPasswordUserAsnc(ApplicationUser user, string password)
        {
            var result = await _signInManager
                        .CheckPasswordSignInAsync(user, password, LOCKOUT_ON_FAILURE);
            return result.Succeeded;
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userManager
                     .FindByNameAsync(userId);
        }

        public async Task<bool> ValidateRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }
    }
}
