using Microsoft.Maui.Controls;
using HomeUIWithMAUI.Connection;
using HomeUIWithMAUI.Models;
using Pool = HomeUIWithMAUI.DevicePool.DevicePool;
using Device = HomeUIWithMAUI.Models.Device;

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

        private Models.SmartLock _frontDoorLock;

        public LocksPage()
        {
            InitializeComponent();

            _frontDoorLock = Pool.Devices.OfType<Models.SmartLock>().FirstOrDefault(d => d.HubId == 1);
        }

        private void OnFrontDoorLockToggleClicked(object sender, EventArgs e)
        {
            //isFrontDoorLocked = !isFrontDoorLocked;
            _frontDoorLock.ToggleLock();
            FrontDoorLockStatus.Text = "Status: " + (_frontDoorLock.IsLocked ? "Locked" : "Unlocked");
            // popup message to show the status of the lock
            DisplayAlert("Front Door Lock", "Front door is now " + (_frontDoorLock.IsLocked ? "locked" : "unlocked"), "OK");
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
