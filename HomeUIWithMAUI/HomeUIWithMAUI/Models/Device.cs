namespace HomeUIWithMAUI.Models
{
    public abstract class Device
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public bool IsOn { get; set; }
        public DateTime LastUpdated { get; set; }

        // Optional constructor for base properties
        protected Device(int id, string type, string name, string room, bool isOn)
        {
            Id = id;
            Type = type;
            Name = name;
            Room = room;
            IsOn = isOn;
            LastUpdated = DateTime.Now;
        }

        public virtual void UpdateStatus(bool isOn)
        {
            IsOn = isOn;
            LastUpdated = DateTime.Now;
        }
    }
}

