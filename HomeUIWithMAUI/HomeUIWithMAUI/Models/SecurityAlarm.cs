namespace HomeUIWithMAUI.Models
{
    public class SecurityAlarm(int DeviceId, State CurrentState, bool DefaultAlarmState) : DeviceWithHub(4, DeviceId, "Security Alarm", CurrentState)
    {
        public bool IsActivated { get; set; } = DefaultAlarmState;

        public void Activate()
        {
            IsActivated = true;
            LastUpdated = DateTime.Now;
        }

        public void Deactivate()
        {
            IsActivated = false;
            LastUpdated = DateTime.Now;
        }
    }
}
