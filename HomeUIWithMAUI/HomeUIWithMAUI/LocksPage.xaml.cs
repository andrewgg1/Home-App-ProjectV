using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace HomeUIWithMAUI
{
    public partial class LocksPage : ContentPage
    {
        private Dictionary<string, (bool IsLocked, string LastAction)> locksStatus = new Dictionary<string, (bool, string)>
        {
            { "FrontDoor", (true, "Locked 3 hours ago") },
            { "GarageDoor", (false, "Unlocked 2 days ago") },
            { "BackDoor", (true, "Locked 1 day ago") },
            { "Window", (true, "Locked 12 hours ago") },
            { "InteriorDoor", (true, "Locked 5 hours ago") },
            { "Gate", (false, "Unlocked 1 week ago") }
        };

        public LocksPage()
        {
            InitializeComponent();
            UpdateLockStatusUI();
        }

        private void UpdateLockStatusUI()
        {
            FrontDoorLockStatus.Text = $"Status: {(locksStatus["FrontDoor"].IsLocked ? "Locked" : "Unlocked")} ({locksStatus["FrontDoor"].LastAction})";
            GarageDoorLockStatus.Text = $"Status: {(locksStatus["GarageDoor"].IsLocked ? "Locked" : "Unlocked")} ({locksStatus["GarageDoor"].LastAction})";
            BackDoorLockStatus.Text = $"Status: {(locksStatus["BackDoor"].IsLocked ? "Locked" : "Unlocked")} ({locksStatus["BackDoor"].LastAction})";
            WindowLockStatus.Text = $"Status: {(locksStatus["Window"].IsLocked ? "Locked" : "Unlocked")} ({locksStatus["Window"].LastAction})";
            InteriorDoorLockStatus.Text = $"Status: {(locksStatus["InteriorDoor"].IsLocked ? "Locked" : "Unlocked")} ({locksStatus["InteriorDoor"].LastAction})";
            GateLockStatus.Text = $"Status: {(locksStatus["Gate"].IsLocked ? "Locked" : "Unlocked")} ({locksStatus["Gate"].LastAction})";
        }

        private void OnFrontDoorLockToggleClicked(object sender, EventArgs e)
        {
            locksStatus["FrontDoor"] = (!locksStatus["FrontDoor"].IsLocked, GetNotificationMessage(!locksStatus["FrontDoor"].IsLocked));
            UpdateLockStatusUI();
        }

        private void OnGarageDoorLockToggleClicked(object sender, EventArgs e)
        {
            locksStatus["GarageDoor"] = (!locksStatus["GarageDoor"].IsLocked, GetNotificationMessage(!locksStatus["GarageDoor"].IsLocked));
            UpdateLockStatusUI();
        }

        private void OnBackDoorLockToggleClicked(object sender, EventArgs e)
        {
            locksStatus["BackDoor"] = (!locksStatus["BackDoor"].IsLocked, GetNotificationMessage(!locksStatus["BackDoor"].IsLocked));
            UpdateLockStatusUI();
        }

        private void OnWindowLockToggleClicked(object sender, EventArgs e)
        {
            locksStatus["Window"] = (!locksStatus["Window"].IsLocked, GetNotificationMessage(!locksStatus["Window"].IsLocked));
            UpdateLockStatusUI();
        }

        private void OnInteriorDoorLockToggleClicked(object sender, EventArgs e)
        {
            locksStatus["InteriorDoor"] = (!locksStatus["InteriorDoor"].IsLocked, GetNotificationMessage(!locksStatus["InteriorDoor"].IsLocked));
            UpdateLockStatusUI();
        }

        private void OnGateLockToggleClicked(object sender, EventArgs e)
        {
            locksStatus["Gate"] = (!locksStatus["Gate"].IsLocked, GetNotificationMessage(!locksStatus["Gate"].IsLocked));
            UpdateLockStatusUI();
        }

        private string GetNotificationMessage(bool isLocked)
        {
            string action = isLocked ? "Locked" : "Unlocked";
            return $"{action} just now"; 
        }
    }
}
