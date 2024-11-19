namespace HomeAutomationAPI.Models
{
    public class Thermostat
    {
        public double CurrentTemperature { get; private set; } // Current temperature
        public double TargetTemperature { get; private set; } // Desired temperature
        public bool IsOn { get; private set; } // Thermostat power state

        public Thermostat()
        {
            CurrentTemperature = 22.0;
            TargetTemperature = 22.0;
            IsOn = true;
        }

        public void SetTargetTemperature(double temperature)
        {
            TargetTemperature = temperature;
        }

        public void TogglePower()
        {
            IsOn = !IsOn;
        }

        public void UpdateTemperature(double newTemperature)
        {
            CurrentTemperature = newTemperature;
        }
    }
}
