using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace HomeUIWithMAUI.Utilities
{
    public static class DataPackage
    {
        public static string PackData(string data)
        {
            try
            {
                var parts = data.Split(',');

                if (parts.Length < 4)
                {
                    return "{\"error\": \"Invalid data format\"}";
                }

                int hubID = int.Parse(parts[0].Trim());
                int deviceID = int.Parse(parts[1].Trim());
                string name = parts[2].Trim();
                int isOn = int.Parse(parts[3].Trim());

                object deviceObject = name switch
                {
                    "SmartFridge" when parts.Length == 6 => new
                    {
                        HubID = hubID,
                        DeviceID = deviceID,
                        Name = name,
                        IsOn = isOn,
                        FridgeTemp = int.Parse(parts[4].Trim()),
                        FreezerTemp = int.Parse(parts[5].Trim())
                    },
                    "SmartDehumidifier" when parts.Length == 6 => new
                    {
                        HubID = hubID,
                        DeviceID = deviceID,
                        Name = name,
                        IsOn = isOn,
                        WaterLevel = int.Parse(parts[4].Trim()),
                        Humidity = int.Parse(parts[5].Trim())
                    },
                    "SmartThermostat" when parts.Length == 5 => new
                    {
                        HubID = hubID,
                        DeviceID = deviceID,
                        Name = name,
                        IsOn = isOn,
                        ThermostatTemp = int.Parse(parts[4].Trim())
                    },
                    _ => new { error = "Unknown or invalid device data format" }
                };

                // Serialize the device object into a JSON string
                return JsonSerializer.Serialize(deviceObject);
            }
            catch (Exception ex)
            {
                // Handle errors in parsing or serialization
                Console.WriteLine($"Error processing data: {ex.Message}");
                return "{\"error\": \"Error processing data\"}";
            }
        }
    }
}
