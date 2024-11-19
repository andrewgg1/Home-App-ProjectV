namespace HomeUIWithMAUI.Models
{
    public class Sensor : DeviceWithHub
    {
        public bool isTriggered { get; set; }

        public Sensor(int id, string name, string room, bool isOn, string hubName, string hubId, bool isTriggered)
            : base(id, "Sensor", name, room, isOn, hubName, hubId)
        {
        }

        public void TriggerSensor()
        {
            isTriggered = true;
            LastUpdated = DateTime.Now;
        }

        public void ResetSensor()
        {
            isTriggered = false;
            LastUpdated = DateTime.Now;
        }
    }
}
