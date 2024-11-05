namespace HomeUIWithMAUI.Models
{
    public class Tracker(int DeviceId, State CurrentState, bool DefaultTrackerState, double DefaultLocation) : DeviceWithHub(5, DeviceId, "Tracker", CurrentState)
    {
        public bool IsActivated { get; set; } = DefaultTrackerState;
        public double Location { get; set; } = DefaultLocation;

        public void Activate()
        {
            IsActivated = true;
            UpdateState(State.On);
            LastUpdated = DateTime.Now;
        }

        public void Deactivate()
        {
            IsActivated = false;
            UpdateState(State.Off);
            LastUpdated = DateTime.Now;
        }

        public void UpdateLocation(double newLocation)
        {
            IsActivated = true;
            Location = newLocation;
            LastUpdated = DateTime.Now;
        }
    }
}
