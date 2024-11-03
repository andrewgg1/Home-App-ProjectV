using Microsoft.Maui.Controls;

namespace HomeUIWithMAUI
{
    public partial class CamerasPage : ContentPage
    {
        private bool isFrontDoorbellCameraOn = false;
        private bool isBackyardCameraOn = false;
        private bool isSideGateCameraOn = false;
        private bool isGarageCameraOn = false;
        private bool isDrivewayCameraOn = false;

        public CamerasPage()
        {
            InitializeComponent();
        }

        private void OnFrontDoorbellCameraToggleClicked(object sender, EventArgs e)
        {
            isFrontDoorbellCameraOn = !isFrontDoorbellCameraOn;
            FrontDoorbellCameraStatus.Text = "Status: " + (isFrontDoorbellCameraOn ? "On" : "Off");
        }

        private void OnBackyardCameraToggleClicked(object sender, EventArgs e)
        {
            isBackyardCameraOn = !isBackyardCameraOn;
            BackyardCameraStatus.Text = "Status: " + (isBackyardCameraOn ? "On" : "Off");
        }

        private void OnSideGateCameraToggleClicked(object sender, EventArgs e)
        {
            isSideGateCameraOn = !isSideGateCameraOn;
            SideGateCameraStatus.Text = "Status: " + (isSideGateCameraOn ? "On" : "Off");
        }

        private void OnGarageCameraToggleClicked(object sender, EventArgs e)
        {
            isGarageCameraOn = !isGarageCameraOn;
            GarageCameraStatus.Text = "Status: " + (isGarageCameraOn ? "On" : "Off");
        }

        private void OnDrivewayCameraToggleClicked(object sender, EventArgs e)
        {
            isDrivewayCameraOn = !isDrivewayCameraOn;
            DrivewayCameraStatus.Text = "Status: " + (isDrivewayCameraOn ? "On" : "Off");
        }
    }
}
