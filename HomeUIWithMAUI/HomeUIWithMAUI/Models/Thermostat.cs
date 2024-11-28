namespace HomeUIWithMAUI.Models
{
    public class Thermostat : Device
    {
        public Thermostat(double currentTemp, State currentState)
            : base(0, 2, "Thermostat", currentState)
        {
            CurrentTemperature = currentTemp;
        }

        // Parameterless constructor for EF Core
        public Thermostat() : base(0, 2, "Thermostat", State.Off) { }
        public double CurrentTemperature { get; set; }

        public void SetTemperature(double temperature)
        {
            CurrentTemperature = temperature;
            LastUpdated = DateTime.Now;
        }


    }
}
