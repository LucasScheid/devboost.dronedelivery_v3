using devboost.dronedelivery.felipe.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Security.Interfaces
{
    public interface ILoginValidator
    {
        Task<bool> CheckPasswordUserAsnc(ApplicationUser user, string password);
        Task<bool> ValidateRoleAsnc(ApplicationUser user, string role);

        Task<ApplicationUser> GetUserById(string userId);
    }
}
