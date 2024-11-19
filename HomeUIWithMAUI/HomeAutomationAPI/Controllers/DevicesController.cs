using HomeAutomationAPI.Data;
using HomeAutomationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomationAPI.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceRepository _repository = new DeviceRepository();

        [HttpGet]
        public IActionResult GetAllDevices()
        {
            var devices = _repository.GetAllDevices();
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeviceById(int id)
        {
            var device = _repository.GetDeviceById(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpPost]
        public IActionResult AddDevice([FromBody] Device device)
        {
            _repository.AddDevice(device);
            return CreatedAtAction(nameof(GetDeviceById), new { id = device.Id }, device);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDevice(int id, [FromBody] Device updatedDevice)
        {
            var success = _repository.UpdateDevice(id, updatedDevice);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(int id)
        {
            var success = _repository.DeleteDevice(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
