namespace HomeUIWithMAUI.Models
{
    public class Dehumidifier : Device
    {
        public int HumidityLevel { get; set; } // Current room humidity level
        public int WaterLevel { get; set; }
        //public int DesiredHumidity { get; set; } // Target humidity set by the user
        //public string Mode { get; set; } // Modes like "Continuous", "Auto", "Eco"
        //public int FanSpeed { get; set; } // Levels like "Low", "Medium", "High"

        public Dehumidifier(int id, string name, string room)
            : base(id, "Dehumidifier", State.On)
        {
            HumidityLevel = 40; // Default humidity level
            WaterLevel = 40;
            //Mode = "Auto";  // Default mode
            //DesiredHumidity = 50; // Default target humidity
            //FanSpeed = 1; // Default fan speed (Low)
        }

        public void UpdateHumidityLevel(int currentHumidity)
        {
            HumidityLevel = currentHumidity;
            LastUpdated = DateTime.Now;
        }


        public void UpdateWaterLevel(int waterLevel)
        {
            WaterLevel = waterLevel;
            LastUpdated = DateTime.Now;
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
