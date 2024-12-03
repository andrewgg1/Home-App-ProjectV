using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Device = HomeUIWithMAUI.Models.Device;

namespace HomeUIWithMAUI.DevicePool
{
    static class DevicePool
    {
        public static List<Device> Devices { get; set; } = new List<Device>();

        static DevicePool()
        {
            // Add 1 of each device to the device pool
            // No hubs
            AddDevice(new Models.Fridge(Models.State.On));
            AddDevice(new Models.Dehumidifier(Models.State.On));
            AddDevice(new Models.Thermostat(72.0, Models.State.On));

            // With hubs
            AddDevice(new Models.SmartLock(1, Models.State.On, false));
            AddDevice(new Models.Sensor(2, Models.State.On, false));
            AddDevice(new Models.SecurityCamera(3, Models.State.On, false));
            AddDevice(new Models.SecurityAlarm(4, Models.State.On, false));
            AddDevice(new Models.Tracker(5, Models.State.On, false, 0));
        }

        public static void AddDevice(Device device)
        {
            Devices.Add(device);
        }
        public static void RemoveDevice(Device device)
        {
            Devices.Remove(device);
        }
        public static void UpdateDevice(Device device)
        {
            Device? existingDevice = Devices.Find(d => d.DeviceId == device.DeviceId && d.HubId == device.HubId);
            if (existingDevice != null)
            {
                existingDevice = device;
            }
        }
        public static Device? GetDevice(int deviceId)
        {
            return Devices.Find(d => d.DeviceId == deviceId);
        }
    }
}
