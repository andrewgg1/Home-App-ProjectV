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
                existingDevice.Name = device.Name;
                existingDevice.CurrentState = device.CurrentState;
                existingDevice.LastUpdated = device.LastUpdated;

                switch (existingDevice)
                {
                    case Models.Fridge fridge:
                        if (device is Models.Fridge newFridge)
                        {
                            fridge.FridgeTemperature = newFridge.FridgeTemperature;
                            fridge.FreezerTemperature = newFridge.FreezerTemperature;
                        }
                        break;
                    case Models.Dehumidifier dehumidifier:
                        if (device is Models.Dehumidifier newDehumidifier)
                        {
                            dehumidifier.HumidityLevel = newDehumidifier.HumidityLevel;
                            dehumidifier.WaterLevel = newDehumidifier.WaterLevel;
                        }
                        break;
                    case Models.Thermostat thermostat:
                        if (device is Models.Thermostat newThermostat)
                        {
                            thermostat.CurrentTemperature = newThermostat.CurrentTemperature;
                        }
                        break;
                    case Models.SmartLock smartLock:
                        if (device is Models.SmartLock newSmartLock)
                        {
                            smartLock.IsLocked = newSmartLock.IsLocked;
                        }
                        break;
                    case Models.Sensor sensor:
                        if (device is Models.Sensor newSensor)
                        {
                            sensor.IsTriggered = newSensor.IsTriggered;
                        }
                        break;
                    case Models.SecurityCamera securityCamera:
                        if (device is Models.SecurityCamera newSecurityCamera)
                        {
                            securityCamera.MotionDetected = newSecurityCamera.MotionDetected;
                        }
                        break;
                    case Models.SecurityAlarm securityAlarm:
                        if (device is Models.SecurityAlarm newSecurityAlarm)
                        {
                            securityAlarm.IsActivated = newSecurityAlarm.IsActivated;
                        }
                        break;
                    case Models.Tracker tracker:
                        if (device is Models.Tracker newTracker)
                        {
                            tracker.IsActivated = newTracker.IsActivated;
                            tracker.Location = newTracker.Location;
                        }
                        break;
                }
            }
        }
        public static Device? GetDevice(int deviceId)
        {
            return Devices.Find(d => d.DeviceId == deviceId);
        }
    }
}
