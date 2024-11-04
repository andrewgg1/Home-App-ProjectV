namespace HomeUIWithMAUI.Models
{
    public class Thermostat : Device
    {
        public double CurrentTemperature { get; set; }
        public double DesiredTemperature { get; set; }
        public string Mode { get; set; }

        public Thermostat(int id, string name, string room, bool isOn, double currentTemp, double desiredTemp, string mode)
            : base(id, "Thermostat", name, room, isOn)
        {
            CurrentTemperature = currentTemp;
            DesiredTemperature = desiredTemp;
            Mode = mode;
        }

        public void SetTemperature(double temperature)
        {
            DesiredTemperature = temperature;
            LastUpdated = DateTime.Now;
        }

        public void SetMode(string mode)
        {
            Mode = mode;
            LastUpdated = DateTime.Now;
        }
    }
}
