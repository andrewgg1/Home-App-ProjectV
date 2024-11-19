using HomeAutomationAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomationAPI.Data
{
    public class DeviceRepository
    {
        private readonly List<Device> _devices = new List<Device>();
        private readonly Thermostat _thermostat = new Thermostat();

        public IEnumerable<Device> GetAllDevices() => _devices;

        public Device GetDeviceById(int id) => _devices.FirstOrDefault(d => d.Id == id);

        public void AddDevice(Device device)
        {
            device.Id = _devices.Any() ? _devices.Max(d => d.Id) + 1 : 1;
            _devices.Add(device);
        }

        public bool UpdateDevice(int id, Device updatedDevice)
        {
            var device = GetDeviceById(id);
            if (device == null) return false;

            device.Name = updatedDevice.Name;
            device.Type = updatedDevice.Type;
            device.IsOn = updatedDevice.IsOn;
            return true;
        }

        public bool DeleteDevice(int id)
        {
            var device = GetDeviceById(id);
            if (device == null) return false;

            _devices.Remove(device);
            return true;
        }

        public Thermostat GetThermostat() => _thermostat;

        public void UpdateThermostat(double targetTemperature)
        {
            _thermostat.SetTargetTemperature(targetTemperature);
        }

        public void ToggleThermostatPower()
        {
            _thermostat.TogglePower();
        }
    }
}
