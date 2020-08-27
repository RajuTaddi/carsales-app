using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using carsales.common.models;
using carsales.core.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace carsales.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;

        public VehicleController(ILogger<VehicleController> logger,
            IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("listings")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Vehicle), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Vehicle>> Get()
        {
            _logger.LogInformation("Test");
            var response = await this._vehicleService.GetVehicles();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}/details")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(VehicleDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<VehicleDetails>> GetById(string id)
        {
            _logger.LogInformation("Test");
            var response = await this._vehicleService.GetVehicleById(id);
            return Ok(response);
        }
    }
}
