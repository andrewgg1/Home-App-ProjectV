namespace HomeUIWithMAUI.Models
{
    public class Dehumidifier(State currentState) : Device(0, 1, "Dehumidifier", currentState)
    {
        public int HumidityLevel { get; set; } = 40; // Default humidity level
        public int WaterLevel { get; set; } = 40;

        public void UpdateHumidityLevel(int currentHumidity)
        {
            HumidityLevel = currentHumidity;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }


        public void UpdateWaterLevel(int waterLevel)
        {
            WaterLevel = waterLevel;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }

        //public void SetDesiredHumidity(int humidity)
        //{
        //    DesiredHumidity = humidity;
        //    LastUpdated = DateTime.Now;
        //}
        //public void SetMode(string mode)
        //{
        //    Mode = mode;
        //    LastUpdated = DateTime.Now;
        //}

        //public void AdjustFanSpeed(int speed)
        //{
        //    FanSpeed = speed;
        //    LastUpdated = DateTime.Now;
        //}


    }
}
