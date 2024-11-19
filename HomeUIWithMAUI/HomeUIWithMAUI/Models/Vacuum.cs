namespace HomeUIWithMAUI.Models
{
    public class Vacuum : Device
    {
        public string Mode { get; set; } // Modes like "Eco", "Standard", "Max"
        public int BatteryLevel { get; set; }
        public bool IsDocked { get; set; }

        public Vacuum(int id, string name, string room)
            : base(id, "Vacuum", name, room, isOn: false)
        {
            Mode = "Standard";  // Default mode
            BatteryLevel = 100; // Assume starting with a full charge
            IsDocked = true;
        }

        public void UpdateBatteryLevel(int level)
        {
            BatteryLevel = level;
            LastUpdated = DateTime.Now;
        }

        public void SetMode(string mode)
        {
            Mode = mode;
            LastUpdated = DateTime.Now;
        }

        public void Dock(bool docked)
        {
            IsDocked = docked;
            UpdateState(docked ? State.Off : State.On); // If docked, it's off. If not docked, it's on.
        }

        public void StartCleaning()
        {
            if (BatteryLevel > 0 && IsDocked == false)
            {
                UpdateState(State.On);
                LastUpdated = DateTime.Now;
            }
        }

        public void StopCleaning()
        {
            UpdateState(State.Off);
            LastUpdated = DateTime.Now;
        }
    }
}
