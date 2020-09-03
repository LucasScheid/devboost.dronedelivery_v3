using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class DronesController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly IDroneFacade _droneFacade;
        private readonly IDroneRepository _droneRepository;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public DronesController(IDroneRepository droneRepository, IDroneFacade droneFacade)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _droneFacade = droneFacade;
            _droneRepository = droneRepository;            
        }

        [HttpGet("GetStatusDrone")]
        [AllowAnonymous]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ActionResult<List<StatusDroneDto>> GetStatusDrone()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return Ok(_droneFacade.GetDroneStatusAsync());
        }
      
        [HttpPost]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<Drone>> PostDrone(Drone drone)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
             return _droneFacade.SaveDrone(drone);
        }
    }
}
