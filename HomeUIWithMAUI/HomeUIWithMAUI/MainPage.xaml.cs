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

        private void OnToggleLightClicked(object sender, EventArgs e)
        {
            WiproSmartBulbSwitch.IsToggled = !WiproSmartBulbSwitch.IsToggled;
        }

        private async void OnAdjustThermostatClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Adjust Temperature", "Enter desired temperature (°F):", initialValue: "72", maxLength: 2, keyboard: Keyboard.Numeric);
            if (int.TryParse(result, out int newTemperature))
            {
                DisplayAlert("Temperature Updated", $"Thermostat set to {newTemperature}°F", "OK");
            }
        }

        private async void OnOpenLocksPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceHubPage());
        }
    }
}
