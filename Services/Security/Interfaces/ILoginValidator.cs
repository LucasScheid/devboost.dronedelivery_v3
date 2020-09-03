using devboost.dronedelivery.felipe.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Security.Interfaces
{
    public interface ILoginValidator
    {
        Task<bool> CheckPasswordUserAsync(ApplicationUser user, string password);
        Task<bool> ValidateRoleAsync(ApplicationUser user, string role);

        Task<ApplicationUser> GetUserById(string userId);
    }
}
