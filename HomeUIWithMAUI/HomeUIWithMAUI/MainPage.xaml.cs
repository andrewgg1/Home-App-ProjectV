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

        // Event handler for toggling the smart bulb
        private void OnToggleLightClicked(object sender, EventArgs e)
        {
            WiproSmartBulbSwitch.IsToggled = !WiproSmartBulbSwitch.IsToggled;
        }

        // Event handler for adjusting the thermostat
        private async void OnAdjustThermostatClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Adjust Temperature", "Enter desired temperature (°F):", initialValue: "72", maxLength: 2, keyboard: Keyboard.Numeric);
            if (int.TryParse(result, out int newTemperature))
            {
                DisplayAlert("Temperature Updated", $"Thermostat set to {newTemperature}°F", "OK");
            }
        }

        // Navigation to each hub page
        private async void OnOpenLocksPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocksPage());
        }

        private async void OnOpenSensorsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SensorsPage());
        }

        private async void OnOpenCamerasPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamerasPage());
        }

        private async void OnOpenAlarmsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlarmsPage());
        }

        private async void OnOpenTrackersPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrackersPage());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");
            if (confirm)
            {
                await Navigation.PopToRootAsync();
            }
        }

    }
}
