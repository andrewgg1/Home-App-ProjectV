namespace HomeUIWithMAUI.Models
{
    public class SmartLock(int DeviceId, State CurrentState, bool DefaultLockState) : DeviceWithHub(1, DeviceId, "Smart Lock", CurrentState)
    {
        public bool IsLocked { get; set; } = DefaultLockState;

        public void ToggleLock()
        {
            IsLocked = !IsLocked;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }
    }
}
