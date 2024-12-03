namespace HomeUIWithMAUI.Models
{
    public class Thermostat(double CurrentTemp, State CurrentState) : Device(0, 2, "Thermostat", CurrentState)
    {
        public double CurrentTemperature { get; set; } = CurrentTemp;

        public void SetTemperature(double temperature)
        {
            CurrentTemperature = temperature;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }


    }
}
