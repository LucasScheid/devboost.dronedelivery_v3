using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Security
{
    public class LoginValidator : ILoginValidator
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginValidator(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> CheckUserAndPassword(ApplicationUser user, string password, bool lockoutOnFailure)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
            return result.Succeeded;
        }
    }
}
