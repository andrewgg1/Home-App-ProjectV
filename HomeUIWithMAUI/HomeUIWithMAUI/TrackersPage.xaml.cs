using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class TrackersPage : ContentPage
    {
        private bool isCarGPSTrackerOn = false;
        private bool isBikeGPSTrackerOn = false;
        private bool isPetGPSTrackerOn = false;

        public TrackersPage()
        {
            InitializeComponent();
        }

        private void OnCarGPSTrackerToggleClicked(object sender, EventArgs e)
        {
            isCarGPSTrackerOn = !isCarGPSTrackerOn;
            CarGPSTrackerStatus.Text = "Status: " + (isCarGPSTrackerOn ? "On" : "Off");
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
        }
    }
}
