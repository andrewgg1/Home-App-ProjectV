namespace HomeUIWithMAUI.Models
{
    public class SecurityCamera : DeviceWithHub
    {
        public bool motionDetected { get; set; }

        public SecurityCamera(int id, string name, string room, bool isOn, string hubName, string hubId, bool motionDetected)
            : base(id, "SecurityCamera", name, room, isOn, hubName, hubId)
        {
        }

        public void DetectMotion()
        {
            motionDetected = true;
            LastUpdated = DateTime.Now;
        }

        public void ResetSecurityCamera()
        {
            motionDetected = false;
            LastUpdated = DateTime.Now;
        }
    }
}
