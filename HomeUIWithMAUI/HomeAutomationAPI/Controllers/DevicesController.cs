using HomeAutomationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private static List<Device> Devices = new List<Device>
        {
            new Device { Id = 1, Name = "Thermostat", Type = "Thermostat", IsOn = true, CurrentTemperature = 22.0, TargetTemperature = 22.0 },
            new Device {Id = 2, Name = "Dehumidifier", Type = "Dehumidifier", IsOn = true, WaterLevel = 50, Humidity = 40},
            new Device { Id = 3, Name = "Fridge", Type = "Fridge", IsOn = true, CurrentTemperature = 4.0, TargetTemperature = 4.0 }
        };

        [HttpGet]
        public IActionResult GetDevices()
        {
            return Ok(Devices);
        }

        [HttpPost]
        public IActionResult RegisterDevice([FromBody] Device newDevice)
        {
            newDevice.Id = Devices.Max(d => d.Id) + 1;
            Devices.Add(newDevice);
            return CreatedAtAction(nameof(GetDeviceById), new { id = newDevice.Id }, newDevice);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeviceById(int id)
        {
            var device = Devices.FirstOrDefault(d => d.Id == id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDevice(int id, [FromBody] Device updatedDevice)
        {
            var device = Devices.FirstOrDefault(d => d.Id == id);
            if (device == null) return NotFound();

            device.Name = updatedDevice.Name;
            device.Type = updatedDevice.Type;
            device.IsOn = updatedDevice.IsOn;
            device.CurrentTemperature = updatedDevice.CurrentTemperature;
            device.TargetTemperature = updatedDevice.TargetTemperature;

            return NoContent();
        }
    }
}
