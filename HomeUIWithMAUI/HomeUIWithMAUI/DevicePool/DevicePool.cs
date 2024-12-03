using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // Add an event for device updates
        public static event Action<Device> DeviceUpdated;

        static DevicePool()
        {
            // Existing code to add devices to the pool
            AddDevice(new Models.Fridge(Models.State.On));
            AddDevice(new Models.Dehumidifier(Models.State.On));
            AddDevice(new Models.Thermostat(22.0, Models.State.On));
            AddDevice(new Models.SmartLock(1, Models.State.On, false));
            AddDevice(new Models.Sensor(2, Models.State.On, false));
            AddDevice(new Models.SecurityCamera(3, Models.State.On, false));
            AddDevice(new Models.SecurityAlarm(4, Models.State.On, false));
            AddDevice(new Models.Tracker(5, Models.State.On, false, 0));
        }

        public static void AddDevice(Device device)
        {
            Devices.Add(device);

            // Subscribe to the device's Updated event
            device.Updated += OnDeviceUpdated;
        }

        public static void RemoveDevice(Device device)
        {
            Devices.Remove(device);
        }

        public static void UpdateDevice(Device device)
        {
            Device existingDevice = null;

            if (device is Models.Fridge || device is Models.Dehumidifier || device is Models.Thermostat)
            {
                existingDevice = Devices.Find(d => d.DeviceId == device.DeviceId && d.HubId == 0);
            }
            else
            {
                existingDevice = Devices.Find(d => d.HubId == device.HubId);
            }

            // write out the entire device with trace writeline
            if (existingDevice != null)
            {
                Trace.WriteLine(device.ToString());
            }

            if (existingDevice != null)
            {
                existingDevice.Name = device.Name;
                existingDevice.CurrentState = device.CurrentState;
                existingDevice.LastUpdated = device.LastUpdated;

                if (!(existingDevice is Models.Fridge || existingDevice is Models.Dehumidifier || existingDevice is Models.Thermostat))
                {
                    existingDevice.DeviceId = device.DeviceId;
                }

                // Update device-specific properties
                switch (existingDevice)
                {
                    case Models.Fridge fridge when device is Models.Fridge newFridge:
                        fridge.FridgeTemperature = newFridge.FridgeTemperature;
                        fridge.FreezerTemperature = newFridge.FreezerTemperature;
                        break;
                    case Models.Dehumidifier dehumidifier when device is Models.Dehumidifier newDehumidifier:
                        dehumidifier.HumidityLevel = newDehumidifier.HumidityLevel;
                        dehumidifier.WaterLevel = newDehumidifier.WaterLevel;
                        break;
                    case Models.Thermostat thermostat when device is Models.Thermostat newThermostat:
                        thermostat.CurrentTemperature = newThermostat.CurrentTemperature;
                        break;
                    case Models.SmartLock smartLock when device is Models.SmartLock newSmartLock:
                        smartLock.IsLocked = newSmartLock.IsLocked;
                        break;
                    case Models.Sensor sensor when device is Models.Sensor newSensor:
                        sensor.IsTriggered = newSensor.IsTriggered;
                        break;
                    case Models.SecurityCamera securityCamera when device is Models.SecurityCamera newSecurityCamera:
                        securityCamera.MotionDetected = newSecurityCamera.MotionDetected;
                        break;
                    case Models.SecurityAlarm securityAlarm when device is Models.SecurityAlarm newSecurityAlarm:
                        securityAlarm.IsActivated = newSecurityAlarm.IsActivated;
                        break;
                    case Models.Tracker tracker when device is Models.Tracker newTracker:
                        tracker.IsActivated = newTracker.IsActivated;
                        tracker.Location = newTracker.Location;
                        break;
                }

                // Trigger the DeviceUpdated event
                DeviceUpdated?.Invoke(existingDevice);
            }
        }

        private static void OnDeviceUpdated(Device updatedDevice)
        {
            // Trigger the DeviceUpdated event when a device updates itself
            DeviceUpdated?.Invoke(updatedDevice);
        }

        public static Device GetDevice(int deviceId)
        {
            return Devices.Find(d => d.DeviceId == deviceId);
        }
    }
}
