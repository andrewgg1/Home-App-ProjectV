using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeUIWithMAUI.Models;
using Device = HomeUIWithMAUI.Models.Device;

namespace HomeUIWithMAUI.Utilities
{
    public static class DataPackageCSV
    {
        public static string PackData(Device device)
        {
            // Start with common fields
            string csv = $"{device.HubId}, {device.DeviceId}, {device.Name}, {(device.CurrentState == State.On ? "1" : "0")}";

            // Append device-specific data
            switch (device)
            {
                case Fridge fridge:
                    csv += $", {fridge.FridgeTemperature}, {fridge.FreezerTemperature}";
                    break;

                case Dehumidifier dehumidifier:
                    csv += $", {dehumidifier.WaterLevel}, {dehumidifier.HumidityLevel}";
                    break;

                case Thermostat thermostat:
                    csv += $", {thermostat.CurrentTemperature}";
                    break;

                case SmartLock smartLock:
                    csv += $", {(smartLock.IsLocked ? "1" : "0")}";
                    break;

                case Sensor sensor:
                    csv += $", {(sensor.IsTriggered ? "1" : "0")}";
                    break;

                case SecurityCamera camera:
                    csv += $", {(camera.MotionDetected ? "1" : "0")}";
                    break;

                case SecurityAlarm alarm:
                    csv += $", {(alarm.IsActivated ? "1" : "0")}";
                    break;

                case Tracker tracker:
                    csv += $", {tracker.Location}";
                    break;

                default:
                    // Handle unknown device types if necessary
                    break;
            }

            return csv;
        }
    }
}
