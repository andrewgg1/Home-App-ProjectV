namespace HomeUIWithMAUI.Models
{
    public class Fridge(State CurrentState) : Device(0, 0, "Fridge", CurrentState)
    {
        public double FridgeTemperature { get; set; } = 4.0;
        public double FreezerTemperature { get; set; } = -2.0;
        //public bool DoorOpen { get; set; }
        //public bool IsCooling { get; set; }



        public void UpdateTemperature(double FridgeTemp, double FreezerTemp)
        {
            FridgeTemperature = FridgeTemp;
            FreezerTemperature = FreezerTemp;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
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
