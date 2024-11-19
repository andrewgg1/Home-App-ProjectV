using HomeUIWithMAUI.Models;
using HomeUIWithMAUI.TCP;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;

namespace HomeUIWithMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Begin listening for TCP connections
            Listener listen = new Listener(this);
            listen.StartListening();
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

        public Thermostat testThermostat = new Thermostat();

        private void OnThermostatSwitchToggled(object sender, ToggledEventArgs e)
        {
            testThermostat.IsOn = e.Value;
            ThermostatSlider.IsEnabled = testThermostat.IsOn;
            ThermostatLabel.Text = $"Thermostat - Status: {(testThermostat.IsOn ? "On" : "Off")}";
            Trace.WriteLine($"Thermostat is on: {testThermostat.IsOn}");
        }

        private void OnThermostatValueChanged(object sender, ValueChangedEventArgs e)
        {
            testThermostat.DesiredTemperature = (int)e.NewValue;
            ThermostatTemp.Text = $"Thermostat - Set temperature: {(int)testThermostat.DesiredTemperature}°C";
            Trace.WriteLine($"Thermostat desired temperature: {testThermostat.DesiredTemperature}");
        }

        // Navigation to each hub page
        private async void OnOpenLocksPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocksPage());
        }

        //private Thermostat testThermostat = new Thermostat();

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
    }
}
