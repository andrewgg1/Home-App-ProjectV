namespace HomeUIWithMAUI.Models
{
    public class SecurityCamera(int DeviceId, State CurrentState, bool MotionDetected) : DeviceWithHub(3, DeviceId, "Security Camera", CurrentState)
    {
        public bool MotionDetected { get; set; } = MotionDetected;

        public void DetectMotion()
        {
            MotionDetected = true;
            LastUpdated = DateTime.Now;
        }

        public void ResetSecurityCamera()
        {
            MotionDetected = false;
            LastUpdated = DateTime.Now;
        }
    }
}
