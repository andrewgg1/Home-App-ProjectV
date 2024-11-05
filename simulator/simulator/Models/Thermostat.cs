using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator.Models
{
    public class Thermostat
    {
        private static Random random = new Random();

        public string Id { get; set; } = GenerateRandomId();
        public string Name { get; set; } = "Default Thermostat";
        public int CurrentTemperature { get; set; } = 20;
        public int DesiredTemperature { get; set; } = 20;
        public string Mode { get; set; } = "Off";
        public bool IsOn { get; set; } = false;
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        private static string GenerateRandomId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void PrintDetails()
        {
            // clear screen
            Console.Clear();
            Console.WriteLine("Thermostat Details:");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Current Temperature: {CurrentTemperature}°C");
            Console.WriteLine($"Desired Temperature: {DesiredTemperature}°C");
            Console.WriteLine($"Mode: {Mode}");
            Console.WriteLine($"Is On: {IsOn}");
            Console.WriteLine($"Last Updated: {LastUpdated:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
