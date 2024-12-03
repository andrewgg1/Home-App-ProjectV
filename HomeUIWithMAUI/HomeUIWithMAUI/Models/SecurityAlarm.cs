namespace HomeUIWithMAUI.Models
{
    public class SecurityAlarm(int DeviceId, State CurrentState, bool DefaultAlarmState) : DeviceWithHub(4, DeviceId, "Security Alarm", CurrentState)
    {
        public bool IsActivated { get; set; } = DefaultAlarmState;

        public void Activate()
        {
            IsActivated = true;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }

        public void Deactivate()
        {
            IsActivated = false;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }
    }
}
