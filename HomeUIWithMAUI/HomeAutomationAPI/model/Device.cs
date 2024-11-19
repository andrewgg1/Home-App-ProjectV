namespace HomeAutomationAPI.Models
{
    public class Device
    {
        public int Id { get; set; } // Unique ID
        public string Name { get; set; } // Device name (e.g., "Front Door Lock")
        public string Type { get; set; } // Type of device (e.g., "Lock", "Sensor", "Camera")
        public bool IsOn { get; set; } // Device state (true = on, false = off)

        public Device(string name, string type)
        {
            Name = name;
            Type = type;
            IsOn = false;
        }

        public void Toggle()
        {
            IsOn = !IsOn; // Toggle the device state
        }
    }
}
