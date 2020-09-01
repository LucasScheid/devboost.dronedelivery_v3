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
    public class DronesController : ControllerBase
    {
        private readonly IDroneFacade _droneFacade;
        private readonly IDroneRepository _droneRepository;

        public DronesController(IDroneRepository droneRepository, IDroneFacade droneFacade)
        {
            _droneFacade = droneFacade;
            _droneRepository = droneRepository;            
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
            drone.Perfomance = (drone.Autonomia / 60.0f) * drone.Velocidade;

             _droneRepository.SaveDrone(drone);

            return drone;
        }
    }
}
