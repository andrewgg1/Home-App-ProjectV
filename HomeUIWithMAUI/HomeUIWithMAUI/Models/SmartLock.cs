namespace HomeUIWithMAUI.Models
{
    public class SmartLock(int DeviceId, State CurrentState, bool DefaultLockState) : DeviceWithHub(1, DeviceId, "Smart Lock", CurrentState)
    {
        public bool IsLocked { get; set; } = DefaultLockState;

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
