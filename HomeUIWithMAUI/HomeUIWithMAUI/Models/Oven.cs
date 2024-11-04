namespace HomeUIWithMAUI.Models
{
    public class Oven : Device
    {
        public int Temperature { get; set; }
        public string Mode { get; set; } // e.g., "Bake", "Broil", "Convection"
        public int Timer { get; set; }   // in minutes

        public Oven(int id, string name, string room)
            : base(id, "Oven", name, room, isOn: false)
        {
            Temperature = 0;
            Mode = "Off";
            Timer = 0;
        }

        public void StartPreheat(int targetTemperature)
        {
            Temperature = targetTemperature;
            Mode = "Preheat";
            UpdateStatus(true);
        }

        public void SetMode(string mode)
        {
            Mode = mode;
            UpdateStatus(true);
        }

        public void SetTimer(int minutes)
        {
            Timer = minutes;
            UpdateStatus(IsOn);
        }

        public void Stop()
        {
            Temperature = 0;
            Mode = "Off";
            Timer = 0;
            UpdateStatus(false);
        }
    }
}
