namespace HomeUIWithMAUI.Models
{
    public abstract class Device
    {
        public int HubId { get; set; }
        public int DeviceId { get; set; }
        //public string Type { get; set; }
        public string Name { get; set; }
        public State CurrentState { get; set; }
        //public string Room { get; set; }
        //public bool IsOn { get; set; }
        public DateTime LastUpdated { get; set; }

        // Optional constructor for base properties
        protected Device(int DeviceId, int HubId, string name, State CurrentState)
        {
            this.DeviceId = DeviceId;
            this.HubId = HubId;
            Name = name;
            this.CurrentState = CurrentState;
            LastUpdated = DateTime.Now;
        }

        public virtual void UpdateState(State newState)
        {
            this.CurrentState = newState;
            LastUpdated = DateTime.Now;
        }
    }

    public enum State
    {
        Off,
        On
    }
}

