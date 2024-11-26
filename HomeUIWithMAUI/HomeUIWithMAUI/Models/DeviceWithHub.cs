namespace HomeUIWithMAUI.Models
{
    public abstract class DeviceWithHub(int DeviceId, int HubId, string HubName, State state) : Device(DeviceId, HubId, "Hub", state)
    {
        public string HubName { get; set; } = HubName;
        //public int HubId { get; set; }


    }
}

