namespace HomeUIWithMAUI.Models
{
    public class Thermostat
    {
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get; private set; }
        public bool IsOn { get; private set; }

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
    }
}
