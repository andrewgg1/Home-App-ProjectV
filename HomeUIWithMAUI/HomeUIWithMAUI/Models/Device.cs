namespace HomeUIWithMAUI.Models
{
    public abstract class Device
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public State CurrentState { get; set; }
        public string Room { get; set; }
        //public bool IsOn { get; set; }
        public DateTime LastUpdated { get; set; }

        // Optional constructor for base properties
        protected Device(int id, string type, string name, string room, bool isOn)
        {
            Id = id;
            Type = type;
            Name = name;
            Room = room;
            CurrentState = State.Off;
            LastUpdated = DateTime.Now;
        }

        public virtual void UpdateState(State newState)
        {
            CurrentState = newState;
            LastUpdated = DateTime.Now;
        }
    }

    public enum State
    {
        Charging,
        On,
        Off
    }
}

