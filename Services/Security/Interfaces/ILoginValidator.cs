using devboost.dronedelivery.felipe.DTO.Models;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Security.Interfaces
{
    public interface ILoginValidator
    {
        Task<bool> CheckUserAndPassword(ApplicationUser user, string password, bool lockoutOnFailure);
    }
}
