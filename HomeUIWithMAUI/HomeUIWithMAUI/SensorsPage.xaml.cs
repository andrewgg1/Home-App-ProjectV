using Microsoft.Maui.Controls;
using System;

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
            MotionSensorNotification.Text = isMotionSensorActive ? "Monitoring for motion..." : "No motion detected.";
            MotionSensorNotification.TextColor = isMotionSensorActive ? Colors.Orange : Colors.Green;
        }

        private void OnGlassBreakSensorToggleClicked(object sender, EventArgs e)
        {
            isGlassBreakSensorActive = !isGlassBreakSensorActive;
            GlassBreakSensorStatus.Text = "Status: " + (isGlassBreakSensorActive ? "Active" : "Inactive");
            GlassBreakSensorNotification.Text = isGlassBreakSensorActive ? "Listening for glass breaks..." : "No glass break detected.";
            GlassBreakSensorNotification.TextColor = isGlassBreakSensorActive ? Colors.Orange : Colors.Green;
        }

        private void OnDoorWindowSensorToggleClicked(object sender, EventArgs e)
        {
            isDoorWindowSensorActive = !isDoorWindowSensorActive;
            DoorWindowSensorStatus.Text = "Status: " + (isDoorWindowSensorActive ? "Active" : "Inactive");
            DoorWindowSensorNotification.Text = isDoorWindowSensorActive ? "Monitoring doors and windows..." : "All doors and windows are secure.";
            DoorWindowSensorNotification.TextColor = isDoorWindowSensorActive ? Colors.Orange : Colors.Green;
        }

        private void OnGarageDoorSensorToggleClicked(object sender, EventArgs e)
        {
            isGarageDoorSensorActive = !isGarageDoorSensorActive;
            GarageDoorSensorStatus.Text = "Status: " + (isGarageDoorSensorActive ? "Active" : "Inactive");
            GarageDoorSensorNotification.Text = isGarageDoorSensorActive ? "Monitoring garage door..." : "Garage door is closed.";
            GarageDoorSensorNotification.TextColor = isGarageDoorSensorActive ? Colors.Orange : Colors.Green;
        }

        private void OnWaterLeakSensorToggleClicked(object sender, EventArgs e)
        {
            isWaterLeakSensorActive = !isWaterLeakSensorActive;
            WaterLeakSensorStatus.Text = "Status: " + (isWaterLeakSensorActive ? "Active" : "Inactive");
            WaterLeakSensorNotification.Text = isWaterLeakSensorActive ? "Monitoring for water leaks..." : "No water leak detected.";
            WaterLeakSensorNotification.TextColor = isWaterLeakSensorActive ? Colors.Orange : Colors.Green;
        }
    }
}
