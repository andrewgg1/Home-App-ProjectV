using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class SensorsPage : ContentPage
    {
        private bool isMotionSensorActive = false;
        private bool isGlassBreakSensorActive = false;
        private bool isDoorWindowSensorActive = false;
        private bool isGarageDoorSensorActive = false;
        private bool isWaterLeakSensorActive = false;

        public SensorsPage()
        {
            InitializeComponent();
        }

        private void OnMotionSensorToggleClicked(object sender, EventArgs e)
        {
            isMotionSensorActive = !isMotionSensorActive;
            MotionSensorStatus.Text = "Status: " + (isMotionSensorActive ? "Active" : "Inactive");
        }

        private void OnGlassBreakSensorToggleClicked(object sender, EventArgs e)
        {
            isGlassBreakSensorActive = !isGlassBreakSensorActive;
            GlassBreakSensorStatus.Text = "Status: " + (isGlassBreakSensorActive ? "Active" : "Inactive");
        }

        private void OnDoorWindowSensorToggleClicked(object sender, EventArgs e)
        {
            isDoorWindowSensorActive = !isDoorWindowSensorActive;
            DoorWindowSensorStatus.Text = "Status: " + (isDoorWindowSensorActive ? "Active" : "Inactive");
        }

        private void OnGarageDoorSensorToggleClicked(object sender, EventArgs e)
        {
            isGarageDoorSensorActive = !isGarageDoorSensorActive;
            GarageDoorSensorStatus.Text = "Status: " + (isGarageDoorSensorActive ? "Active" : "Inactive");
        }

        private void OnWaterLeakSensorToggleClicked(object sender, EventArgs e)
        {
            isWaterLeakSensorActive = !isWaterLeakSensorActive;
            WaterLeakSensorStatus.Text = "Status: " + (isWaterLeakSensorActive ? "Active" : "Inactive");
        }
    }
}
