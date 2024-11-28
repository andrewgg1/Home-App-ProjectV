namespace HomeUIWithMAUI.Models
{
    public class SecurityAlarm : DeviceWithHub
    {

        public SecurityAlarm() : base(4, 0, "Security Alarm", State.Off)
        {
        }

        public SecurityAlarm(int deviceId, State currentState, bool defaultAlarmState)
            : base(4, deviceId, "Security Alarm", currentState)
        {
            IsActivated = defaultAlarmState;
        }
        public bool IsActivated { get; set; }

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
