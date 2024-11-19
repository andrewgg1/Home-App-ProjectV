namespace HomeUIWithMAUI.Models
{
    public class Tracker : DeviceWithHub
    {
        public bool isActivated { get; set; }
        public double location { get; set; }

        public Tracker(int id, string name, string room, bool isOn, string hubName, string hubId, bool isActivated)
            : base(id, "Tracker", name, room, isOn, hubName, hubId)
        {
        }

        public void Activate()
        {
            isActivated = true;
            UpdateState(State.On);
            LastUpdated = DateTime.Now;
        }

        public void Deactivate()
        {
            isActivated = false;
            UpdateState(State.Off);
            LastUpdated = DateTime.Now;
        }

        public void UpdateLocation(double newLocation)
        {
            isActivated = true;
            location = newLocation;
            LastUpdated = DateTime.Now;
        }
    }
}
