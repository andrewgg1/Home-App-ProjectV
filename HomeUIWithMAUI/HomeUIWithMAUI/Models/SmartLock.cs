namespace HomeUIWithMAUI.Models
{
    public class SmartLock : Device
    {
        public SmartLock(int deviceId, State currentState, bool defaultLockState)
            : base(1, deviceId, "Smart Lock", currentState)
        {
            IsLocked = defaultLockState;
        }

        // Parameterless constructor for EF Core
        public SmartLock() : base(1, 0, "Smart Lock", State.Off) { }

        public bool IsLocked { get; set; }

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
