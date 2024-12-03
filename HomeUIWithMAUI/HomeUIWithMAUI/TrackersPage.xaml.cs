using Microsoft.Maui.Controls;
using HomeUIWithMAUI.Connection;
using HomeUIWithMAUI.Models;
using Pool = HomeUIWithMAUI.DevicePool.DevicePool;
using Device = HomeUIWithMAUI.Models.Device;

namespace HomeUIWithMAUI
{
    public partial class TrackersPage : ContentPage
    {
        private bool isCarGPSTrackerOn = false;
        private bool isBikeGPSTrackerOn = false;
        private bool isPetGPSTrackerOn = false;

        private Models.Tracker _carGPSTracker;

        public TrackersPage()
        {
            InitializeComponent();

            _carGPSTracker = Pool.Devices.OfType<Models.Tracker>().FirstOrDefault(d => d.HubId == 5);
        }

        private void OnCarGPSTrackerToggleClicked(object sender, EventArgs e)
        {
            //isCarGPSTrackerOn = !isCarGPSTrackerOn;
            _carGPSTracker.ToggleTracker();
            CarGPSTrackerStatus.Text = "Status: " + (_carGPSTracker.IsActivated ? "On" : "Off");
            // popup message to show the status of the tracker
            DisplayAlert("Car GPS Tracker", "Car GPS tracker is now " + (_carGPSTracker.IsActivated ? "on" : "off"), "OK");
        }

        private void OnBikeGPSTrackerToggleClicked(object sender, EventArgs e)
        {
            isBikeGPSTrackerOn = !isBikeGPSTrackerOn;
            BikeGPSTrackerStatus.Text = "Status: " + (isBikeGPSTrackerOn ? "On" : "Off");
        }

        private void OnPetGPSTrackerToggleClicked(object sender, EventArgs e)
        {
            isPetGPSTrackerOn = !isPetGPSTrackerOn;
            PetGPSTrackerStatus.Text = "Status: " + (isPetGPSTrackerOn ? "On" : "Off");
        } //
    }
}
