using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Device = HomeUIWithMAUI.Models.Device;
using HomeUIWithMAUI.Models;

namespace HomeUIWithMAUI.Utilities
{
    public static class DataUnpackageCSV
    {
        public static (bool IsValid, Device Device) ValidateMessageAndCreateDevice(string message)
        {
            try
            {
                // Split the message into parts and trim any whitespace
                var parts = message.Split(',').Select(p => p.Trim()).ToArray();

                // Ensure there are enough parts to proceed
                if (parts.Length < 4)
                    return (false, null);

                // Common fields
                int hubId = int.Parse(parts[0]);
                int deviceId = int.Parse(parts[1]);
                string deviceType = parts[2];
                bool isOn = parts[3] == "1";
                State currentState = isOn ? State.On : State.Off;

                // Device variable to hold the created device
                Device device = null;

                switch (deviceType)
                {
                    case "SmartFridge":
                        if (parts.Length != 6)
                            return (false, null);

                        int fridgeTemp = int.Parse(parts[4]);
                        int freezerTemp = int.Parse(parts[5]);

                        // Instantiate the Fridge device
                        device = new Models.Fridge(currentState)
                        {
                            HubId = hubId,
                            DeviceId = deviceId,
                            Name = deviceType,
                            FridgeTemperature = fridgeTemp,
                            FreezerTemperature = freezerTemp
                        };
                        break;

                    case "SmartDehumidifier":
                        if (parts.Length != 6)
                            return (false, null);

                        int waterLevel = int.Parse(parts[4]);
                        int humidityLevel = int.Parse(parts[5]);

                        device = new Models.Dehumidifier(currentState)
                        {
                            HubId = hubId,
                            DeviceId = deviceId,
                            Name = deviceType,
                            WaterLevel = waterLevel,
                            HumidityLevel = humidityLevel
                        };
                        break;

                    case "SmartThermostat":
                        if (parts.Length != 5)
                            return (false, null);

                        double currentTemp = double.Parse(parts[4]);

                        device = new Models.Thermostat(currentTemp, currentState)
                        {
                            HubId = hubId,
                            DeviceId = deviceId,
                            Name = deviceType
                        };
                        break;

                    case "SmartLock":
                        device = new Models.SmartLock(deviceId, currentState, DefaultLockState: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartSensor":
                        device = new Models.Sensor(deviceId, currentState, DefaultTrigger: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartCamera":
                        device = new Models.SecurityCamera(deviceId, currentState, MotionDetected: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartAlarm":
                        device = new Models.SecurityAlarm(deviceId, currentState, DefaultAlarmState: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartTracker":
                        if (parts.Length != 5)
                            return (false, null);

                        int location = int.Parse(parts[4]);

                        device = new Models.Tracker(deviceId, currentState, DefaultTrackerState: true, location)
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    default:
                        // Unknown device type
                        return (false, null);
                }

                return (true, device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing message: {ex.Message}");
                return (false, null);
            }
        }
    }
}
