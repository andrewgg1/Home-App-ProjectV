using HomeUIWithMAUI.ViewModels;

namespace HomeUIWithMAUI
{
    public partial class LocksPage : ContentPage
    {
        private bool isFrontDoorLocked = true;
        private bool isGarageDoorLocked = false;
        private bool isBackDoorLocked = true;
        private bool isWindowLocked = true;
        private bool isInteriorDoorLocked = true;
        private bool isGateLocked = false;

        public LocksPage()
        {
            InitializeComponent();
            BindingContext = new LocksPageViewModel(); // Bind to LocksViewModel

        }

        private void OnFrontDoorLockToggleClicked(object sender, EventArgs e)
        {
            isFrontDoorLocked = !isFrontDoorLocked;
            FrontDoorLockStatus.Text = "Status: " + (isFrontDoorLocked ? "Locked" : "Unlocked");
        }

        private void OnGarageDoorLockToggleClicked(object sender, EventArgs e)
        {
            isGarageDoorLocked = !isGarageDoorLocked;
            GarageDoorLockStatus.Text = "Status: " + (isGarageDoorLocked ? "Locked" : "Unlocked");
        }

        private void OnBackDoorLockToggleClicked(object sender, EventArgs e)
        {
            isBackDoorLocked = !isBackDoorLocked;
            BackDoorLockStatus.Text = "Status: " + (isBackDoorLocked ? "Locked" : "Unlocked");
        }

        private void OnWindowLockToggleClicked(object sender, EventArgs e)
        {
            isWindowLocked = !isWindowLocked;
            WindowLockStatus.Text = "Status: " + (isWindowLocked ? "Locked" : "Unlocked");
        }

        private void OnInteriorDoorLockToggleClicked(object sender, EventArgs e)
        {
            isInteriorDoorLocked = !isInteriorDoorLocked;
            InteriorDoorLockStatus.Text = "Status: " + (isInteriorDoorLocked ? "Locked" : "Unlocked");
        }

        private void OnGateLockToggleClicked(object sender, EventArgs e)
        {
            isGateLocked = !isGateLocked;
            GateLockStatus.Text = "Status: " + (isGateLocked ? "Locked" : "Unlocked");
        }
    }
}
