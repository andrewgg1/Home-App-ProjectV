namespace HomeUIWithMAUI.Models
{
    public class SecurityAlarm : DeviceWithHub
    {
        public bool isActivated { get; set; }

        public SecurityAlarm(int id, string name, string room, bool isOn, string hubName, string hubId, bool isActivated)
            : base(id, "SecurityAlarm", name, room, isOn, hubName, hubId)
        {
        }

        public void Activate()
        {
            isActivated = true;
            LastUpdated = DateTime.Now;
        }

        public void Deactivate()
        {
            isActivated = false;
            LastUpdated = DateTime.Now;
        }
    }
}
