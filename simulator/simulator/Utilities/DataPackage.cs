using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace simulator.Utilities
{
    public static class DataPackage
    {
        public static string PackData<T>(T device)
        {
            try
            {
                // Serialize the device object into a JSON string
                string jsonData = JsonSerializer.Serialize<T>(device);
                return jsonData;
            }
            catch (JsonException ex)
            {
                // Handle JSON serialization errors
                Console.WriteLine($"Error serializing JSON data: {ex.Message}");
                return default;
            }
        }
    }
}
