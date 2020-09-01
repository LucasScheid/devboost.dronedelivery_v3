using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.Facade.Interface;
using devboost.dronedelivery.felipe.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade
{
    public class DroneFacade : IDroneFacade
    {
        private readonly IDroneService _droneService;
        public DroneFacade(IDroneService droneService)
        {
            _droneService = droneService;
        }
        public List<StatusDroneDto> GetDroneStatusAsync()
        {
            return _droneService.GetDroneStatusAsync().ToList();
        }

    }
}
