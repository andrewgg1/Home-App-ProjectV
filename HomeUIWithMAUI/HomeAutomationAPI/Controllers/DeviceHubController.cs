using HomeAutomationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceHubsController : ControllerBase
    {
        private static List<DeviceHub> DeviceHubs = new List<DeviceHub>
        {
            new DeviceHub
            {
                Id = 1,
                Name = "Locks",
                Devices = new List<Device>
                {
                    new Device { Id = 101, Name = "Front Door Smart Lock", Type = "Lock", IsOn = true },
                    new Device { Id = 102, Name = "Garage Door Smart Lock", Type = "Lock", IsOn = false },
                    new Device { Id = 103, Name = "Back Door Smart Lock", Type = "Lock", IsOn = true },
                    new Device { Id = 104, Name = "Window Locks", Type = "Lock", IsOn = true },
                    new Device { Id = 105, Name = "Interior Door Locks (Mud Room)", Type = "Lock", IsOn = false },
                    new Device { Id = 106, Name = "Gate Locks (Fence Gate)", Type = "Lock", IsOn = true }
                }
            },
            new DeviceHub
            {
                Id = 2,
                Name = "Sensors",
                Devices = new List<Device>
                {
                    new Device { Id = 201, Name = "Motion Sensors (Front and Back Outdoor)", Type = "Sensor", IsOn = true },
                    new Device { Id = 202, Name = "Glass Break Sensors", Type = "Sensor", IsOn = false },
                    new Device { Id = 203, Name = "Door and Window Sensors", Type = "Sensor", IsOn = true },
                    new Device { Id = 204, Name = "Garage Door Sensors", Type = "Sensor", IsOn = false },
                    new Device { Id = 205, Name = "Water Leak Sensors", Type = "Sensor", IsOn = true }
                }
            },
            new DeviceHub
            {
                Id = 3,
                Name = "Cameras",
                Devices = new List<Device>
                {
                    new Device { Id = 301, Name = "Front Doorbell Camera", Type = "Camera", IsOn = true },
                    new Device { Id = 302, Name = "Backyard Camera", Type = "Camera", IsOn = true },
                    new Device { Id = 303, Name = "Side Gate Camera", Type = "Camera", IsOn = false },
                    new Device { Id = 304, Name = "Garage Camera", Type = "Camera", IsOn = true },
                    new Device { Id = 305, Name = "Driveway Camera", Type = "Camera", IsOn = true }
                }
            },
            new DeviceHub
            {
                Id = 4,
                Name = "Alarms",
                Devices = new List<Device>
                {
                    new Device { Id = 401, Name = "Fire/Smoke Detectors", Type = "Alarm", IsOn = true },
                    new Device { Id = 402, Name = "Carbon Monoxide (CO) Detectors", Type = "Alarm", IsOn = true },
                    new Device { Id = 403, Name = "Garage Alarm", Type = "Alarm", IsOn = false },
                    new Device { Id = 404, Name = "Main House Alarm System", Type = "Alarm", IsOn = true },
                    new Device { Id = 405, Name = "Panic Buttons", Type = "Alarm", IsOn = true },
                    new Device { Id = 406, Name = "Flood/Water Alarm", Type = "Alarm", IsOn = false }
                }
            },
            new DeviceHub
            {
                Id = 5,
                Name = "Trackers",
                Devices = new List<Device>
                {
                    new Device { Id = 501, Name = "Car GPS Tracker", Type = "Tracker", IsOn = true },
                    new Device { Id = 502, Name = "Bike GPS Tracker", Type = "Tracker", IsOn = false },
                    new Device { Id = 503, Name = "Pet GPS Tracker", Type = "Tracker", IsOn = true }
                }
            }
        };

        [HttpGet]
        public IActionResult GetDeviceHubs()
        {
            return Ok(DeviceHubs);
        }

        [HttpGet("{id}/devices")]
        public IActionResult GetDevicesInHub(int id)
        {
            var hub = DeviceHubs.FirstOrDefault(h => h.Id == id);
            if (hub == null) return NotFound();
            return Ok(hub.Devices);
        }

        [HttpPost]
        public IActionResult RegisterHub([FromBody] DeviceHub newHub)
        {
            newHub.Id = DeviceHubs.Max(h => h.Id) + 1;
            DeviceHubs.Add(newHub);
            return CreatedAtAction(nameof(GetDeviceHubs), new { id = newHub.Id }, newHub);
        }
    }
}
