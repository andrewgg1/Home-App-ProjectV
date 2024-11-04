namespace HomeUIWithMAUI.Models
{
    public abstract class DeviceWithHub : Device
    {
        public string HubName { get; set; }
        public string HubId { get; set; }

        protected DeviceWithHub(int id, string type, string name, string room, bool isOn, string hubName, string hubId)
            : base(id, type, name, room, isOn)
        {
            HubName = hubName;
            HubId = hubId;
        }
    }
}

