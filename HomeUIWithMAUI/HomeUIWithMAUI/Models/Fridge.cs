namespace HomeUIWithMAUI.Models
{
    public class Fridge : Device
    {
        public double FridgeTemperature { get; set; }
        public double FreezerTemperature { get; set; }
        //public bool DoorOpen { get; set; }
        //public bool IsCooling { get; set; }

        public Fridge(int id, string name, string room)
            : base(id, "Fridge", name, room, isOn: true)
        {
            FridgeTemperature = 4.0; // Assumption: Default fridge temp in °C
            FreezerTemperature = -2.0;
            //DoorOpen = false;
            //IsCooling = true;
        }

        public void UpdateTemperature(double currentTemp, double targetTemp)
        {
            FridgeTemperature = currentTemp;
            FreezerTemperature = targetTemp;
            LastUpdated = DateTime.Now;
        }

        //public void ToggleDoor(bool open)
        //{
        //    DoorOpen = open;
        //    LastUpdated = DateTime.Now;
        //}

        //public void ToggleCooling(bool cooling)
        //{
        //    IsCooling = cooling;
        //    UpdateStatus(IsOn);
        //}
    }
}
