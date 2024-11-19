using HomeAutomationAPI.Data;
using HomeAutomationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomationAPI.Controllers
{
    [ApiController]
    [Route("api/thermostat")]
    public class ThermostatController : ControllerBase
    {
        private readonly DeviceRepository _repository = new DeviceRepository();

        [HttpGet]
        public IActionResult GetThermostat()
        {
            var thermostat = _repository.GetThermostat();
            return Ok(thermostat);
        }

        [HttpPut]
        public IActionResult UpdateTargetTemperature([FromBody] double targetTemperature)
        {
            _repository.UpdateThermostat(targetTemperature);
            return NoContent();
        }

        [HttpPost("toggle")]
        public IActionResult TogglePower()
        {
            _repository.ToggleThermostatPower();
            return NoContent();
        }
    }
}
