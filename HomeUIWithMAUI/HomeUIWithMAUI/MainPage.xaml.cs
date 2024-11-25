using Microsoft.Maui.Controls;
using System;

namespace HomeUIWithMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Event handler for toggling Fridge Power
        private void OnToggleFridgePower(object sender, EventArgs e)
        {
            bool isOn = FridgeSwitch.IsToggled;
            // Placeholder for integration with Home Business Layer
            // Example: Call a method to update the fridge power state
            DisplayAlert("Fridge Power", $"Fridge is now {(isOn ? "On" : "Off")}.", "OK");
        }

        // Event handler for toggling Dehumidifier Power
        private void OnToggleDehumidifierPower(object sender, EventArgs e)
        {
            bool isOn = DehumidifierSwitch.IsToggled;
            // Placeholder for integration with Home Business Layer
            // Example: Call a method to update the dehumidifier power state
            DisplayAlert("Dehumidifier Power", $"Dehumidifier is now {(isOn ? "On" : "Off")}.", "OK");
        }

        // Method to update Fridge data (to be called by the Home Business Layer)
        public void UpdateFridgeData(int fridgeTemp, int freezerTemp)
        {
            FridgeTempLabel.Text = $"{fridgeTemp}°C";
            FreezerTempLabel.Text = $"{freezerTemp}°C";
        }

        // Method to update Dehumidifier data (to be called by the Home Business Layer)
        public void UpdateDehumidifierData(int waterLevel, int humidity)
        {
            WaterLevelLabel.Text = $"{waterLevel}%";
            HumidityLabel.Text = $"{humidity}%";
        }
    }
}
