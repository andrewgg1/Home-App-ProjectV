namespace HomeUIWithMAUI.Models
{
    public class SmartLock : DeviceWithHub
    {
        public bool IsLocked { get; set; }

        public SmartLock(int id, string name, string room, bool isOn, string hubName, string hubId, bool isLocked)
            : base(id, "SmartLock", name, room, isOn, hubName, hubId)
        {
            IsLocked = isLocked;
        }

        public void Lock()
        {
            IsLocked = true;
            LastUpdated = DateTime.Now;
        }

        public void Unlock()
        {
            IsLocked = false;
            LastUpdated = DateTime.Now;
        }
    }
}
