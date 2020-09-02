using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
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
    public class DronesController : ControllerBase
    {
        private readonly IDroneFacade _droneFacade;


        public DronesController(IDroneFacade droneFacade)
        {
            _droneFacade = droneFacade;
        }

        [HttpGet("GetStatusDrone")]
        [AllowAnonymous]
        public ActionResult<List<StatusDroneDto>> GetStatusDrone()
        {
            return Ok(_droneFacade.GetDroneStatusAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Drone>> PostDrone(Drone drone)
        {
            return _droneFacade.SaveDrone(drone);
        }
    }
}
