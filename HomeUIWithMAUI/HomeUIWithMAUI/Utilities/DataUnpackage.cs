using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace HomeUIWithMAUI.Utilities
{
    public static class DataUnpackage
    {
        public static T UnpackData<T>(string jsonData)
        {
            try
            {
                // Deserialize the JSON data to the specified type
                T device = JsonSerializer.Deserialize<T>(jsonData);
                return device;
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization errors
                Console.WriteLine($"Error deserializing JSON data: {ex.Message}");
                return default;
            }
        }
    }
}
