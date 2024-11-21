namespace HomeUIWithMAUI.Models
{
    public class Thermostat : Device
    {
        public double CurrentTemperature { get; set; }
        //public double DesiredTemperature { get; set; }
        //public string Mode { get; set; }

        public Thermostat(int id, string name, string room, bool isOn, double currentTemp, string mode)
            : base(id, "Thermostat", State.On)
        {
            CurrentTemperature = currentTemp;
            //Mode = mode;
        }

        public void SetTemperature(double temperature)
        {
            CurrentTemperature = temperature;
            LastUpdated = DateTime.Now;
        }


    }
}
