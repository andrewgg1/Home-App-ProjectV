namespace HomeUIWithMAUI.Models
{
    public class Sensor(int DeviceId, State CurrentState, bool DefaultTrigger) : DeviceWithHub(2, DeviceId, "Sensor", CurrentState)
    {
        public bool IsTriggered { get; set; } = DefaultTrigger;

        public void TriggerSensor()
        {
            IsTriggered = true;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }

        public void ResetSensor()
        {
            IsTriggered = false;
            LastUpdated = DateTime.Now;
            OnUpdated(); // Notify that the device has been updated
        }
    }
}
